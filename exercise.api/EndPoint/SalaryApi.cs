using exercise.api.Models;
using exercise.api.Repository;

namespace exercise.api.EndPoint
{
    public static class SalaryApi
    {
        public static void ConfigureSalaryApi(this WebApplication app)
        {
            app.MapGet("/salaries", GetSalaries);
            app.MapGet("/salaries/{id}", GetSalary);
            app.MapPost("/salaries", AddSalary);
            app.MapPut("/salaries", UpdateSalary);
            app.MapDelete("/salaries/{id}", DeleteSalary);
        }

        public static async Task<IResult> GetSalaries(IEmployeeRepository repository)
        {
            try
            {
                var salaries = repository.GetSalaries();
                return salaries != null ? Results.Ok(salaries) : Results.Problem("There are no salaries yet");
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }

        public static async Task<IResult> DeleteSalary(IEmployeeRepository repository, int id)
        {
            try
            {
                var salary = repository.DeleteSalary(id);
                return salary != null ? Results.Ok(salary) : Results.Problem($"There is no salary with id of {id}");
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }

        public static async Task<IResult> GetSalary(IEmployeeRepository repository, int id)
        {
            try
            {
                var salary = repository.GetSalary(id);
                return salary != null ? Results.Ok(salary) : Results.Problem($"There is no salary with id of {id}");
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }

        public static async Task<IResult> AddSalary(IEmployeeRepository repository, Salary salary)
        {
            try
            {
                var item = repository.AddSalary(salary);
                return item != null ? Results.Created("https://localhost:7174/salaries", salary) : Results.Problem("There is no salary to be added");
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }

        public static async Task<IResult> UpdateSalary(IEmployeeRepository repository, Salary salary)
        {
            try
            {
                var item = repository.UpdateSalary(salary);
                return item != null ? Results.Ok(item) : Results.Problem($"There is no salary with id of {salary.Id}");
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }
    }
}
