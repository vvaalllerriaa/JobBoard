namespace JobBoard.DAL.Entities
{
    public class Vacancy
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Requirements { get; set; } = string.Empty;
        public decimal Salary { get; set; }
        public bool IsActive { get; set; } = true;
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;

        // Зв'язок із роботодавцем
        public int EmployerId { get; set; }
        public User Employer { get; set; } = null!;

        public ICollection<JobApplication> JobApplications { get; set; } = new List<JobApplication>();
    }
}