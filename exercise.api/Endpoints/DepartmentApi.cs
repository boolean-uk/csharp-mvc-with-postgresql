using exercise.api.Models;
using exercise.api.Repository;

namespace exercise.api.Endpoints
{
   public static class DepartmentApi
    {
        public static void ConfigureDepartmentApi(this WebApplication app)
        {
            app.MapGet("/departments", GetDepartments);
            app.MapGet("/departments/{id}", GetDepartment);
            app.MapPost("/departments", AddDepartment);
            app.MapPut("/departments", UpdateDepartment);
            app.MapDelete("/departments/{id}", DeleteDepartment);
        }

        public static async Task<IResult> GetDepartments(iEmployeeRepo repository)
        {
            try
            {
                var departments = repository.GetDepartments();
                return departments != null ? Results.Ok(departments) : Results.Problem("There are no departments yet");
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }

        public static async Task<IResult> DeleteDepartment(iEmployeeRepo repository, int id)
        {
            try
            {
                var department = repository.DeleteDepartment(id);
                return department != null ? Results.Ok(department) : Results.Problem($"There is no department with id of {id}");
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }

        public static async Task<IResult> GetDepartment(iEmployeeRepo repository, int id)
        {
            try
            {
                var department = repository.GetDepartment(id);
                return department != null ? Results.Ok(department) : Results.Problem($"There is no department with id of {id}");
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }

        public static async Task<IResult> AddDepartment(iEmployeeRepo repository, Department department)
        {
            try
            {
                var item = repository.AddDepartment(department);
                return item != null ? Results.Created("https://localhost:7174/departments", department) : Results.Problem("There is no department to be added");
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }

        public static async Task<IResult> UpdateDepartment(iEmployeeRepo repository, Department department)
        {
            try
            {
                var item = repository.UpdateDepartment(department);
                return item != null ? Results.Ok(item) : Results.Problem($"There is no salary with id of {department.Id}");
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }
    }
}
