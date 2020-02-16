using System.Collections.Generic;
using cruddotnetcore.API.Domain.Models;
using Newtonsoft.Json;

namespace cruddotnetcore.API.Domain.Persistence.Contexts
{
  public class DbInitializer
  {
    private readonly DataContext _context;

    public DbInitializer(DataContext context)
    {
      _context = context;

    }

    public void SeedUsers()
    {
      var _data = System.IO.File.ReadAllText("Domain/Seeders/userDataSeed.json");
      var data = JsonConvert.DeserializeObject<List<User>>(_data);

      foreach (var item in data)
      {
        byte[] passwordHash, passwordSalt;
        CreatePasswordHash(item.Password, out passwordHash, out passwordSalt);

        item.PasswordHash = passwordHash;
        item.PasswordSalt = passwordSalt;

        item.Username = item.Username.ToLower();

        _context.Users.Add(item);

      }

      _context.SaveChanges();

    }


    public void SeedDepartment()
    {
      var _data = System.IO.File.ReadAllText("Domain/Seeders/departmentDataSeed.json");
      var data = JsonConvert.DeserializeObject<List<Department>>(_data);

      foreach (var item in data)
      {
        _context.Departments.Add(item);
      }

      _context.SaveChanges();

    }

    public void SeedEmployee()
    {
      var _data = System.IO.File.ReadAllText("Domain/Seeders/EmployeeDataSeed.json");
      var data = JsonConvert.DeserializeObject<List<Employee>>(_data);

      foreach (var item in data)
      {
        _context.Employees.Add(item);
      }

      _context.SaveChanges();

    }

    private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
    {
      using (var hmac = new System.Security.Cryptography.HMACSHA512())
      {

        passwordSalt = hmac.Key;
        passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));

      }
    }
  }
}