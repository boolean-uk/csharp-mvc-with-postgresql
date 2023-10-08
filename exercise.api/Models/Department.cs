using System.ComponentModel.DataAnnotations;

namespace exercise.api.Models
{
    public class Department
    {
        [Required] public int Id { get; set; }
        [Required] public string name { get; set; }
        [Required] public string location { get; set; }
    }
}
