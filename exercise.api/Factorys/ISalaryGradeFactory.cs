using exercise.api.DTOs;
using exercise.api.Models;

namespace exercise.api.Factorys
{
    public interface ISalaryGradeFactory
    {
        SalaryGrade FromDTO(SalaryGradeInputDTO inputDTO);
        void UpdateFromDTO(SalaryGrade existingSalaryGrade, SalaryGradeInputDTO inputDTO);
        SalaryGradeOutputDTO ToDTO(SalaryGrade salaryGrade);
    }
}