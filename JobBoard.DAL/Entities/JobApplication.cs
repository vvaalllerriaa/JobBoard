namespace JobBoard.DAL.Entities
{
    public class JobApplication
    {
        public int Id { get; set; }
        public DateTime AppliedDate { get; set; } = DateTime.UtcNow;
        public string Status { get; set; } = "Pending"; 

        public int VacancyId { get; set; }
        public Vacancy Vacancy { get; set; } = null!;

        public int ResumeId { get; set; }
        public Resume Resume { get; set; } = null!;
    }
}