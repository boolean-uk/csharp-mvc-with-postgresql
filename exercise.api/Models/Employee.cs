using Microsoft.EntityFrameworkCore;

namespace exercise.api.Models
{
    public class Employee
    {
        
        public int Id { get; set; }
        public string Name { get; set; }
        public string jobName { get; set; }
        public string salaryGrade { get; set; }
        public string department { get; set; }

    }
}
