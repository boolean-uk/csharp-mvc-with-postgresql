using exercise.api.DataContext;
using exercise.api.Models;

namespace exercise.api.Repository
{
    public class DepartRepo : IDepartRepo
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
                var target = db.Departments.FirstOrDefault(s => s.Id == id);
                if (target != null)
                {
                    db.Remove(target);
                    db.SaveChanges();
                    return true;
                };
                return false;
            }
        }

        public IEnumerable<Department> GetAllDepartments()
        {
            using (var db = new EmployeeContext())
            {
                return db.Departments.ToList();
            }
            return null;
        }

        public Department GetDepartment(int id)
        {
            Department result;
            using (var db = new EmployeeContext())
            {
                result = db.Departments.FirstOrDefault(s => s.Id == id);
            };
            return result;
        }

        public bool UpdateDepartment(Department department)
        {
            using (var db = new EmployeeContext())
            {
                var target = db.Departments.FirstOrDefault(c => c.Id == department.Id);
                if (target != null)
                {
                    db.Departments.Attach(target);
                    target.name = department.name;
                    target.location = department.location;
                    db.SaveChanges();
                    return true;

                }
            }
            return false;
        }
    }
}
