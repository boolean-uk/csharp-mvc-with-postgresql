namespace exercise.api.Models
{
    public class Department : IEntityWithId
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        // navigation
        public ICollection<Employee> Employees { get; set; }
    }
}
