using exercise.api.Models;
using exercise.api.Repository;
using System.Runtime.CompilerServices;

namespace exercise.api.EndPoint
{
    public static class SalaryApi
    {
        public static void ConfigureSalaryApi(this WebApplication app)
        {
            app.MapGet("/salaries", GetSalaries);
            app.MapGet("/salaries/{id}", GetSalary);
            app.MapPost("/salaries", InsertSalaries);
            app.MapPut("/salaries", UpdateSalaries);
            app.MapDelete("/salaries", DeleteSalaries);
        }
        private static async Task<IResult> GetSalaries(IEmployeeRepository service)
        {
            try
            {
                return await Task.Run(() =>
                {
                    return Results.Ok(service.GetAllSalaries());
                });
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }
        private static async Task<IResult> GetSalary(int id, IEmployeeRepository service)
        {
            try
            {
                return await Task.Run(() =>
                {
                    var salary = service.GetSalary(id);
                    if (salary == null) return Results.NotFound();
                    return Results.Ok(salary);
                });

            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }

        private static async Task<IResult> InsertSalaries(Salary salary, IEmployeeRepository service)
        {
            try
            {
                if (service.AddSalary(salary)) return Results.Ok();
                return Results.NotFound();

            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }
        private static async Task<IResult> UpdateSalaries(Salary salary, IEmployeeRepository service)
        {
            try
            {
                return await Task.Run(() =>
                {
                    if (service.AddSalary(salary)) return Results.Ok();
                    return Results.NotFound();
                });

            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }
        private static async Task<IResult> DeleteSalaries(int id, IEmployeeRepository service)
        {
            try
            {
                if (service.DeleteSalary(id)) return Results.Ok();
                return Results.NotFound();

            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }
    }
}
