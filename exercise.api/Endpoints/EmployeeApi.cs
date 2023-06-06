using exercise.api.Models;
using exercise.api.Repository;

namespace exercise.api.Endpoints
{
    public static class EmployeeApi
    {
        public static void ConfigureEmployeeApi(this WebApplication app)
        {
            app.MapGet("/employees", GetEmployees);
            app.MapGet("/employees/{id}", GetEmployee);
            app.MapPost("/employees", AddEmployee);
            app.MapPut("/employees", UpdateEmployee);
            app.MapDelete("/employees/{id}", DeleteEmployee);

        }

        public static async Task<IResult> GetEmployees(iEmployeeRepo repository)
        {
            try
            {
                var employees = repository.GetEmployees();
                return employees != null ? Results.Ok(employees) : Results.Problem("There are no emplooyes yet");
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }

        public static async Task<IResult> DeleteEmployee(iEmployeeRepo repository, int id)
        {
            try
            {
                var employee = repository.DeleteEmployee(id);
                return employee != null ? Results.Ok(employee) : Results.Problem($"There is no employee with id of {id}");
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }

        public static async Task<IResult> GetEmployee(iEmployeeRepo repository, int id)
        {
            try
            {
                var employee = repository.GetEmployee(id);
                return employee != null ? Results.Ok(employee) : Results.Problem($"There is no employee with id of {id}");
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }

        public static async Task<IResult> AddEmployee(iEmployeeRepo repository, Employee employee)
        {
            try
            {
                var item = repository.AddEmployee(employee);
                return item != null ? Results.Created("https://localhost:7174/employees", employee) : Results.Problem("There is no employee to be added");
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }

        public static async Task<IResult> UpdateEmployee(iEmployeeRepo repository, Employee employee)
        {
            try
            {
                var item = repository.UpdateEmployee(employee);
                return item != null ? Results.Ok(item) : Results.Problem($"There is no employee with id of {employee.Id}");
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }
    }
}
