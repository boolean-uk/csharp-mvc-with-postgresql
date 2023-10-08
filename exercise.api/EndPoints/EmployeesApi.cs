using exercise.api.Models;
using exercise.api.Repository;
using Microsoft.AspNetCore.Mvc;

namespace exercise.api.EndPoints
{
    public static class EmployeesApi
    {
        public static void ConfigureEmployeesApi(this WebApplication app)
        {
            app.MapPost("/employees", AddEmployee);
            app.MapGet("/employees", GetEmployees);
            app.MapGet("/employees/{id}", GetEmployee);
            app.MapPut("/employees/{id}", UpdateEmployee);
            app.MapDelete("/employees/{id}", DeleteEmployee);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        private static async Task<IResult> GetEmployees(ICompanyRepository service)
        {
            try
            {
                return await Task.Run(() =>
                {
                    return Results.Ok(service.GetAllEmployees());
                });
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        private static async Task<IResult> GetEmployee(int id, ICompanyRepository service)
        {
            try
            {
                return await Task.Run(() =>
                {
                    var employee = service.GetEmployee(id);
                    if (employee == null) return Results.NotFound($"No Employee with ID {id} was found!");
                    return Results.Ok(employee);
                });
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        private static async Task<IResult> AddEmployee(Employee employee, ICompanyRepository service)
        {
            try
            {
                if (service.AddEmployee(employee))
                {
                    return Results.Created($"/employees/{employee.Id}", new
                    {
                        Message = "The Employee with ID {employee.Id} was added successfully!",
                        Employee = employee
                    });
                }
                return Results.BadRequest("The Employee could not be added. Please check that all required fields are correct!");
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        private static async Task<IResult> UpdateEmployee(Employee employee, ICompanyRepository service)
        {
            try
            {
                return await Task.Run(() =>
                {
                    if (service.UpdateEmployee(employee))
                    {
                        return Results.Ok(new
                        {
                            Message = "The Employee with ID {employee.Id} was updated successfully!",
                            Employee = employee
                        });
                    }
                    return Results.NotFound($"No Employee with ID {employee.Id} was found!");
                });
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        private static async Task<IResult> DeleteEmployee(int id, ICompanyRepository service)
        {
            try
            {
                if (service.DeleteEmployee(id)) return Results.Ok($"The Employee with ID {id} was deleted successfully!");
                return Results.NotFound($"No Employee with ID {id} was found!");
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }
    }
}
