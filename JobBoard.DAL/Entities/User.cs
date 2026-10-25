namespace JobBoard.DAL.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Email { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;
        public string FullName { get; set; } = string.Empty;
        public string Role { get; set; } = string.Empty; 

        public ICollection<Resume> Resumes { get; set; } = new List<Resume>();
        public ICollection<Vacancy> Vacancies { get; set; } = new List<Vacancy>();
    }
}