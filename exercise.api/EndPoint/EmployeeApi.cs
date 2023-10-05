using exercise.api.Models;
using exercise.api.Repository;

namespace exercise.api.EndPoint
{
    public static class EmployeeApi
    {
        public static void ConfigureEmployeeApi(this WebApplication app)
        {
            app.MapGet("/employees", GetEmployees);
            app.MapGet("/employees/{id}", GetEmployee);
            app.MapPost("/employees", InsertEmployee);
            app.MapPut("/employees", UpdateEmployee);
            app.MapDelete("/employees", DeleteEmployee);
        }
        private static async Task<IResult> GetEmployees(IEmployeeRepository service)
        {
            try
            {
                return await Task.Run(() => {
                    return Results.Ok(service.GetAllEmployees());
                });
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }
        private static async Task<IResult> GetEmployee(int id, IEmployeeRepository service)
        {
            try
            {
                return await Task.Run(() =>
                {
                    var person = service.GetEmployee(id);
                    if (person == null) return Results.NotFound();
                    return Results.Ok(person);
                });

            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }
        private static async Task<IResult> InsertEmployee(Employee employee, IEmployeeRepository service)
        {
            try
            {
                if (service.AddEmployee(employee)) return Results.Ok();
                return Results.NotFound();

            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }
        private static async Task<IResult> UpdateEmployee(Employee employee, IEmployeeRepository service)
        {
            try
            {
                return await Task.Run(() =>
                {
                    if (service.UpdateEmployee(employee)) return Results.Ok();
                    return Results.NotFound();
                });

            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }
        private static async Task<IResult> DeleteEmployee(int id, IEmployeeRepository service)
        {
            try
            {
                if (service.DeleteEmployee(id)) return Results.Ok();
                return Results.NotFound();

            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }

    }
}

