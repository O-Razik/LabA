using LabA.Abstraction.IModel;
using LabA.Abstraction.IServices;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LabA.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnalysisCategoriesController : ControllerBase
    {
        private readonly IAnalysisCategoryService _service;

        public AnalysisCategoriesController(IAnalysisCategoryService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<IAnalysisCategory>>> GetAll()
        {
            var result = await _service.GetAllAnalysisCategories();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<IAnalysisCategory>> GetById(int id)
        {
            var result = await _service.GetAnalysisCategoryById(id);
            if (result == null) return NotFound();
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<IAnalysisCategory>> Post(IAnalysisCategory model)
        {
            try
            {
                _service.Validate(model);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            var result = await _service.AddAnalysisCategory(model);
            return CreatedAtAction(nameof(GetById), new { id = result.AnalysisCategoryId }, result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, IAnalysisCategory model)
        {
            if (id != model.AnalysisCategoryId) return BadRequest();
            try
            {
                _service.Validate(model);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            await _service.UpdateAnalysisCategory(id, model);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var existing = await _service.GetAnalysisCategoryById(id);
            if (existing == null) return NotFound();
            await _service.DeleteAnalysisCategory(id);
            return NoContent();
        }
    }
}
