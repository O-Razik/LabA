using LabA.Abstraction.IModel;
using LabA.Abstraction.IServices;
using Microsoft.AspNetCore.Mvc;

namespace LabA.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ClientsController : ControllerBase
{
    private readonly IClientService _service;

    public ClientsController(IClientService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<IClient>>> GetAll()
    {
        var result = await _service.GetAllClientsAsync();
        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<IClient>> GetById(int id)
    {
        var result = await _service.GetClientByIdAsync(id);
        if (result == null) return NotFound();
        return Ok(result);
    }

    [HttpPost]
    public async Task<ActionResult<IClient>> Post(IClient model)
    {
        try
        {
            _service.Validate(model);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
        var result = await _service.AddClientAsync(model);
        return CreatedAtAction(nameof(GetById), new { id = result.ClientId }, result);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, IClient model)
    {
        if (id != model.ClientId) return BadRequest();
        try
        {
            _service.Validate(model);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
        await _service.UpdateClientAsync(id, model);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _service.DeleteClientAsync(id);
        return NoContent();
    }
}