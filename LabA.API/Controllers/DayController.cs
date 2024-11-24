using LabA.Abstraction.IModel;
using LabA.Abstraction.IServices;
using Microsoft.AspNetCore.Mvc;

namespace LabA.API.Controllers;

public class DayController : ControllerBase
{
    private readonly IDayService _service;

    public DayController(IDayService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<IDay>>> GetAll()
    {
        var result = await _service.GetAllDaysAsync();
        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<IDay>> GetById(int id)
    {
        var result = await _service.GetDayByIdAsync(id);
        if (result == null) return NotFound();
        return Ok(result);
    }

    [HttpPost]
    public async Task<ActionResult<IDay>> Post(IDay model)
    {
        try
        {
            _service.Validate(model);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
        var result = await _service.AddDayAsync(model);
        return CreatedAtAction(nameof(GetById), new { id = result.DayId }, result);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, IDay model)
    {
        if (id != model.DayId) return BadRequest();
        try
        {
            _service.Validate(model);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
        await _service.UpdateDayAsync(id, model);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _service.DeleteDayAsync(id);
        return NoContent();
    }
}