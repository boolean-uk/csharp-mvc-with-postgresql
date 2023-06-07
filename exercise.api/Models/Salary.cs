using Microsoft.EntityFrameworkCore.Metadata;

namespace exercise.api.Models
{
    public class Salary
    {
        public int Id { get; set; }
        public string grade { get; set; }
        public int maxSalary { get; set; }
        public int minSalary { get; set; }
    }
}
