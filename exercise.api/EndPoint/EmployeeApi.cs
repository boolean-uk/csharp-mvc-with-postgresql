using exercise.api.Model;
using exercise.api.Repository;

namespace exercise.api.EndPoint
{
    public static class EmployeeApi
    {
        public static void ConfigureEmployeeApi(this WebApplication app)
        {
            app.MapGet("/Employees", GetEmployees);
            app.MapPost("/Employees", PostEmployee);
        }

        private static async Task<IResult> PostEmployee(Employee employee, IEmployeeRepository repository)
        {
            try
            {
                if (repository.AddEmployee(employee)) return Results.Ok();
                return Results.NotFound();
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }

        private static async Task<IResult> GetEmployees(IEmployeeRepository employee)
        {
            try
            {
                return Results.Ok(employee.GetEmployees());
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }
    }
}
