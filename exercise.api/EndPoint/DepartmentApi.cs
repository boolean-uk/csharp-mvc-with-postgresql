using exercise.api.Models;
using exercise.api.Repository;

namespace exercise.api.EndPoint
{
    public static class DepartmentApi
    {
        public static void ConfigureDepartmentApi(this WebApplication app)
        {
            app.MapGet("/departments", GetDepartments);
            app.MapGet("departments/{id}", GetDepartment);
            app.MapPost("departments", InsertDepartment);
            app.MapPut("departments", UpdateDepartment);
            app.MapDelete("departments", DeleteDepartment);
            
        }
        private static async Task<IResult> GetDepartments(IEmployeeRepository service)
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
        private static async Task<IResult> GetDepartment(int id, IEmployeeRepository service)
        {
            try
            {
                return await Task.Run(() =>
                {
                    var department = service.GetDepartment(id);
                    if (department == null) return Results.NotFound();
                    return Results.Ok(department);
                });

            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }
        private static async Task<IResult> InsertDepartment(Department department, IEmployeeRepository service)
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
        private static async Task<IResult> UpdateDepartment(Department department, IEmployeeRepository service)
        {
            try
            {
                return await Task.Run(() =>
                {
                    if (service.AddDepartment(department)) return Results.Ok();
                    return Results.NotFound();
                });

            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }
        private static async Task<IResult> DeleteDepartment(int id, IEmployeeRepository service)
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
