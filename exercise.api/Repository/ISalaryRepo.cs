using exercise.api.Models;

namespace exercise.api.Repository
{
    public interface ISalaryRepo
    {
        IEnumerable<Salary> GetAllSalaryGrades();
        Salary GetSalary(int id);
        bool AddSalary(Salary salary);
        bool UpdateSalary(Salary salary);
        bool DeleteSalary(int id);
    }
}
