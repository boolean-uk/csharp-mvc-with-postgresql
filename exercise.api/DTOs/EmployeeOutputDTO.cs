namespace exercise.api.DTOs
{
    public class EmployeeOutputDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string JobName { get; set; }
        public string SalaryGrade { get; set; }
        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }
    }
}
