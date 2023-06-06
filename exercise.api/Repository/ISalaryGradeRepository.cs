using exercise.api.Models;

namespace exercise.api.Repository
{
    public interface ISalaryGradeRepository
    {
        IEnumerable<SalaryGrade> GetSalaryGrades();
        SalaryGrade GetSalaryGrade(int id);
        bool AddSalaryGrade(SalaryGrade salarygrade);
        bool UpdateSalaryGrade(SalaryGrade salarygrade);
        bool DeleteSalaryGrade(int id);
    }
}
