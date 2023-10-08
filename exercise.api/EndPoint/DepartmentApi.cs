using exercise.api.Models;
using exercise.api.Repository;
using Microsoft.AspNetCore.Mvc;

namespace exercise.api.EndPoint
{
    public static class DepartmentApi
    {
        public static void ConfigureDepartmentApi(this WebApplication app)
        {
            app.MapGet("/departments", GetDepartments);
            app.MapGet("/departments/{id}", GetDepartment);
            app.MapPost("/departments", InsertDepartment);
            app.MapPut("/departments", UpdateDepartment);
            app.MapDelete("/departments", DeleteDepartment);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        private static async Task<IResult> GetDepartments(IDepartRepo service)
        {
            try
            {
                return await Task.Run(() => {
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
        private static async Task<IResult> GetDepartment(int id, IDepartRepo service)
        {
            try
            {
                return await Task.Run(() =>
                {
                    var person = service.GetDepartment(id);
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
        private static async Task<IResult> InsertDepartment(Department department, IDepartRepo service)
        {
            try
            {
                if (service.AddDepartment(department)) return Results.Ok();
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
        private static async Task<IResult> UpdateDepartment(Department department, IDepartRepo service)
        {
            try
            {
                return await Task.Run(() =>
                {
                    if (service.UpdateDepartment(department)) return Results.Ok();
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
        private static async Task<IResult> DeleteDepartment(int id, IDepartRepo service)
        {
            try
            {
                if (service.DeleteDepartment(id)) return Results.Ok();
                return Results.NotFound();

            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }
    }
}
