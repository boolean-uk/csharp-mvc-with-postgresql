using exercise.api.Model;
using exercise.api.Repository;

namespace exercise.api.EndPoint
{
    public static class SalaryApi
    {
        public static void ConfigureSalaryApi(this WebApplication app)
        {
            app.MapPost("/Salaries", InsertSalary);
            app.MapGet("/Salaries", GetAllSalaries);
            app.MapGet("/Salaries/{id}", GetSalary);
            app.MapPut("/Salaries", UpdateSalary);
            app.MapDelete("Salaries/{id}", DeleteSalary);
        }


        private static async Task<IResult> InsertSalary(Salary salary, IEmployeeRepository repository)
        {
            try
            {
                if (repository.AddSalary(salary)) return Results.Ok(salary);
                return Results.NotFound();
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }
        private static async Task<IResult> GetAllSalaries(IEmployeeRepository salary)
        {
            try
            {
                return Results.Ok(salary.GetSalaries());
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);

            }
        }
        private static async Task<IResult> GetSalary(int id, IEmployeeRepository repository)
        {
            try
            {
                return await Task.Run(() =>
                {
                    var s = repository.GetASalary(id);
                    if (s == null) return Results.NotFound();
                    return Results.Ok(s);
                });
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }
    
        private static async Task<IResult> UpdateSalary(Salary salary, IEmployeeRepository repository)
        {
            try
            {
             return await Task.Run(() =>
                {
                    if (repository.UpdateASalary(salary)) return Results.Ok(salary);
                    return Results.NotFound();
                });
            }
            catch (Exception ex)
            {
             return Results.Problem(ex.Message);
            }
        }

            private static async Task<IResult> DeleteSalary(int id, IEmployeeRepository repository)
            {
                try
                {
                    if (repository.DeleteSalary(id)) return Results.Ok();
                    return Results.NotFound();
                }
                catch (Exception ex)
                {
                    return Results.Problem(ex.Message);
                }
        }
    }
}

