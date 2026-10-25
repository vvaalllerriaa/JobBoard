namespace JobBoard.BLL.DTOs
{
    public class VacancyDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Requirements { get; set; } = string.Empty;
        public decimal Salary { get; set; }
        public bool IsActive { get; set; }
        public int EmployerId { get; set; }
    }
}