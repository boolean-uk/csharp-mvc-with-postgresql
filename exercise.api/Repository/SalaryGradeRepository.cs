using exercise.api.DataContext;
using exercise.api.Models;

namespace exercise.api.Repository
{
    public class SalaryGradeRepository : ISalaryGradeRepository
    {
        public bool AddSalaryGrade(SalaryGrade salarygrade)
        {
            using (var db = new EmployeeContext())
            {
                db.SalaryGrades.Add(salarygrade);
                db.SaveChanges();
                return true;
            }
            return false;
        }

        public bool DeleteSalaryGrade(int id)
        {
            using (var db = new EmployeeContext())
            {
                db.Remove(db.SalaryGrades.Find(id));
                db.SaveChanges();
                return true;
            };
            return false;
        }

        public SalaryGrade GetSalaryGrade(int id)
        {
            SalaryGrade result;
            using (var db = new EmployeeContext())
            {
                result = db.SalaryGrades.Find(id);
                db.SaveChanges();
                return result;
            };
            return result;
        }

        public IEnumerable<SalaryGrade> GetSalaryGrades()
        {
            using (var db = new EmployeeContext())
            {
                return db.SalaryGrades.ToList();
            }
            return null;
        }

        public bool UpdateSalaryGrade(SalaryGrade salarygrade)
        {
            using (var db = new EmployeeContext())
            {
                db.Update(salarygrade);
                db.SaveChanges();
                return true;
            };
            return false;
        }
    }
}
