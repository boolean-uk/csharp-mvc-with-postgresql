using exercise.api.Models;
using exercise.api.Repository;

namespace exercise.api.EndPoint
{
    public static class DepartmentApi
    {
        public static void ConfigureDepartmentApi(this WebApplication app)
        {
            app.MapGet("/departments", GetDepartments);
            app.MapGet("/departments/{id}", GetDepartment);
            app.MapPost("/departments", AddDepartment);
            app.MapPut("/departments", UpdateDepartment);
            app.MapDelete("/departments", DeleteDepartment);
        }
        private static async Task<IResult> GetDepartments(IDepartmentRepository service)
        {
            try
            {
                return await Task.Run(() => {
                    return Results.Ok(service.GetDepartments());
                });
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }
        private static async Task<IResult> GetDepartment(int id, IDepartmentRepository service)
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
        private static async Task<IResult> AddDepartment(Department department, IDepartmentRepository service)
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
        private static async Task<IResult> UpdateDepartment(Department department, IDepartmentRepository service)
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
        private static async Task<IResult> DeleteDepartment(int id, IDepartmentRepository service)
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
