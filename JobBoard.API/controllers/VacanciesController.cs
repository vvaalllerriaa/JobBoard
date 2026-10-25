using Microsoft.AspNetCore.Mvc;
using JobBoard.BLL.DTOs;
using JobBoard.BLL.Services;
using JobBoard.BLL.Exceptions;

namespace JobBoard.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VacanciesController : ControllerBase
    {
        private readonly IVacancyService _vacancyService;

        public VacanciesController(IVacancyService vacancyService)
        {
            _vacancyService = vacancyService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<VacancyDto>>> GetAll()
        {
            var vacancies = await _vacancyService.GetAllVacanciesAsync();
            return Ok(vacancies);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<VacancyDto>> GetById(int id)
        {
            try
            {
                var vacancy = await _vacancyService.GetVacancyByIdAsync(id);
                return Ok(vacancy);
            }
            catch (NotFoundException ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] VacancyDto vacancyDto)
        {
            await _vacancyService.CreateVacancyAsync(vacancyDto);
            return Ok(new { message = "Вакансію успішно створено!" });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] VacancyDto vacancyDto)
        {
            if (id != vacancyDto.Id)
                return BadRequest(new { message = "ID в URL не збігається з ID в тілі запиту." });

            try
            {
                await _vacancyService.UpdateVacancyAsync(vacancyDto);
                return Ok(new { message = "Вакансію оновлено!" });
            }
            catch (NotFoundException ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _vacancyService.DeleteVacancyAsync(id);
                return Ok(new { message = "Вакансію видалено!" });
            }
            catch (NotFoundException ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }
    }
}