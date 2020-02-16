using System.ComponentModel.DataAnnotations;

namespace cruddotnetcore.API.Dtos
{
  public class UserForLoginDto
  {
    [Required(ErrorMessage = "Campo obrigatório")]
    public string Username { get; set; }
    [Required(ErrorMessage = "Campo obrigatório")]
    public string Password { get; set; }
  }
}