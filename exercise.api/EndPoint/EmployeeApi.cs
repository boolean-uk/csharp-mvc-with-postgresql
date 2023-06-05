using exercise.api.Model;
using exercise.api.Repository;

namespace exercise.api.EndPoint
{
    public static class EmployeeApi
    {
        public static void ConfigureEmployeeApi(this WebApplication app)
        {
            app.MapPost("/Employees", PostEmployee);
            app.MapGet("/Employees", GetEmployees);
            app.MapGet("/Employees/{id}", GetEmployee);
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
        private static async Task<IResult> GetEmployee(int id, IEmployeeRepository repository)
        {
            {
                try
                {
                    return await Task.Run(() =>
                    {
                        var person = repository.GetAEmployee(id);
                        if (person == null) return Results.NotFound();
                        return Results.Ok(person);
                    });

                }
                catch (Exception ex)
                {
                    return Results.Problem(ex.Message);
                }
            }
        }
    }
}
