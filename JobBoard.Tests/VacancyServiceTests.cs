using Xunit;
using Moq;
using JobBoard.BLL.Services;
using JobBoard.BLL.Exceptions;
using JobBoard.DAL.Repositories;
using JobBoard.DAL.Entities;

namespace JobBoard.Tests
{
    public class VacancyServiceTests
    {
        [Fact]
        public async Task GetVacancyByIdAsync_WithValidId_ReturnsVacancyDto()
        {
            var mockUnitOfWork = new Mock<IUnitOfWork>();
            var mockVacancyRepo = new Mock<IRepository<Vacancy>>();

            var testVacancy = new Vacancy
            {
                Id = 1,
                Title = "C# Developer",
                Description = "Test description",
                Requirements = "EF Core, SQL",
                Salary = 2000,
                IsActive = true,
                EmployerId = 1
            };

            mockVacancyRepo.Setup(r => r.GetByIdAsync(1)).ReturnsAsync(testVacancy);
            mockUnitOfWork.Setup(u => u.Vacancies).Returns(mockVacancyRepo.Object);

            var service = new VacancyService(mockUnitOfWork.Object);

            var result = await service.GetVacancyByIdAsync(1);

            Assert.NotNull(result);
            Assert.Equal(1, result.Id);
            Assert.Equal("C# Developer", result.Title);
        }

        [Fact]
        public async Task GetVacancyByIdAsync_WithInvalidId_ThrowsNotFoundException()
        {
            var mockUnitOfWork = new Mock<IUnitOfWork>();
            var mockVacancyRepo = new Mock<IRepository<Vacancy>>();

            mockVacancyRepo.Setup(r => r.GetByIdAsync(99)).ReturnsAsync((Vacancy?)null);
            mockUnitOfWork.Setup(u => u.Vacancies).Returns(mockVacancyRepo.Object);

            var service = new VacancyService(mockUnitOfWork.Object);

            await Assert.ThrowsAsync<NotFoundException>(() => service.GetVacancyByIdAsync(99));
        }
    }
}