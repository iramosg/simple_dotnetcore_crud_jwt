using System.Collections.Generic;
using System.Threading.Tasks;
using cruddotnetcore.API.Domain.Models;

namespace cruddotnetcore.API.Domain.Repositories
{
  public interface IEmployeeRepository
  {
    Task<IEnumerable<Employee>> ListAsync();

    Task<Employee> FindByIdAsync(int id);
    Task<Employee> FirstByIdAsync(int id);

    Task<Employee> Save(Employee data);

    Task<Employee> Update(Employee data);

    void Delete(Employee data);
  }
}