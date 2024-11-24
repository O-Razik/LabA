using LabA.Abstraction.IModel;
using LabA.Abstraction.IServices;
using Microsoft.AspNetCore.Mvc;

namespace LabA.API.Controllers;

public class PositionController : ControllerBase
{
    private readonly IPositionService _service;

    public PositionController(IPositionService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<IPosition>>> GetAll()
    {
        var result = await _service.GetAllPositionsAsync();
        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<IPosition>> GetById(int id)
    {
        var result = await _service.GetPositionByIdAsync(id);
        if (result == null) return NotFound();
        return Ok(result);
    }

    [HttpPost]
    public async Task<ActionResult<IPosition>> Post(IPosition model)
    {
        try
        {
            _service.Validate(model);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
        var result = await _service.AddPositionAsync(model);
        return CreatedAtAction(nameof(GetById), new { id = result.PositionId }, result);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, IPosition model)
    {
        if (id != model.PositionId) return BadRequest();
        try
        {
            _service.Validate(model);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
        await _service.UpdatePositionAsync(id, model);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _service.DeletePositionAsync(id);
        return NoContent();
    }
}