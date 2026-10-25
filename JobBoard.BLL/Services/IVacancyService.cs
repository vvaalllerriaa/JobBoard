using JobBoard.BLL.DTOs;

namespace JobBoard.BLL.Services
{
    public interface IVacancyService
    {
        Task<IEnumerable<VacancyDto>> GetAllVacanciesAsync();
        Task<VacancyDto> GetVacancyByIdAsync(int id);
        Task CreateVacancyAsync(VacancyDto vacancyDto);
        Task UpdateVacancyAsync(VacancyDto vacancyDto);
        Task DeleteVacancyAsync(int id);
    }
}