namespace JobBoard.BLL.DTOs
{
    public class ResumeDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Summary { get; set; } = string.Empty;
        public string Skills { get; set; } = string.Empty;
        public decimal DesiredSalary { get; set; }
        public int UserId { get; set; }
    }
}