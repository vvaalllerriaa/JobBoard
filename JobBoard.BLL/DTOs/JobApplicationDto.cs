namespace JobBoard.BLL.DTOs
{
    public class JobApplicationDto
    {
        public int Id { get; set; }
        public int VacancyId { get; set; }
        public int ResumeId { get; set; }
        public string Status { get; set; } = string.Empty;
        public DateTime AppliedDate { get; set; }
    }
}