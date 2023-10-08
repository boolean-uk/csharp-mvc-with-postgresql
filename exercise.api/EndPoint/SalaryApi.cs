using exercise.api.Models;
using exercise.api.Repository;
using Microsoft.AspNetCore.Mvc;

namespace exercise.api.EndPoint
{
    public static class SalaryApi
    {
        public static void ConfigureSalaryApi(this WebApplication app)
        {
            app.MapGet("/salaries", GetSalaries);
            app.MapGet("/salaries/{id}", GetSalary);
            app.MapPost("/salaries", InsertSalary);
            app.MapPut("/salaries", UpdateSalary);
            app.MapDelete("/salaries", DeleteSalary);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        private static async Task<IResult> GetSalaries(ISalaryRepo service)
        {
            try
            {
                return await Task.Run(() => {
                    return Results.Ok(service.GetAllSalaryGrades());
                });
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        private static async Task<IResult> GetSalary(int id, ISalaryRepo service)
        {
            try
            {
                return await Task.Run(() =>
                {
                    var person = service.GetSalary(id);
                    if (person == null) return Results.NotFound();
                    return Results.Ok(person);
                });

            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        private static async Task<IResult> InsertSalary(Salary salary, ISalaryRepo service)
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

        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        private static async Task<IResult> UpdateSalary(Salary salary, ISalaryRepo service)
        {
            try
            {
                return await Task.Run(() =>
                {
                    if (service.UpdateSalary(salary)) return Results.Ok();
                    return Results.NotFound();
                });

            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        private static async Task<IResult> DeleteSalary(int id, ISalaryRepo service)
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
