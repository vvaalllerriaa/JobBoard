using JobBoard.BLL.DTOs;
using JobBoard.BLL.Exceptions;
using JobBoard.DAL.Entities;
using JobBoard.DAL.Repositories;

namespace JobBoard.BLL.Services
{
    public class VacancyService : IVacancyService
    {
        private readonly IUnitOfWork _uow;

        public VacancyService(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<IEnumerable<VacancyDto>> GetAllVacanciesAsync()
        {
            var vacancies = await _uow.Vacancies.GetAllAsync();
            return vacancies.Select(v => new VacancyDto
            {
                Id = v.Id,
                Title = v.Title,
                Description = v.Description,
                Requirements = v.Requirements,
                Salary = v.Salary,
                IsActive = v.IsActive,
                EmployerId = v.EmployerId
            });
        }

        public async Task<VacancyDto> GetVacancyByIdAsync(int id)
        {
            var vacancy = await _uow.Vacancies.GetByIdAsync(id);
            if (vacancy == null)
                throw new NotFoundException($"Вакансію з ID {id} не знайдено.");

            return new VacancyDto
            {
                Id = vacancy.Id,
                Title = vacancy.Title,
                Description = vacancy.Description,
                Requirements = vacancy.Requirements,
                Salary = vacancy.Salary,
                IsActive = vacancy.IsActive,
                EmployerId = vacancy.EmployerId
            };
        }

        public async Task CreateVacancyAsync(VacancyDto dto)
        {
            var vacancy = new Vacancy
            {
                Title = dto.Title,
                Description = dto.Description,
                Requirements = dto.Requirements,
                Salary = dto.Salary,
                IsActive = true,
                EmployerId = dto.EmployerId
            };

            await _uow.Vacancies.AddAsync(vacancy);
            await _uow.SaveAsync();
        }

        public async Task UpdateVacancyAsync(VacancyDto dto)
        {
            var vacancy = await _uow.Vacancies.GetByIdAsync(dto.Id);
            if (vacancy == null)
                throw new NotFoundException($"Вакансію з ID {dto.Id} не знайдено.");

            vacancy.Title = dto.Title;
            vacancy.Description = dto.Description;
            vacancy.Requirements = dto.Requirements;
            vacancy.Salary = dto.Salary;
            vacancy.IsActive = dto.IsActive;

            _uow.Vacancies.Update(vacancy);
            await _uow.SaveAsync();
        }

        public async Task DeleteVacancyAsync(int id)
        {
            var vacancy = await _uow.Vacancies.GetByIdAsync(id);
            if (vacancy == null)
                throw new NotFoundException($"Вакансію з ID {id} не знайдено.");

            _uow.Vacancies.Remove(vacancy);
            await _uow.SaveAsync();
        }
    }
}