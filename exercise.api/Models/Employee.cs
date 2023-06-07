using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace exercise.api.Models
{
    public class Employee
    {
        
        public int Id { get; set; }
        public string Name { get; set; }
        public string jobName { get; set; }

        [ForeignKey("Salary")]
        public int salaryId { get; set; }
        public string salaryGrade { get; set; }
        public string department { get; set; }

    }
}
