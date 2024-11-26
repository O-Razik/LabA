using LabA.Abstraction.IModel;
using LabA.Abstraction.IServices;
using Microsoft.AspNetCore.Mvc;

namespace LabA.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class StatusesController : ControllerBase
{
    private readonly IStatusService _service;

    public StatusesController(IStatusService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<IStatus>>> GetAll()
    {
        var result = await _service.GetAllStatusesAsync();
        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<IStatus>> GetById(int id)
    {
        var result = await _service.GetStatusByIdAsync(id);
        if (result == null) return NotFound();
        return Ok(result);
    }

    [HttpPost]
    public async Task<ActionResult<IStatus>> Post(IStatus model)
    {
        try
        {
            _service.Validate(model);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
        var result = await _service.AddStatusAsync(model);
        return CreatedAtAction(nameof(GetById), new { id = result.StatusId }, result);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, IStatus model)
    {
        if (id != model.StatusId) return BadRequest();
        try
        {
            _service.Validate(model);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
        await _service.UpdateStatusAsync(id, model);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _service.DeleteStatusAsync(id);
        return NoContent();
    }
}