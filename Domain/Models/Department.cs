using System;
using System.ComponentModel.DataAnnotations;

namespace cruddotnetcore.API.Domain.Models
{
  public class Department
  {

    [Key]
    public int Id { get; set; }

    [Required]
    public string Name { get; set; }

  }
}