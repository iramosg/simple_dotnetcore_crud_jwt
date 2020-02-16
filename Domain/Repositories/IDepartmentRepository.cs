using System.Collections.Generic;
using System.Threading.Tasks;
using cruddotnetcore.API.Domain.Models;

namespace cruddotnetcore.API.Domain.Repositories
{
  public interface IDepartmentRepository
  {
    Task<IEnumerable<Department>> ListAsync();

    Task<Department> FindByIdAsync(int id);

    Task<Department> Save(Department data);

    Task<bool> DataExists(string name);

    Task<Department> Update(Department data);

    void Delete(Department data);
  }
}