using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace exercise.api.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string JobName { get; set; }

        [ForeignKey("Salary")]
        public int SalaryId { get; set; }

        [ForeignKey("Department")]
        public int DepartmentId { get; set; }
    }
}
