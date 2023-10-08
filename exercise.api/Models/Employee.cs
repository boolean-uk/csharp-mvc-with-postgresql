using System.ComponentModel.DataAnnotations;

namespace exercise.api.Models
{
    public class Employee
    {
        [Required] public int Id { get; set; }

        [Required] public string name { get; set; }
        [Required] public string jobName { get; set; }
        [Required] public string salaryGrade { get; set; }
        [Required] public string department { get; set; }
    }
}
