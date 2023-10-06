using exercise.api.Models;

namespace exercise.api.Repository
{
    public interface ISalaryGradeRepository
    {
        Task<IEnumerable<SalaryGrade>> GetAll();
        Task<SalaryGrade> GetById(int id);
        Task Add(SalaryGrade salaryGrade);
        Task Update(SalaryGrade salaryGrade);
        Task Delete(int id);
    }
}
