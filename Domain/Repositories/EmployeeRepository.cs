using System.Collections.Generic;
using System.Threading.Tasks;
using cruddotnetcore.API.Domain.Models;
using cruddotnetcore.API.Domain.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace cruddotnetcore.API.Domain.Repositories
{
  public class EmployeeRepository : BaseRepository, IEmployeeRepository
  {

    public EmployeeRepository(DataContext context) : base(context)
    {
    }

    public async Task<Employee> FirstByIdAsync(int id) => await _context.Employees.Include(x => x.Department).AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);

    public async Task<Employee> FindByIdAsync(int id) => await _context.Employees.FindAsync(id);

    public async Task<IEnumerable<Employee>> ListAsync() => await _context.Employees.Include(x => x.Department).ToListAsync();


    public async Task<Employee> Save(Employee data)
    {
      await _context.Employees.AddAsync(data);
      await _context.SaveChangesAsync();

      return data;
    }

    public async Task<Employee> Update(Employee data)
    {
      _context.Update(data);
      await _context.SaveChangesAsync();

      return data;
    }

    public async void Delete(Employee data)
    {
      _context.Remove(data);
      await _context.SaveChangesAsync();
    }
  }
}