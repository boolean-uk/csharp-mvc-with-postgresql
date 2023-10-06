using System.ComponentModel.DataAnnotations;

namespace exercise.api.DTOs
{
    public class SalaryGradeInputDTO
    {
        [Required(ErrorMessage = "Grade is required.")]
        public string Grade { get; set; }

        [Required(ErrorMessage = "MinSalary is required.")]
        public int MinSalary { get; set; }

        [Required(ErrorMessage = "MaxSalary is required.")]
        public int MaxSalary { get; set; }
    }
}
