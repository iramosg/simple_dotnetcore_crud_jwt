using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace cruddotnetcore.API.Domain.Models
{
  public class Employee
  {
    public int Id { get; set; }

    [Required]
    public string Name { get; set; }

    [Required]
    public string Email { get; set; }

    [Required]
    public int DepartmentId { get; set; }

    [ForeignKey("DepartmentId")]
    public Department Department { get; set; }
  }
}