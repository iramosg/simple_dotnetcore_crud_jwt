using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using cruddotnetcore.API.Domain.Models;
using cruddotnetcore.API.Domain.Repositories;
using cruddotnetcore.API.Dtos;
using cruddotnetcore.API.Resources;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace cruddotnetcore.API.Controllers
{
  [Authorize]
  [Route("api/[controller]")]
  [ApiController]
  public class EmployeeController : ControllerBase
  {
    private readonly IEmployeeRepository _repo;
    private readonly IMapper _mapper;

    public EmployeeController(IEmployeeRepository repo, IMapper mapper)
    {
      _repo = repo;
      _mapper = mapper;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
      var dados = await _repo.ListAsync();
      var resources = _mapper.Map<IEnumerable<Employee>, IEnumerable<EmployeeListResource>>(dados);

      return Ok(resources);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
      var dado = await _repo.FirstByIdAsync(id);

      if (dado == null)
        return NotFound();

      var resources = _mapper.Map<Employee, EmployeeResource>(dado);

      return Ok(resources);
    }

    [HttpPost]
    public async Task<IActionResult> Post(EmployeeDtos data)
    {
      var dataToCreate = new Employee
      {
        Name = data.Name,
        Email = data.Email,
        DepartmentId = data.DepartmentId
      };

      var created = await _repo.Save(dataToCreate);

      return StatusCode(201, created);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, EmployeeDtos data)
    {
      var editData = await _repo.FindByIdAsync(id);

      if (editData == null)
        return NotFound();

      editData.Name = data.Name;
      editData.Email = data.Email;
      editData.DepartmentId = data.DepartmentId;

      var updated = await _repo.Update(editData);

      return StatusCode(204);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
      var editData = await _repo.FindByIdAsync(id);

      if (editData == null)
        return NotFound();

      _repo.Delete(editData);

      return StatusCode(200);
    }

  }
}