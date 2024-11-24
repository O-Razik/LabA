using LabA.Abstraction.IModel;
using LabA.Abstraction.IServices;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LabA.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnalysisResultsController : ControllerBase
    {
        private readonly IAnalysisResultService _service;

        public AnalysisResultsController(IAnalysisResultService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<IAnalysisResult>>> GetAll()
        {
            var result = await _service.GetAllAnalysisResultsAsync();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<IAnalysisResult>> GetById(int id)
        {
            var result = await _service.GetAnalysisResultAsync(id);
            if (result == null) return NotFound();
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<IAnalysisResult>> Post(IAnalysisResult model)
        {
            try
            {
                _service.Validate(model);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            var result = await _service.AddAnalysisResultAsync(model);
            return CreatedAtAction(nameof(GetById), new { id = result.AnalysisResultId }, result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, IAnalysisResult model)
        {
            if (id != model.AnalysisResultId) return BadRequest();
            try
            {
                _service.Validate(model);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            await _service.UpdateAnalysisResultAsync(id, model);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var existing = await _service.GetAnalysisResultAsync(id);
            if (existing == null) return NotFound();
            await _service.DeleteAnalysisResultAsync(id);
            return NoContent();
        }
    }
}
