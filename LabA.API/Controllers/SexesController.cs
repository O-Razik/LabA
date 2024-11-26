using LabA.Abstraction.IModel;
using LabA.Abstraction.IServices;
using Microsoft.AspNetCore.Mvc;

namespace LabA.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SexesController : Controller
{
    private readonly ISexService _service;

    public SexesController(ISexService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ISex>>> GetAll()
    {
        var result = await _service.GetAllSexesAsync();
        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ISex>> GetById(int id)
    {
        var result = await _service.GetSexByIdAsync(id);
        if (result == null) return NotFound();
        return Ok(result);
    }

    [HttpPost]
    public async Task<ActionResult<ISex>> Post(ISex model)
    {
        try
        {
            _service.Validate(model);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
        var result = await _service.AddSexAsync(model);
        return CreatedAtAction(nameof(GetById), new { id = result.SexId }, result);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, ISex model)
    {
        if (id != model.SexId) return BadRequest();
        try
        {
            _service.Validate(model);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
        await _service.UpdateSexAsync(id, model);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _service.DeleteSexAsync(id);
        return NoContent();
    }
}