using exercise.api.Models;
using exercise.api.Repository;

namespace exercise.api.EndPoint
{
    public static class EmployeeApi
    {
        public static void ConfigureEmployeeApi(this WebApplication app) 
        {
            app.MapGet("/employees", GetEmployees);
            app.MapGet("/employees/{id}", GetEmployee);
            app.MapPost("/employees", InsertEmployee);
            app.MapDelete("/employees/{id}", DeleteEmployee);
            app.MapPut("/employees/{id}", UpdateEmployee);

        }

        private static async Task<IResult> UpdateEmployee(IEmployeeRepository repo, int id, Employee employee)
        {
            try
            {
                
                return repo.UpdateEmployee(employee, id) != null ? Results.Ok(employee) : Results.NotFound();
            }

            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }


        private static async Task<IResult> DeleteEmployee(IEmployeeRepository repo, int id)
        {
            try
            {
                var result = repo.DeleteEmployee(id);
                return result != null ? Results.Ok(result) : Results.NotFound();
            }

            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }

        private static async Task<IResult> InsertEmployee(IEmployeeRepository repo, Employee employee)
        {
            try
            {
                return Results.Ok(repo.AddEmployee(employee));
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }

        private static async Task<IResult> GetEmployee(IEmployeeRepository repo, int id)
        {
            try
            {
                var result = repo.GetEmployeeById(id);
                return result != null ? Results.Ok(result) : Results.NotFound();
            }

            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }
    

        private static async Task<IResult> GetEmployees(IEmployeeRepository repo)
        {
            try
            {
                return Results.Ok(repo.GetEmployees());
            }

            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }


    }
}
