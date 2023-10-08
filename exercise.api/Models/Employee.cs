using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace exercise.api.Models
{
    public class Employee
    {
        [Required] public int Id { get; set; }

        [Required] public string name { get; set; }
        [Required] public string jobName { get; set; }

        [ForeignKey("Salary")]
        public int SalaryId { get; set; }
        public Salary Salary { get; set; }

        [ForeignKey("Department")]
        public int DepartmentId { get; set; }
        public Department Department { get; set; }


    }
}
