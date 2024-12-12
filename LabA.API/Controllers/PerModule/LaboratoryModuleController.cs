using LabA.Abstraction.DTO;
using LabA.Abstraction.IServices;
using LabA.DAL.Mappers.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LabA.API.Controllers.PerModule
{
    [Route("api/[controller]")]
    [ApiController]
    public class LaboratoryModuleController : ControllerBase
    {
        private readonly ILaboratoryService _laboratoryService;
        private readonly IScheduleService _scheduleService;
        private readonly IDayService _dayService;
        private readonly ICityService _cityService;
        private readonly IEmployeeService _employeeService;
        private readonly IPositionService _positionService;

        public LaboratoryModuleController(ILaboratoryService laboratoryService,
            IScheduleService scheduleService,
            IDayService dayService,
            ICityService cityService,
            IEmployeeService employeeService,
            IPositionService positionService)
        {
            _laboratoryService = laboratoryService;
            _scheduleService = scheduleService;
            _dayService = dayService;
            _cityService = cityService;
            _employeeService = employeeService;
            _positionService = positionService;
        }

        // GET: api/laboratoryModule/cities
        [HttpGet("cities")]
        public async Task<ActionResult<IEnumerable<CityDto>>> GetAllCities()
        {
            var result = await _cityService.GetAllCitiesAsync();
            return Ok(result.Select(c => c.ToDto()));
        }

        // GET: api/laboratoryModule/cities/{id}
        [HttpGet("cities/{id}")]
        public async Task<ActionResult<CityDto>> GetCity(int id)
        {
            var result = await _cityService.GetCityByIdAsync(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result.ToDto());
        }

        // POST: api/laboratoryModule/cities
        [HttpPost("cities")]
        public async Task<ActionResult<CityDto>> AddCity(CityDto cityDto)
        {
            try
            {
                var city = cityDto.ToModel();
                var result = await _cityService.AddCityAsync(city);
                return CreatedAtAction(nameof(GetCity), new { id = result.CityId }, result.ToDto());
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        // PUT: api/laboratoryModule/cities/{id}
        [HttpPut("cities/{id}")]
        public async Task<ActionResult<CityDto>> UpdateCity(int id, [FromBody] CityDto cityDto)
        {
            if (id != cityDto.CityId)
            {
                return BadRequest();
            }

            try
            {
                var city = cityDto.ToModel();
                var result = await _cityService.UpdateCityAsync(id, city);
                if (result == null)
                {
                    return NotFound();
                }
                return Ok(result.ToDto());
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        // DELETE: api/laboratoryModule/cities/{id}
        [HttpDelete("cities/{id}")]
        public async Task<ActionResult> DeleteCity(int id)
        {
            var result = await _cityService.GetCityByIdAsync(id);
            if (result == null)
            {
                return NotFound();
            }
            await _cityService.DeleteCityAsync(id);
            return NoContent();
        }

        // GET: api/laboratoryModule/laboratories
        [HttpGet("laboratories")]
        public async Task<ActionResult<IEnumerable<LaboratoryDto>>> GetAllLaboratories()
        {
            var result = await _laboratoryService.GetAllLaboratoriesAsync();
            return Ok(result.Select(l => l.ToDto()));
        }

        // GET: api/laboratoryModule/laboratories/{id}
        [HttpGet("laboratories/{id}")]
        public async Task<ActionResult<LaboratoryDto>> GetLaboratory(int id)
        {
            var result = await _laboratoryService.GetLaboratoryByIdAsync(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result.ToDto());
        }

        // GET: api/laboratoryModule/laboratories/{city}
        [HttpGet("laboratories/city/{id}")]
        public async Task<ActionResult<IEnumerable<LaboratoryDto>>> GetLaboratoriesByCity(int id)
        {
            var result = await _laboratoryService.GetLaboratoriesByCityAsync(id);
            return Ok(result.Select(l => l.ToDto()));
        }

        // POST: api/laboratoryModule/laboratories
        [HttpPost("laboratories")]
        public async Task<ActionResult<LaboratoryDto>> AddLaboratory(LaboratoryDto laboratoryDto)
        {
            try
            {
                var laboratory = laboratoryDto.ToModel();
                var result = await _laboratoryService.AddLaboratoryAsync(laboratory);
                return CreatedAtAction(nameof(GetLaboratory), new { id = result.LaboratoryId }, result.ToDto());
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        // PUT: api/laboratoryModule/laboratories/{id}
        [HttpPut("laboratories/{id}")]
        public async Task<ActionResult<LaboratoryDto>> UpdateLaboratory(int id, [FromBody] LaboratoryDto laboratoryDto)
        {
            if (id != laboratoryDto.LaboratoryId)
            {
                return BadRequest();
            }

            try
            {
                var laboratory = laboratoryDto.ToModel();
                var result = await _laboratoryService.UpdateLaboratoryAsync(id, laboratory);
                if (result == null)
                {
                    return NotFound();
                }
                return Ok(result.ToDto());
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        // DELETE: api/laboratoryModule/laboratories/{id}
        [HttpDelete("laboratories/{id}")]
        public async Task<ActionResult> DeleteLaboratory(int id)
        {
            var result = await _laboratoryService.GetLaboratoryByIdAsync(id);
            if (result == null)
            {
                return NotFound();
            }
            await _laboratoryService.DeleteLaboratoryAsync(id);
            return NoContent();
        }

        // GET: api/laboratoryModule/schedules
        [HttpGet("schedules")]
        public async Task<ActionResult<IEnumerable<ScheduleDto>>> GetAllSchedules()
        {
            var result = await _scheduleService.GetAllSchedulesAsync();
            return Ok(result.Select(s => s.ToDto()));
        }

        // GET: api/laboratoryModule/schedules/{id}
        [HttpGet("schedules/{id}")]
        public async Task<ActionResult<ScheduleDto>> GetSchedule(int id)
        {
            var result = await _scheduleService.GetScheduleByIdAsync(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result.ToDto());
        }

        // POST: api/laboratoryModule/schedules
        [HttpPost("schedules")]
        public async Task<ActionResult<ScheduleDto>> AddSchedule(ScheduleDto scheduleDto)
        {
            try
            {
                var schedule = scheduleDto.ToModel();
                var result = await _scheduleService.AddScheduleAsync(schedule);
                return CreatedAtAction(nameof(GetSchedule), new { id = result.ScheduleId }, result.ToDto());
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        // PUT: api/laboratoryModule/schedules/{id}
        [HttpPut("schedules/{id}")]
        public async Task<ActionResult<ScheduleDto>> UpdateSchedule(int id, [FromBody] ScheduleDto scheduleDto)
        {
            if (id != scheduleDto.ScheduleId)
            {
                return BadRequest();
            }

            try
            {
                var schedule = scheduleDto.ToModel();
                var result = await _scheduleService.UpdateScheduleAsync(id, schedule);
                if (result == null)
                {
                    return NotFound();
                }
                return Ok(result.ToDto());
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        // GET: api/laboratoryModule/days
        [HttpGet("days")]
        public async Task<ActionResult<IEnumerable<DayDto>>> GetAllDays()
        {
            var result = await _dayService.GetAllDaysAsync();
            return Ok(result.Select(d => d.ToDto()));
        }

        // GET: api/laboratoryModule/days/{id}
        [HttpGet("days/{id}")]
        public async Task<ActionResult<DayDto>> GetDay(int id)
        {
            var result = await _dayService.GetDayByIdAsync(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result.ToDto());
        }

        // GET: api/laboratoryModule/employees
        [HttpGet("employees")]
        public async Task<ActionResult<IEnumerable<EmployeeDto>>> GetAllEmployees()
        {
            var result = await _employeeService.GetAllEmployeesAsync();
            return Ok(result.Select(e => e.ToDto()));
        }

        // GET: api/laboratoryModule/employees/{id}
        [HttpGet("employees/{id}")]
        public async Task<ActionResult<EmployeeDto>> GetEmployee(int id)
        {
            var result = await _employeeService.GetEmployeeByIdAsync(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result.ToDto());
        }

        // GET: api/laboratoryModule/employees/{laboratory}
        [HttpGet("employees/{laboratory}")]
        public async Task<ActionResult<IEnumerable<EmployeeDto>>> GetEmployeesByLaboratory(LaboratoryDto laboratory)
        {
            var result = await _employeeService.GetEmployeesByLaboratoryAsync(laboratory.ToModel());
            return Ok(result.Select(e => e.ToDto()));
        }

        // POST: api/laboratoryModule/employees
        [HttpPost("employees")]
        public async Task<ActionResult<EmployeeDto>> AddEmployee(EmployeeDto employeeDto)
        {
            try
            {
                var employee = employeeDto.ToModel();
                var result = await _employeeService.AddEmployeeAsync(employee);
                return CreatedAtAction(nameof(GetEmployee), new { id = result.EmployeeId }, result.ToDto());
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        // PUT: api/laboratoryModule/employees/{id}
        [HttpPut("employees/{id}")]
        public async Task<ActionResult<EmployeeDto>> UpdateEmployee(int id, [FromBody] EmployeeDto employeeDto)
        {
            if (id != employeeDto.EmployeeId)
            {
                return BadRequest();
            }

            try
            {
                var employee = employeeDto.ToModel();
                var result = await _employeeService.UpdateEmployeeAsync(id, employee);
                if (result == null)
                {
                    return NotFound();
                }
                return Ok(result.ToDto());
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        // DELETE: api/laboratoryModule/employees/{id}
        [HttpDelete("employees/{id}")]
        public async Task<ActionResult> DeleteEmployee(int id)
        {
            var result = await _employeeService.GetEmployeeByIdAsync(id);
            if (result == null)
            {
                return NotFound();
            }
            await _employeeService.DeleteEmployeeAsync(id);
            return NoContent();
        }

        // GET: api/laboratoryModule/positions
        [HttpGet("positions")]
        public async Task<ActionResult<IEnumerable<PositionDto>>> GetAllPositions()
        {
            var result = await _positionService.GetAllPositionsAsync();
            return Ok(result.Select(p => p.ToDto()));
        }

        // GET: api/laboratoryModule/positions/{id}
        [HttpGet("positions/{id}")]
        public async Task<ActionResult<PositionDto>> GetPosition(int id)
        {
            var result = await _positionService.GetPositionByIdAsync(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result.ToDto());
        }

        // POST: api/laboratoryModule/positions
        [HttpPost("positions")]
        public async Task<ActionResult<PositionDto>> AddPosition(PositionDto positionDto)
        {
            try
            {
                var position = positionDto.ToModel();
                var result = await _positionService.AddPositionAsync(position);
                return CreatedAtAction(nameof(GetPosition), new { id = result.PositionId }, result.ToDto());
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        // PUT: api/laboratoryModule/positions/{id}
        [HttpPut("positions/{id}")]
        public async Task<ActionResult<PositionDto>> UpdatePosition(int id, [FromBody] PositionDto positionDto)
        {
            if (id != positionDto.PositionId)
            {
                return BadRequest();
            }

            try
            {
                var position = positionDto.ToModel();
                var result = await _positionService.UpdatePositionAsync(id, position);
                if (result == null)
                {
                    return NotFound();
                }
                return Ok(result.ToDto());
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        // DELETE: api/laboratoryModule/positions/{id}
        [HttpDelete("positions/{id}")]
        public async Task<ActionResult> DeletePosition(int id)
        {
            var result = await _positionService.GetPositionByIdAsync(id);
            if (result == null)
            {
                return NotFound();
            }
            await _positionService.DeletePositionAsync(id);
            return NoContent();
        }
    }
}