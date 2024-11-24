using LabA.Abstraction.IModel;
using LabA.Abstraction.IServices;
using Microsoft.AspNetCore.Mvc;

namespace LabA.API.Controllers;

public class ScheduleController : Controller
{
    private readonly IScheduleService _service;

    public ScheduleController(IScheduleService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ISchedule>>> GetAll()
    {
        var result = await _service.GetAllSchedulesAsync();
        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ISchedule>> GetById(int id)
    {
        var result = await _service.GetScheduleByIdAsync(id);
        if (result == null) return NotFound();
        return Ok(result);
    }

    [HttpPost]
    public async Task<ActionResult<ISchedule>> Post(ISchedule model)
    {
        try
        {
            _service.Validate(model);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
        var result = await _service.AddScheduleAsync(model);
        return CreatedAtAction(nameof(GetById), new { id = result.ScheduleId }, result);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, ISchedule model)
    {
        if (id != model.ScheduleId) return BadRequest();
        try
        {
            _service.Validate(model);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
        await _service.UpdateScheduleAsync(id, model);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _service.DeleteScheduleAsync(id);
        return NoContent();
    }
}