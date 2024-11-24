using LabA.Abstraction.IModel;
using LabA.Abstraction.IServices;
using Microsoft.AspNetCore.Mvc;

namespace LabA.API.Controllers;

public class LaboratoryController : ControllerBase
{
    private readonly ILaboratoryService _service;

    public LaboratoryController(ILaboratoryService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ILaboratory>>> GetAll()
    {
        var result = await _service.GetAllLaboratoriesAsync();
        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ILaboratory>> GetById(int id)
    {
        var result = await _service.GetLaboratoryByIdAsync(id);
        if (result == null) return NotFound();
        return Ok(result);
    }

    [HttpPost]
    public async Task<ActionResult<ILaboratory>> Post(ILaboratory model)
    {
        try
        {
            _service.Validate(model);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
        var result = await _service.AddLaboratoryAsync(model);
        return CreatedAtAction(nameof(GetById), new { id = result.LaboratoryId }, result);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, ILaboratory model)
    {
        if (id != model.LaboratoryId) return BadRequest();
        try
        {
            _service.Validate(model);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
        await _service.UpdateLaboratoryAsync(id, model);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _service.DeleteLaboratoryAsync(id);
        return NoContent();
    }
}