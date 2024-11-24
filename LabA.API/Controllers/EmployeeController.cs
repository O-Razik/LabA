using LabA.Abstraction.IModel;
using LabA.Abstraction.IServices;
using Microsoft.AspNetCore.Mvc;

namespace LabA.API.Controllers;

public class EmployeeController : Controller
{
    private readonly IEmployeeService _service;

    public EmployeeController(IEmployeeService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<IEmployee>>> GetAll()
    {
        var result = await _service.GetAllEmployeesAsync();
        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<IEmployee>> GetById(int id)
    {
        var result = await _service.GetEmployeeByIdAsync(id);
        if (result == null) return NotFound();
        return Ok(result);
    }

    [HttpPost]
    public async Task<ActionResult<IEmployee>> Post(IEmployee model)
    {
        try
        {
            _service.Validate(model);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
        var result = await _service.AddEmployeeAsync(model);
        return CreatedAtAction(nameof(GetById), new { id = result.EmployeeId }, result);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, IEmployee model)
    {
        if (id != model.EmployeeId) return BadRequest();
        try
        {
            _service.Validate(model);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
        await _service.UpdateEmployeeAsync(id, model);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        if (id < 0) return BadRequest();
        await _service.DeleteEmployeeAsync(id);
        return NoContent();
    }
}