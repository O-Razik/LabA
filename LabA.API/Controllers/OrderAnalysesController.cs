using LabA.Abstraction.IModel;
using LabA.Abstraction.IServices;
using Microsoft.AspNetCore.Mvc;

namespace LabA.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class OrderAnalysesController : ControllerBase
{
    private readonly IOrderAnalysisService _service;

    public OrderAnalysesController(IOrderAnalysisService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<IOrderAnalysis>>> GetAll()
    {
        var result = await _service.GetAllOrderAnalysisAsync();
        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<IOrderAnalysis>> GetById(int id)
    {
        var result = await _service.GetOrderAnalysisByIdAsync(id);
        if (result == null) return NotFound();
        return Ok(result);
    }

    [HttpPost]
    public async Task<ActionResult<IOrderAnalysis>> Post(IOrderAnalysis model)
    {
        try
        {
            _service.Validate(model);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
        var result = await _service.AddOrderAnalysisAsync(model);
        return CreatedAtAction(nameof(GetById), new { id = result.OrderAnalysisId }, result);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, IOrderAnalysis model)
    {
        if (id != model.OrderAnalysisId) return BadRequest();
        try
        {
            _service.Validate(model);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
        await _service.UpdateOrderAnalysisAsync(id, model);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _service.DeleteOrderAnalysisAsync(id);
        return NoContent();
    }
}