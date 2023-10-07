using exercise.api.Models;
using exercise.api.Repository;
using Microsoft.AspNetCore.Mvc;

namespace exercise.api.EndPoints
{
    public static class DepartmentsApi
    {
        public static void ConfigureDepartmentsApi(this WebApplication app)
        {
            app.MapPost("/departments", AddDepartment);
            app.MapGet("/departments", GetDepartments);
            app.MapGet("/departments/{id}", GetDepartment);
            app.MapPut("/departments/{id}", UpdateDepartment);
            app.MapDelete("/departments/{id}", DeleteDepartment);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        private static async Task<IResult> GetDepartments(ICompanyRepository service)
        {
            try
            {
                return await Task.Run(() =>
                {
                    return Results.Ok(service.GetAllDepartments());
                });
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        private static async Task<IResult> GetDepartment(int id, ICompanyRepository service)
        {
            try
            {
                return await Task.Run(() =>
                {
                    var department = service.GetDepartment(id);
                    if (department == null) return Results.NotFound($"No Department with ID {id} was found!");
                    return Results.Ok(department);
                });
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        private static async Task<IResult> AddDepartment(Department department, ICompanyRepository service)
        {
            try
            {
                if (service.AddDepartment(department))
                {
                    return Results.Created($"/departments/{department.Id}", new
                    {
                        Message = "The Department with ID {department.Id} was added successfully!",
                        Department = department
                    });
                }
                return Results.BadRequest("The Department could not be added. Please check that all required fields are correct!");
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        private static async Task<IResult> UpdateDepartment(Department department, ICompanyRepository service)
        {
            try
            {
                return await Task.Run(() =>
                {
                    if (service.UpdateDepartment(department))
                    {
                        return Results.Ok(new
                        {
                            Message = "The Department with ID {department.Id} was updated successfully!",
                            Department = department
                        });
                    }
                    return Results.NotFound($"No Department with ID {department.Id} was found!");
                });
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        private static async Task<IResult> DeleteDepartment(int id, ICompanyRepository service)
        {
            try
            {
                if (service.DeleteDepartment(id)) return Results.Ok($"The Department with ID {id} was deleted successfully!");
                return Results.NotFound($"No Department with ID {id} was found!");
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }
    }
}
