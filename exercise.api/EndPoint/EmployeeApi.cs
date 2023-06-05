using exercise.api.Repository;
using System.Runtime.CompilerServices;


namespace exercise.api.DataContext
{
    public static class EmployeeApi
    {

        public static void ConfigureEmployeeApi(this WebApplication app)
        {
            app.MapGet("/employees", GetEmployees);
        }

        private static async Task<IResult> GetEmployees(IEmployeeRepository repository)
        {
            try
            {
                return Results.Ok(repository.GetEmployees());
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }
    }
}
