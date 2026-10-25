using JobBoard.DAL.Entities;

namespace JobBoard.DAL.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<User> Users { get; }
        IRepository<Resume> Resumes { get; }
        IRepository<Vacancy> Vacancies { get; }
        IRepository<JobApplication> JobApplications { get; }
        Task<int> SaveAsync();
    }
}