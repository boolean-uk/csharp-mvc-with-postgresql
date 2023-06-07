using exercise.api.Model;
using exercise.api.Repository;
using Microsoft.AspNetCore.Mvc;

namespace exercise.api.EndPoint
{
    public static class DepartmentApi
    {
        public static void ConfigureDepartmentApi(this WebApplication app)
        {
            app.MapPost("/Department", InsertDepartment);
            app.MapGet("/Departments", GetAllDepartments);
            app.MapGet("/Departments/{id}", GetADepartment);
            app.MapPut("/Departments", UpdatDepartment);
            app.MapDelete("/Departments/{id}", DeleteDepartment);
        }

        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status201Created)]

        private static async Task<IResult> InsertDepartment(Department department, IEmployeeRepository repository)
        {
            try
            {
                if(department.Name == string.Empty || department.Location == string.Empty)
                {
                    return Results.BadRequest("Could not create the new department, please check all required fields are correct.");
                }
                if (repository.AddDepartment(department)) return Results.Created($"https://localhost:7174/Department/{department.Id}", department);
                return Results.NotFound();
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }

        private static async Task<IResult> GetAllDepartments(IEmployeeRepository department)
        {
            try
            {
                return Results.Ok(department.GetDepartments());
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }

        private static async Task<IResult> GetADepartment(int id, IEmployeeRepository repository)
        {
            try
            {
                return await Task.Run(() =>
                {
                    var d = repository.GetADepartment(id);
                    if (d == null) return Results.NotFound();
                    return Results.Ok(d);
                });
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }

        private static async Task<IResult> UpdatDepartment(Department department, IEmployeeRepository repository)
        {
            try
            {
                return await Task.Run(() =>
                {
                    if (repository.UpdateDepartment(department)) return Results.Ok(department);
                    return Results.NotFound();
                });
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }

        private static async Task<IResult> DeleteDepartment(int id, IEmployeeRepository repository)
        {
            try
            {
                if (repository.DeleteDepartment(id)) return Results.Ok();
                return Results.NotFound();
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }

    }
}
