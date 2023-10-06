using System.ComponentModel.DataAnnotations.Schema;

namespace exercise.api.Models
{
    public class Employee
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public string JobName { get; set; }

        // adding fk to salarygrade
        [ForeignKey("SalaryGrade")]
        public int SalaryGradeId { get; set; }
        // navigation
        public SalaryGrade SalaryGrade { get; set; }

        // adding fk for department
        [ForeignKey("Department")]
        public int DepartmentId { get; set; }
        // navigation
        public Department Department { get; set; }
    }
}
