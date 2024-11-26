using LabA.Abstraction.IModel;
using LabA.Abstraction.IServices;
using Microsoft.AspNetCore.Mvc;

namespace LabA.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BiomaterialsController : ControllerBase
{
    private readonly IBiomaterialService _service;

    public BiomaterialsController(IBiomaterialService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<IBiomaterial>>> GetAll()
    {
        var result = await _service.GetAllBiomaterialsAsync();
        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<IBiomaterial>> GetById(int id)
    {
        var result = await _service.GetBiomaterialByIdAsync(id);
        if (result == null) return NotFound();
        return Ok(result);
    }

    [HttpPost]
    public async Task<ActionResult<IBiomaterial>> Post(IBiomaterial model)
    {
        try
        {
            _service.Validate(model);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
        var result = await _service.AddBiomaterialAsync(model);
        return CreatedAtAction(nameof(GetById), new { id = result.BiomaterialId }, result);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, IBiomaterial model)
    {
        if (id != model.BiomaterialId) return BadRequest();
        try
        {
            _service.Validate(model);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
        await _service.UpdateBiomaterialAsync(id, model);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _service.DeleteBiomaterialAsync(id);
        return NoContent();
    }
}