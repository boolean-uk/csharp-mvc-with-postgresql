using System.ComponentModel.DataAnnotations;

namespace exercise.api.Models
{
    public class Salary
    {
        [Required] public int Id { get; set; }

        [Required] public string grade { get; set; }
        [Required] public int minSalary { get; set; }
        [Required] public int maxSalary { get; set; }
    }
}
