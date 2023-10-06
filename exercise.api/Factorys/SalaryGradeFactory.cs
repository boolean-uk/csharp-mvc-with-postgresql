using exercise.api.DTOs;
using exercise.api.Models;

namespace exercise.api.Factorys
{
    public class SalaryGradeFactory : Factory<SalaryGrade, SalaryGradeInputDTO, SalaryGradeOutputDTO>
    {
        public override SalaryGrade FromDTO(SalaryGradeInputDTO inputDTO)
        {
            return new SalaryGrade
            {
                Grade = inputDTO.Grade,
                MinSalary = inputDTO.MinSalary,
                MaxSalary = inputDTO.MaxSalary
            };
        }

        public override SalaryGradeOutputDTO ToDTO(SalaryGrade salaryGrade)
        {
            return new SalaryGradeOutputDTO
            {
                Id = salaryGrade.Id,
                Grade = salaryGrade.Grade,
                MinSalary = salaryGrade.MinSalary,
                MaxSalary = salaryGrade.MaxSalary
            };
        }

        public override void UpdateFromDTO(SalaryGrade existingSalaryGrade, SalaryGradeInputDTO inputDTO)
        {
            existingSalaryGrade.Grade = inputDTO.Grade;
            existingSalaryGrade.MinSalary = inputDTO.MinSalary;
            existingSalaryGrade.MaxSalary = inputDTO.MaxSalary;
        }
    }
}