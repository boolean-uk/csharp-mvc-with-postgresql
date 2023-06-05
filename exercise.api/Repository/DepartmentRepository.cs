using exercise.api.DataContext;
using exercise.api.Models;

namespace exercise.api.Repository
{
    public class DepartmentRepository : IDepartmentRepository
    {
        public bool AddDepartment(Department department)
        {
            using (var db = new EmployeeContext())
            {
                db.Departments.Add(department);
                db.SaveChanges();
                return true;
            }
            return false;
        }

        public bool DeleteDepartment(int id)
        {
            using (var db = new EmployeeContext())
            {
                db.Remove(db.Departments.Find(id));
                db.SaveChanges();
                return true;
            };
            return false;
        }

        public Department GetDepartment(int id)
        {
            Department result;
            using (var db = new EmployeeContext())
            {
                result = db.Departments.Find(id);
                db.SaveChanges();
                return result;
            };
            return result;
        }

        public IEnumerable<Department> GetDepartments()
        {
            using (var db = new EmployeeContext())
            {
                return db.Departments.ToList();
            }
            return null;
        }

        public bool UpdateDepartment(Department department)
        {
            using (var db = new EmployeeContext())
            {
                db.Update(department);
                db.SaveChanges();
                return true;
            };
            return false;
        }
    }
}
