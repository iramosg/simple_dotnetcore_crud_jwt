using System.ComponentModel.DataAnnotations;

namespace cruddotnetcore.API.Dtos
{
  public class UserForRegisterDtos
  {
    [Required(ErrorMessage = "Campo obrigatório")]
    public string Username { get; set; }

    [Required(ErrorMessage = "Campo obrigatório")]
    [StringLength(8, MinimumLength = 4, ErrorMessage = "A senha deve conter de 4 há 8 dígitos")]
    public string Password { get; set; }
  }
}