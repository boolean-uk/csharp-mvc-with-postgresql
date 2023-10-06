using System.ComponentModel.DataAnnotations;

namespace exercise.api.DTOs
{
    public class EmployeeInputDTO
    {
        //added random requirements that are not in api spec
        [Required(ErrorMessage = "Name is required.")]
        [StringLength(100, ErrorMessage = "Name can't be longer than 100 characters.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Job name is required.")]
        [StringLength(100, ErrorMessage = "Job name can't be longer than 100 characters.")]
        public string JobName { get; set; }

        [Required(ErrorMessage = "Salary grade is required.")]
        public int SalaryGradeId { get; set; }

        [Required(ErrorMessage = "Department is required.")]
        public int DepartmentId { get; set; }
    }
}
