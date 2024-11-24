using LabA.Abstraction.IModel;
using LabA.Abstraction.IServices;
using Microsoft.AspNetCore.Mvc;

namespace LabA.API.Controllers;

public class LaboratoryScheduleController : Controller
{
    private readonly ILaboratoryScheduleService _service;

    public LaboratoryScheduleController(ILaboratoryScheduleService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ILaboratorySchedule>>> GetAll()
    {
        var result = await _service.GetAllLaboratorySchedulesAsync();
        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ILaboratorySchedule>> GetById(int id)
    {
        var result = await _service.GetLaboratoryScheduleByIdAsync(id);
        if (result == null) return NotFound();
        return Ok(result);
    }

    [HttpPost]
    public async Task<ActionResult<ILaboratorySchedule>> Post(ILaboratorySchedule model)
    {
        try
        {
            _service.Validate(model);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
        var result = await _service.AddLaboratoryScheduleAsync(model);
        return CreatedAtAction(nameof(GetById), new { id = result.LaboratoryScheduleId }, result);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, ILaboratorySchedule model)
    {
        if (id != model.LaboratoryScheduleId) return BadRequest();
        try
        {
            _service.Validate(model);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
        await _service.UpdateLaboratoryScheduleAsync(id, model);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        if (id < 0) return BadRequest();
        await _service.DeleteLaboratoryScheduleAsync(id);
        return NoContent();
    }
}