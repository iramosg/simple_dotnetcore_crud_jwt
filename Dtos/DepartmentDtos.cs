using System.ComponentModel.DataAnnotations;

namespace cruddotnetcore.API.Dtos
{
  public class DepartmentDtos
  {
    [Required(ErrorMessage = "Campo obrigatório")]
    public string Name { get; set; }
  }
}