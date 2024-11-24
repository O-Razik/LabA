using LabA.Abstraction.IModel;
using LabA.Abstraction.IServices;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LabA.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnalysisBiomaterialsController : ControllerBase
    {
        private readonly IAnalysisBiomaterialService _service;

        public AnalysisBiomaterialsController(IAnalysisBiomaterialService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<IAnalysisBiomaterial>>> GetAll()
        {
            var result = await _service.GetAllAnalysisBiomaterialsAsync();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<IAnalysisBiomaterial>> GetById(int id)
        {
            var result = await _service.GetAnalysisBiomaterialByIdAsync(id);
            if (result == null) return NotFound();
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<IAnalysisBiomaterial>> Post(IAnalysisBiomaterial model)
        {
            try
            {
                _service.Validate(model);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            var result = await _service.AddAnalysisBiomaterialAsync(model);
            return CreatedAtAction(nameof(GetById), new { id = result.AnalysisBiomaterialId }, result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, IAnalysisBiomaterial model)
        {
            if (id != model.AnalysisBiomaterialId) return BadRequest();
            try
            {
                _service.Validate(model);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            await _service.UpdateAnalysisBiomaterialAsync(id, model);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var existing = await _service.GetAnalysisBiomaterialByIdAsync(id);
            if (existing == null) return NotFound();
            await _service.DeleteAnalysisBiomaterialAsync(id);
            return NoContent();
        }
    }
}
