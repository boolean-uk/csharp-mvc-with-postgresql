using exercise.api.DataContext;
using exercise.api.Models;

namespace exercise.api.Data
{
    public static class Seeder
    {
        private static readonly List<string> Firstnames = new List<string>()
        {
            "Audrey",
            "Donald",
            "Elvis",
            "Barack",
            "Oprah",
            "Jimi",
            "Mick",
            "Kate",
            "Charles",
            "Kate"
        };

        private static readonly List<string> Lastnames = new List<string>()
        {
            "Hepburn",
            "Trump",
            "Presley",
            "Obama",
            "Winfrey",
            "Hendrix",
            "Jagger",
            "Winslet",
            "Windsor",
            "Middleton"
        };

        private static readonly List<string> JobTitles = new List<string>()
        {
            "Software Engineer",
            "Software Developer",
            "Front-End Developer", 
            "Back-End Developer",
            "CLoud Developer"
        };

        private static readonly List<string> SalaryGrades = new List<string>()
        {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10"
        };

        private static readonly List<string> DepartmentNames = new List<string>()
        {
            "Software Engineering",
            "Software Development",
            "Front-End Development",
            "Back-End Development",
            "Cloud Development"
        };

        private static readonly List<string> DepartmentLocations = new List<string>()
        {
            "New York",
            "Los Angeles",
            "Chicago",
            "San Francisco",
            "Miami",
            "Houston",
            "Boston",
            "Seattle",
            "Dallas",
            "Denver"
        };
        
        private static readonly Random Random = new Random();

        private static string GenerateEmployeeName()
        {
            return $"{Firstnames[Random.Next(Firstnames.Count)]} {Lastnames[Random.Next(Lastnames.Count)]}";
        }

        private static string GenerateEmployeeJobName()
        {
            return $"{JobTitles[Random.Next(JobTitles.Count)]}";
        }

        private static int GenerateRandomSalary()
        {
            return Random.Next(30000, 100000);
        }
        
        public static void Seed(this WebApplication app)
        {
            using (var db = new CompanyContext())
            {
                var employees = new List<Employee>();
                var salaries = new List<Salary>();
                var departments = new List<Department>();

                if (!db.Salaries.Any())
                {
                    for (int x = 1; x <= 17; x++)
                    {
                        Salary salary = new Salary();
                        salary.Id = x;
                        salary.Grade = SalaryGrades[Random.Next(SalaryGrades.Count)];
                        salary.MinSalary = GenerateRandomSalary();
                        salary.MaxSalary = GenerateRandomSalary();

                        salaries.Add(salary);
                    }

                    db.Salaries.AddRange(salaries);
                }

                if (!db.Departments.Any())
                {
                    for (int x = 1; x <= 17; x++)
                    {
                        Department department = new Department();
                        department.Id = x;
                        department.Name = DepartmentNames[Random.Next(DepartmentNames.Count)];
                        department.Location = DepartmentLocations[Random.Next(DepartmentLocations.Count)];

                        departments.Add(department);
                    }

                    db.Departments.AddRange(departments);
                }

                if (!db.Employees.Any())
                {
                    for (int x = 1; x <= 17; x++)
                    {
                        Employee employee = new Employee();
                        employee.Id = x;
                        employee.Name = GenerateEmployeeName();
                        employee.JobName = GenerateEmployeeJobName();
                        employee.SalaryId = salaries[Random.Next(salaries.Count)].Id;
                        employee.DepartmentId = departments[Random.Next(departments.Count)].Id;

                        employees.Add(employee);
                    }

                    db.Employees.AddRange(employees);
                }

                db.SaveChanges();
            }
        }
    }
}