namespace exercise.api.Models
{
    public class SalaryGrade : IEntityWithId
    {
        public int Id { get; set; }
        public string Grade { get; set; }
        public int MinSalary { get; set; }
        public int MaxSalary { get; set; }
        // navigation 
        public ICollection<Employee> Employees { get; set; } = new List<Employee>();
    }
}
