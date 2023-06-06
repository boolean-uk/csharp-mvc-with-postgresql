using exercise.api.Models;
using exercise.api.Repository;

namespace exercise.api.Endpoint

{
    public static class EmployeeApi
    {
        //defines the endpoint
        public static void ConfigureEmployeeApi(this WebApplication app)
        {
            app.MapGet("/Employees", GetEmployees);
            app.MapGet("/Employees/{id}", GetEmployee);
            app.MapPost("/Employees", CreateEmployee);
            app.MapPut("/Employees/{id}", UpdateEmployee);
            app.MapDelete("/Employees/{id}", DeleteEmployee);
        }

        private static async Task<IResult> DeleteEmployee(int id, IEmployeeRepo repo)
        {
            try
            {
                var result = repo.DeleteEmployee(id);
                return result != null ? Results.Ok(result) : Results.NotFound($"Employee with id {id} not found");

            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }

        private static async Task<IResult> GetEmployee(IEmployeeRepo repo, int id)
        {
            try
            {
                var result = repo.GetEmployee(id);
                return result != null ? Results.Ok(result) : Results.NotFound($"Employee with id {id} not found");

            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }

        }

        private static async Task<IResult> GetEmployees(IEmployeeRepo repo)
        {
            try
            {
                return Results.Ok(repo.GetAllEmployees());

            }catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }

        private static async Task<IResult> CreateEmployee(IEmployeeRepo repo, Employee empl)
        {
            try
            {
                return Results.Ok(repo.AddEmployee(empl));

            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }

        }
        private static async Task<IResult> UpdateEmployee(int id, IEmployeeRepo repo, Employee empl)
        {
            try
            {
               return repo.UpdateEmployee(empl, id) != null ? Results.Ok(empl) : Results.NotFound($"Employee with id {id} not found");
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }

        }
    }
}
