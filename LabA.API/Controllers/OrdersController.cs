using LabA.Abstraction.IModel;
using LabA.Abstraction.IServices;
using Microsoft.AspNetCore.Mvc;

namespace LabA.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class OrdersController : ControllerBase
{
    private readonly IOrderService _service;

    public OrdersController(IOrderService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<IOrder>>> GetAll()
    {
        var result = await _service.GetAllOrdersAsync();
        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<IOrder>> GetById(int id)
    {
        var result = await _service.GetOrderByIdAsync(id);
        if (result == null) return NotFound();
        return Ok(result);
    }

    [HttpPost]
    public async Task<ActionResult<IOrder>> Post(IOrder model)
    {
        try
        {
            _service.Validate(model);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
        var result = await _service.AddOrderAsync(model);
        return CreatedAtAction(nameof(GetById), new { id = result.OrderId }, result);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, IOrder model)
    {
        if (id != model.OrderId) return BadRequest();
        try
        {
            _service.Validate(model);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
        await _service.UpdateOrderAsync(id, model);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _service.DeleteOrderAsync(id);
        return NoContent();
    }
}