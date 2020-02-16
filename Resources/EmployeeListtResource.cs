using System.Runtime.Serialization;
using cruddotnetcore.API.Domain.Models;

namespace cruddotnetcore.API.Resources
{
  public class EmployeeListResource
  {
    public int Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }

    [IgnoreDataMember]
    public Department _Department { get; set; }

    public string Department
    {
      get
      {
        return _Department.Name;
      }
    }
  }
}