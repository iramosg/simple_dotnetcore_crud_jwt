using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace cruddotnetcore.API.Domain.Models
{
  public class User
  {
    public int Id { get; set; }

    [Required]
    public string Username { get; set; }

    [NotMapped]
    public string Password { get; set; }

    [Required]
    public byte[] PasswordHash { get; set; }

    [Required]
    public byte[] PasswordSalt { get; set; }

  }
}