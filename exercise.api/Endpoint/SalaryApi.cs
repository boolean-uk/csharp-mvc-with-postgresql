using exercise.api.Models;
using exercise.api.Repository;

namespace exercise.api.Endpoint
{
    public static class SalaryApi
    {

        //defines the endpoint
        public static void ConfigureSalaryApi(this WebApplication app)
        {
            app.MapGet("/Salary", GetSalaries);
            app.MapGet("/Salary/{id}", GetSalary);
            app.MapPost("/Salary", CreateSalary);
            app.MapPut("/Salary/{id}", UpdateSalary);
            app.MapDelete("/Salary/{id}", DeleteSalary);
        }

        private static async Task<IResult> DeleteSalary(int id, IEmployeeRepo repo)
        {
            try
            {
                var result = repo.DeleteSalary(id);
                return result != null ? Results.Ok(result) : Results.NotFound($"Salary with id {id} not found");

            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }

        private static async Task<IResult> GetSalary(IEmployeeRepo repo, int id)
        {
            try
            {
                var result = repo.GetSalary(id);
                return result != null ? Results.Ok(result) : Results.NotFound($"Employee with id {id} not found");

            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }

        }

        private static async Task<IResult> GetSalaries(IEmployeeRepo repo)
        {
            try
            {
                return Results.Ok(repo.GetSalaries());

            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }

        private static async Task<IResult> CreateSalary(IEmployeeRepo repo, Salary sal)
        {
            try
            {
                return Results.Ok(repo.AddSalaryGrade(sal));

            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }

        }
        private static async Task<IResult> UpdateSalary(int id, IEmployeeRepo repo, Salary sal)
        {
            try
            {
                return repo.UpdateSalaryGrade(sal, id) != null ? Results.Ok(sal) : Results.NotFound($"Salary with id {id} not found");
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }

        }
    }
}
