using System.ComponentModel.DataAnnotations;
using exercise.api.Models;

namespace exercise.tests
{
    [TestFixture]
    public class Tests
    {
        [Test]
        public void Initializing_Employee_Model()
        {
            var employee = new Employee
            {
                Name = "John Doe",
                JobName = "Software Engineer",
                SalaryId = 1,
                DepartmentId = 1
            };

            Assert.AreEqual("John Doe", employee.Name);
            Assert.AreEqual("Software Engineer", employee.JobName);
            Assert.AreEqual(1, employee.SalaryId);
            Assert.AreEqual(1, employee.DepartmentId);
        }

        [Test]
        public void Initializing_Department_Model()
        {
            var department = new Department
            {
                Name = "IT",
                Location = "New York"
            };

            Assert.AreEqual("IT", department.Name);
            Assert.AreEqual("New York", department.Location);
        }

        [Test]
        public void Initializing_Salary_Model()
        {
            var salary = new Salary
            {
                Grade = "7",
                MinSalary = 50000,
                MaxSalary = 90000
            };

            Assert.AreEqual("7", salary.Grade);
            Assert.AreEqual(50000, salary.MinSalary);
            Assert.AreEqual(90000, salary.MaxSalary);
        }

        [Test]
        public void Employee_Salary_Relationship()
        {
            var salary = new Salary { Id = 1 };
            var employee = new Employee { SalaryId = salary.Id };

            Assert.AreEqual(salary.Id, employee.SalaryId);
        }

        [Test]
        public void Employee_Department_Relationship()
        {
            var department = new Department { Id = 1 };
            var employee = new Employee { DepartmentId = department.Id };

            Assert.AreEqual(department.Id, employee.DepartmentId);
        }

        [Test]
        public void Salary_Employees_Relationship()
        {
            var salary = new Salary { Id = 1 };
            var employee1 = new Employee { SalaryId = salary.Id };
            var employee2 = new Employee { SalaryId = salary.Id };

            salary.Employees.Add(employee1);
            salary.Employees.Add(employee2);

            Assert.IsTrue(salary.Employees.Contains(employee1));
            Assert.IsTrue(salary.Employees.Contains(employee2));
        }

        [Test]
        public void Department_Employees_Relationship()
        {
            var department = new Department { Id = 1 };
            var employee1 = new Employee { DepartmentId = department.Id };
            var employee2 = new Employee { DepartmentId = department.Id };

            department.Employees.Add(employee1);
            department.Employees.Add(employee2);

            Assert.IsTrue(department.Employees.Contains(employee1));
            Assert.IsTrue(department.Employees.Contains(employee2));
        }
    }
}
