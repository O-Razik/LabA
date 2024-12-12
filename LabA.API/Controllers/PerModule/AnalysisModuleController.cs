using LabA.Abstraction.DTO;
using LabA.Abstraction.IServices;
using LabA.DAL.Mappers.Dto;
using LabA.DAL.Mappers.Entity;
using Microsoft.AspNetCore.Mvc;

namespace LabA.API.Controllers.PerModule
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnalysisModuleController : ControllerBase
    {
        private readonly IAnalysisService _analysisService;
        private readonly IAnalysisCategoryService _analysisCategoryService;
        private readonly IBiomaterialService _biomaterialService;

        public AnalysisModuleController(IAnalysisService analysisService,
            IAnalysisCategoryService analysisCategoryService,
            IBiomaterialService biomaterialService)
        {
            _analysisService = analysisService;
            _analysisCategoryService = analysisCategoryService;
            _biomaterialService = biomaterialService;
        }

        // GET: api/analysisModule/analyses
        [HttpGet("analyses")]
        public async Task<ActionResult<IEnumerable<AnalysisDto>>> GetAllAnalyses()
        {
            var result = await _analysisService.GetAllAnalysisAsync();
            return Ok(result.Select(a => a.ToDto()));
        }

        // GET: api/analysisModule/analyses/filter
        [HttpGet("analyses/filter")]
        public async Task<ActionResult<IEnumerable<AnalysisDto>>> GetFilteredAnalyses([FromQuery] string? name, [FromQuery] string? categoryName, [FromQuery] double? price)
        {
            var result = await _analysisService.GetAnalysisFilteredAsync(name, categoryName, price);
            return Ok(result.Select(a => a.ToDto()));
        }

        // GET: api/analysisModule/analyses/{id}
        [HttpGet("analyses/{id}")]
        public async Task<ActionResult<AnalysisDto>> GetAnalysis(int id)
        {
            var result = await _analysisService.GetAnalysisByIdAsync(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result.ToDto());
        }

        //GET: api/analysisModule/analyses/{name}
        [HttpGet("analyses/{name}")]
        public async Task<ActionResult<AnalysisDto>> GetAnalysis(string name)
        {
            var result = await _analysisService.GetAnalysisByNameAsync(name);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result.ToDto());
        }

        // POST: api/analysisModule/analyses
        [HttpPost("analyses")]
        public async Task<ActionResult<AnalysisDto>> PostAnalysis([FromBody] AnalysisDto analysis)
        {
            var entity = analysis.ToModel();
            try
            {
                _analysisService.Validate(entity);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            var result = await _analysisService.AddAnalysisAsync(entity);
            return CreatedAtAction("GetAnalysis", new { id = result.AnalysisId }, result.ToDto());
        }

        // PUT: api/analysisModule/analyses/{id}
        [HttpPut("analyses/{id}")]
        public async Task<ActionResult> PutAnalysis(int id, [FromBody] AnalysisDto analysis)
        {
            var entity = analysis.ToModel();
            if (id != entity.AnalysisId)
            {
                return BadRequest();
            }
            try
            {
                _analysisService.Validate(entity);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            var result = await _analysisService.UpdateAnalysisAsync(id, entity);
            if (result == null)
            {
                return NotFound();
            }
            return NoContent();
        }

        // DELETE: api/analysisModule/analyses/{id}
        [HttpDelete("analyses/{id}")]
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

        // GET: api/analysisModule/categories
        [HttpGet("categories")]
        public async Task<ActionResult<IEnumerable<AnalysisCategoryDto>>> GetAllAnalysisCategories()
        {
            var result = await _analysisCategoryService.GetAllAnalysisCategories();
            return Ok(result.Select(a => a.ToDto()));
        }

        // GET: api/analysisModule/categories/{id}
        [HttpGet("categories/{id}")]
        public async Task<ActionResult<AnalysisCategoryDto>> GetAnalysisCategory(int id)
        {
            var result = await _analysisCategoryService.GetAnalysisCategoryById(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result.ToDto());
        }

        // POST: api/analysisModule/categories
        [HttpPost("categories")]
        public async Task<ActionResult<AnalysisCategoryDto>> PostAnalysisCategory([FromBody] AnalysisCategoryDto analysisCategory)
        {
            var entity = analysisCategory.ToModel();
            var result = await _analysisCategoryService.AddAnalysisCategory(entity);
            return CreatedAtAction("GetAnalysisCategory", new { id = result.AnalysisCategoryId }, result.ToDto());
        }

        // PUT: api/analysisModule/categories/{id}
        [HttpPut("categories/{id}")]
        public async Task<ActionResult> PutAnalysisCategory(int id, [FromBody] AnalysisCategoryDto analysisCategory)
        {
            var entity = analysisCategory.ToModel();
            if (id != entity.AnalysisCategoryId)
            {
                return BadRequest();
            }
            var result = await _analysisCategoryService.UpdateAnalysisCategory(id, entity);
            if (result == null)
            {
                return NotFound();
            }
            return NoContent();
        }

        // DELETE: api/analysisModule/categories/{id}
        [HttpDelete("categories/{id}")]
        public async Task<IActionResult> DeleteAnalysisCategory(int id)
        {
            var result = await _analysisCategoryService.GetAnalysisCategoryById(id);
            if (result == null)
            {
                return NotFound();
            }
            await _analysisCategoryService.DeleteAnalysisCategory(id);
            return NoContent();
        }

        // GET: api/analysisModule/biomaterials
        [HttpGet("biomaterials")]
        public async Task<ActionResult<IEnumerable<BiomaterialDto>>> GetAllAnalysisBiomaterials()
        {
            var result = await _biomaterialService.GetAllBiomaterialsAsync();
            return Ok(result.Select(a => a.ToDto()));
        }

        // GET: api/analysisModule/biomaterials/{id}
        [HttpGet("biomaterials/{id}")]
        public async Task<ActionResult<BiomaterialDto>> GetAnalysisBiomaterial(int id)
        {
            var result = await _biomaterialService.GetBiomaterialByIdAsync(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result.ToDto());
        }

        // POST: api/analysisModule/biomaterials
        [HttpPost("biomaterials")]
        public async Task<ActionResult<BiomaterialDto>> PostAnalysisBiomaterial([FromBody] BiomaterialDto biomaterial)
        {
            var entity = biomaterial.ToModel();
            var result = await _biomaterialService.AddBiomaterialAsync(entity);
            return CreatedAtAction("GetAnalysisBiomaterial", new { id = result.BiomaterialId }, result.ToDto());
        }

        // PUT: api/analysisModule/biomaterials/{id}
        [HttpPut("biomaterials/{id}")]
        public async Task<ActionResult> PutAnalysisBiomaterial(int id, [FromBody] BiomaterialDto biomaterial)
        {
            var entity = biomaterial.ToModel();
            if (id != entity.BiomaterialId)
            {
                return BadRequest();
            }
            var result = await _biomaterialService.UpdateBiomaterialAsync(id, entity);
            if (result == null)
            {
                return NotFound();
            }
            return NoContent();
        }

        // DELETE: api/analysisModule/biomaterials/{id}
        [HttpDelete("biomaterials/{id}")]
        public async Task<IActionResult> DeleteAnalysisBiomaterial(int id)
        {
            var result = await _biomaterialService.GetBiomaterialByIdAsync(id);
            if (result == null)
            {
                return NotFound();
            }
            await _biomaterialService.DeleteBiomaterialAsync(id);
            return NoContent();
        }
    }
}
