using System.ComponentModel.DataAnnotations.Schema;

namespace exercise.api.Models
{
    public class Employee
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public string JobName { get; set; }
        public string SalaryGrade { get; set; }

        //adding fk for department
        [ForeignKey("Department")]
        public int DepartmentId { get; set; }
        // navigation
        public Department Department { get; set; }


    }
}
