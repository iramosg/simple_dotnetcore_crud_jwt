using cruddotnetcore.API.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace cruddotnetcore.API.Domain.Persistence.Contexts
{
  public class DataContext : DbContext
  {
    public DataContext(DbContextOptions<DataContext> options) : base(options) { }

    public DbSet<User> Users { get; set; }

    public DbSet<Department> Departments { get; set; }

    public DbSet<Employee> Employees { get; set; }
  }
}