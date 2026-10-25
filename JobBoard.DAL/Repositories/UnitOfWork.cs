using JobBoard.DAL.Entities;

namespace JobBoard.DAL.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly JobBoardDbContext _context;

        public IRepository<User> Users { get; }
        public IRepository<Resume> Resumes { get; }
        public IRepository<Vacancy> Vacancies { get; }
        public IRepository<JobApplication> JobApplications { get; }

        public UnitOfWork(JobBoardDbContext context)
        {
            _context = context;
            Users = new Repository<User>(_context);
            Resumes = new Repository<Resume>(_context);
            Vacancies = new Repository<Vacancy>(_context);
            JobApplications = new Repository<JobApplication>(_context);
        }

        public async Task<int> SaveAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}