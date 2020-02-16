using AutoMapper;
using cruddotnetcore.API.Domain.Models;
using cruddotnetcore.API.Resources;

namespace cruddotnetcore.API.Mapping
{
  public class ModelToResourceProfile : Profile
  {

    public ModelToResourceProfile()
    {
      CreateMap<Employee, EmployeeResource>();
      CreateMap<Employee, EmployeeListResource>();
    }

  }
}