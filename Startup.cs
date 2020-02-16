using System;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Text;
using AutoMapper;
using cruddotnetcore.API.Domain.Persistence.Contexts;
using cruddotnetcore.API.Domain.Repositories;
using cruddotnetcore.API.Helpers;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace cruddotnetcore
{
  public class Startup
  {

    public Startup(IConfiguration configuration)
    {
      Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    // This method gets called by the runtime. Use this method to add services to the container.
    public void ConfigureServices(IServiceCollection services)
    {
      //Injeta o dbcontext
      services.AddDbContext<DataContext>(x => x.UseSqlite(Configuration.GetConnectionString("DefaultConnection")));

      // add dbInitializer seeder
      services.AddTransient<DbInitializer>();

      //criando o repositório global
      services.AddScoped<IAuthRepository, AuthRepository>();
      services.AddScoped<IEmployeeRepository, EmployeeRepository>();
      services.AddScoped<IDepartmentRepository, DepartmentRepository>();

      //add authentication service
      services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
          .AddJwtBearer(options =>
          {
            options.TokenValidationParameters = new TokenValidationParameters
            {
              ValidateIssuerSigningKey = true,
              IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII
                          .GetBytes(Configuration.GetSection("AppSettings:Token").Value)),
              ValidateIssuer = false,
              ValidateAudience = false
            };
          });

      services.AddCors(options => options.AddPolicy("ApiCorsPolicy", builder =>
          {
            builder.WithOrigins("http://localhost:8080").AllowAnyMethod().AllowAnyHeader();
          }));

      services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

      services.AddAutoMapper();

    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IHostingEnvironment env, DbInitializer seeder)
    {
      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
      }
      else
      {

        //configura uma forma mais amigável de dar erros
        app.UseExceptionHandler(builder =>
        {
          builder.Run(async context =>
          {
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            var error = context.Features.Get<IExceptionHandlerFeature>();
            if (error != null)
            {
              context.Response.AddApplicationError(error.Error.Message);
              await context.Response.WriteAsync(error.Error.Message.ToString());
            }
          });
        });

        //app.UseHsts();
      }

      // add seeder rodar apenas uma vez -- Jaqueline Benedicto
      seeder.SeedUsers();
      seeder.SeedDepartment();
      seeder.SeedEmployee();

      app.UseCors("AllowSpecificOrigin");

      // autenticação jwt
      app.Use(async (context, next) =>
      {
        var authHeader = context.Request.Headers["Authorization"].ToString();
        if (authHeader != null && authHeader.StartsWith("bearer", StringComparison.OrdinalIgnoreCase))
        {
          var tokenStr = authHeader.Substring("Bearer ".Length).Trim();
          var handler = new JwtSecurityTokenHandler();
          //var token = handler.ReadToken(tokenStr) as JwtSecurityToken;
          //var nameid = token.Claims.First(claim => claim.Type == "nameid").Value;

          //var identity = new ClaimsIdentity(token.Claims);
          //context.User = new ClaimsPrincipal(identity);
        }
        await next();
      });

      //add authentication --sempre chamar antes do UseMVC
      app.UseAuthentication();

      app.UseCors("ApiCorsPolicy");

      app.UseMvc();
    }
  }
}
