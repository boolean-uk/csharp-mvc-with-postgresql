namespace exercise.api.DTOs
{
    public class DepartmentOutputDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public List<string> EmployeeNames { get; set; } = new List<string>();
    }
}
