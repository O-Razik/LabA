using Microsoft.AspNetCore.Mvc;
using LabA.Abstraction.IServices;
using LabA.Abstraction.IModel;

namespace LabA.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnalysesController : ControllerBase
    {
        private readonly IAnalysisService _analysisService;

        public AnalysesController(IAnalysisService analysisService)
        {
            _analysisService = analysisService;
        }

        // GET: api/analyses
        [HttpGet]
        public async Task<ActionResult<IEnumerable<IAnalysis>>> GetAll()
        {
            var result = await _analysisService.GetAllAnalysisAsync();
            return Ok(result);
        }

        // GET: api/analyses/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<IAnalysis>> GetAnalysis(int id)
        {
            var result = await _analysisService.GetAnalysisByIdAsync(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        // POST: api/analyses
        [HttpPost]
        public async Task<ActionResult<IAnalysis>> PostAnalysis(IAnalysis analysis)
        {
            try
            {
                _analysisService.Validate(analysis);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            var result = await _analysisService.AddAnalysisAsync(analysis);
            return CreatedAtAction("GetAnalysis", new { id = result.AnalysisId }, result);
        }

        // PUT: api/analyses/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAnalysis(int id, IAnalysis analysis)
        {
            if (id != analysis.AnalysisId)
            {
                return BadRequest();
            }
            try
            {
                _analysisService.Validate(analysis);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            await _analysisService.UpdateAnalysisAsync(id, analysis);
            return NoContent();
        }

        // DELETE: api/analyses/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAnalysis(int id)
        {
            var result = await _analysisService.GetAnalysisByIdAsync(id);
            if (result == null)
            {
                return NotFound();
            }
            await _analysisService.DeleteAnalysisAsync(id);
            return NoContent();
        }
    }
}
