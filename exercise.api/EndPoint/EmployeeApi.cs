using exercise.api.Models;
using exercise.api.Repository;
using System.Runtime.CompilerServices;


namespace exercise.api.DataContext
{
    public static class EmployeeApi
    {

        public static void ConfigureEmployeeApi(this WebApplication app)
        {
            app.MapGet("/employees", GetEmployees);
            app.MapGet("/employees/{id}", GetEmployee);
            app.MapPost("/employees", InsertEmployee);
            app.MapPut("/employees", UpdateEmployee);
            app.MapDelete("/employees", DeleteEmployee);
        }

        private static async Task<IResult> DeleteEmployee(int id, IEmployeeRepository service)
        {
            try
            {
                if (service.DeleteEmployee(id)) return Results.Ok();
                return Results.NotFound();
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }

        private static async Task<IResult> UpdateEmployee(Employee employee, IEmployeeRepository service)
        {
            try
            {
                return await Task.Run(() =>
                {
                    if (service.UpdateEmployee(employee)) return Results.Ok();
                    return Results.NotFound();
                });
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }

        private static async Task<IResult> InsertEmployee(Employee employee, IEmployeeRepository service)
        {
            try
            {
                if (service.AddEmployee(employee)) return Results.Ok();
                return Results.NotFound();
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }

        private static async Task<IResult> GetEmployee(int id, IEmployeeRepository service)
        {
            try
            {
                return await Task.Run(() =>
                {
                    var employee = service.GetEmployee(id);
                    if (employee == null) return Results.NotFound();
                    return Results.Ok(employee);
                });
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }

        private static async Task<IResult> GetEmployees(IEmployeeRepository repository)
        {
            try
            {
                return Results.Ok(repository.GetEmployees());
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }
    }
}
