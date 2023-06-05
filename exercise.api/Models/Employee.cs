﻿using System.ComponentModel.DataAnnotations.Schema;

namespace exercise.api.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string JobName { get; set; }
        public string SalaryGrade { get; set; }

        [ForeignKey("Department")]
        public int DepartmentId { get; set; }

    }
}
