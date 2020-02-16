using System.Threading.Tasks;
using cruddotnetcore.API.Domain.Models;
using cruddotnetcore.API.Domain.Repositories;
using cruddotnetcore.API.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace cruddotnetcore.API.Controllers
{

  [Authorize]
  [Route("api/[controller]")]
  [ApiController]
  public class DepartmentController : ControllerBase
  {
    private readonly IDepartmentRepository _repo;

    public DepartmentController(IDepartmentRepository repo)
    {
      _repo = repo;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
      var dados = await _repo.ListAsync();
      return Ok(dados);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
      var dado = await _repo.FindByIdAsync(id);

      if (dado == null)
        return NotFound();

      return Ok(dado);
    }

    [HttpPost]
    public async Task<IActionResult> Post(DepartmentDtos data)
    {
      if (await _repo.DataExists(data.Name))
        return BadRequest("Departamento já existe!");

      var dataToCreate = new Department
      {
        Name = data.Name
      };

      var created = await _repo.Save(dataToCreate);

      return StatusCode(201, created);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, DepartmentDtos data)
    {
      var editData = await _repo.FindByIdAsync(id);

      if (editData == null)
        return NotFound();

      editData.Name = data.Name;

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