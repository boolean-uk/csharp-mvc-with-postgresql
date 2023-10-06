using System.ComponentModel.DataAnnotations;

namespace exercise.api.DTOs
{
    public class DepartmentDTO
    {
        [Required(ErrorMessage = "Name is required.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Location is required.")]
        public string Location { get; set; }
    }
}
