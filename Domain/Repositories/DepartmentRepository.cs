using System.Collections.Generic;
using System.Threading.Tasks;
using cruddotnetcore.API.Domain.Models;
using cruddotnetcore.API.Domain.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace cruddotnetcore.API.Domain.Repositories
{
  public class DepartmentRepository : BaseRepository, IDepartmentRepository
  {

    public DepartmentRepository(DataContext context) : base(context)
    {
    }
    public async Task<IEnumerable<Department>> ListAsync() => await _context.Departments.ToListAsync();

    public async Task<Department> FindByIdAsync(int id) => await _context.Departments.FindAsync(id);

    public async Task<Department> Save(Department data)
    {
      await _context.Departments.AddAsync(data);

      await _context.SaveChangesAsync();

      return data;
    }

    public async Task<bool> DataExists(string name)
    {
      if (await _context.Departments.AnyAsync(x => x.Name == name))
        return true;

      return false;
    }

    public async Task<Department> Update(Department data)
    {
      _context.Update(data);
      await _context.SaveChangesAsync();

      return data;
    }

    public async void Delete(Department data)
    {
      _context.Remove(data);
      await _context.SaveChangesAsync();
    }
  }
}