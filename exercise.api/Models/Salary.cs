using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace exercise.api.Models
{
    public class Salary
    {
        public int Id { get; set; }
        public string Grade { get; set; }
        public int MinSalary { get; set; }
        public int MaxSalary { get; set; }

        public List<Employee> Employees { get; set; } = new List<Employee>();
    }
}