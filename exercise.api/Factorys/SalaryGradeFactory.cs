using exercise.api.DTOs;
using exercise.api.Models;

namespace exercise.api.Factorys
{
    public class SalaryGradeFactory : ISalaryGradeFactory
    {
        public SalaryGrade FromDTO(SalaryGradeInputDTO inputDTO)
        {
            return new SalaryGrade
            {
                Grade = inputDTO.Grade,
                MinSalary = inputDTO.MinSalary,
                MaxSalary = inputDTO.MaxSalary
            };
        }

        public void UpdateFromDTO(SalaryGrade existingSalaryGrade, SalaryGradeInputDTO inputDTO)
        {
            existingSalaryGrade.Grade = inputDTO.Grade;
            existingSalaryGrade.MinSalary = inputDTO.MinSalary;
            existingSalaryGrade.MaxSalary = inputDTO.MaxSalary;
        }

        public SalaryGradeOutputDTO ToDTO(SalaryGrade salaryGrade)
        {
            return new SalaryGradeOutputDTO
            {
                Id = salaryGrade.Id,
                Grade = salaryGrade.Grade,
                MinSalary = salaryGrade.MinSalary,
                MaxSalary = salaryGrade.MaxSalary
            };
        }
    }
}