namespace JobBoard.DAL.Entities
{
    public class Resume
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;      
        public string Summary { get; set; } = string.Empty;     
        public string Skills { get; set; } = string.Empty;     
        public decimal DesiredSalary { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
        public int UserId { get; set; }
        public User User { get; set; } = null!;

        public ICollection<JobApplication> JobApplications { get; set; } = new List<JobApplication>();
    }
}