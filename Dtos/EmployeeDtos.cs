using System.ComponentModel.DataAnnotations;

namespace cruddotnetcore.API.Dtos
{
  public class EmployeeDtos
  {
    [Required(ErrorMessage = "Campo obrigatório")]
    public string Name { get; set; }

    [Required(ErrorMessage = "Campo obrigatório")]
    public string Email { get; set; }

    [Required(ErrorMessage = "Campo obrigatório")]
    public int DepartmentId { get; set; }
  }
}