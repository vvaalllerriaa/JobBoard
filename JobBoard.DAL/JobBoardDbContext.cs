using Microsoft.EntityFrameworkCore;
using JobBoard.DAL.Entities;

namespace JobBoard.DAL
{
    public class JobBoardDbContext : DbContext
    {
        public DbSet<User> Users => Set<User>();
        public DbSet<Resume> Resumes => Set<Resume>();
        public DbSet<Vacancy> Vacancies => Set<Vacancy>();
        public DbSet<JobApplication> JobApplications => Set<JobApplication>();

        public JobBoardDbContext(DbContextOptions<JobBoardDbContext> options) : base(options)
        {
        }
    }
}