using exercise.api.Models;
using exercise.api.Repository;
using Microsoft.AspNetCore.Mvc;

namespace exercise.api.EndPoints
{
    public static class SalariesApi
    {
        public static void ConfigureSalariesApi(this WebApplication app)
        {
            app.MapPost("/salaries", AddSalary);
            app.MapGet("/salaries", GetSalaries);
            app.MapGet("/salaries/{id}", GetSalary);
            app.MapPut("/salaries/{id}", UpdateSalary);
            app.MapDelete("/salaries/{id}", DeleteSalary);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        private static async Task<IResult> GetSalaries(ICompanyRepository service)
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

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        private static async Task<IResult> GetSalary(int id, ICompanyRepository service)
        {
            try
            {
                return await Task.Run(() =>
                {
                    var salary = service.GetSalary(id);
                    if (salary == null) return Results.NotFound($"No Salary with ID {id} was found!");
                    return Results.Ok(salary);
                });
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        private static async Task<IResult> AddSalary(Salary salary, ICompanyRepository service)
        {
            try
            {
                if (service.AddSalary(salary))
                {
                    return Results.Created($"/salaries/{salary.Id}", new
                    {
                        Message = "The Salary with ID {salary.Id} was added successfully!",
                        Salary = salary
                    });
                }
                return Results.BadRequest("The Salary could not be added. Please check that all required fields are correct!");
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        private static async Task<IResult> UpdateSalary(Salary salary, ICompanyRepository service)
        {
            try
            {
                return await Task.Run(() =>
                {
                    if (service.UpdateSalary(salary))
                    {
                        return Results.Ok(new
                        {
                            Message = "The Salary with ID {salary.Id} was updated successfully!",
                            Salary = salary
                        });
                    }
                    return Results.NotFound($"No Salary with ID {salary.Id} was found!");
                });
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        private static async Task<IResult> DeleteSalary(int id, ICompanyRepository service)
        {
            try
            {
                if (service.DeleteSalary(id)) return Results.Ok($"The Salary with ID {id} was deleted successfully!");
                return Results.NotFound($"No Salary with ID {id} was found!");
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }
    }
}
