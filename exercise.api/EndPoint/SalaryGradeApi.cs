using exercise.api.Models;
using exercise.api.Repository;

namespace exercise.api.EndPoint
{
    public static class SalaryGradeApi
    {

        public static void ConfigureSalaryGradeApi(this WebApplication app)
        {
            app.MapGet("/salarygrade", GetSalaryGrades);
            app.MapGet("/salarygrade/{id}", GetSalaryGrade);
            app.MapPost("/salarygrade", AddSalaryGrade);
            app.MapPut("/salarygrade", UpdateSalaryGrade);
            app.MapDelete("/salarygrade", DeleteSalaryGrade);
        }
        private static async Task<IResult> GetSalaryGrades(ISalaryGradeRepository service)
        {
            try
            {
                return await Task.Run(() => {
                    return Results.Ok(service.GetSalaryGrades());
                });
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }
        private static async Task<IResult> GetSalaryGrade(int id, ISalaryGradeRepository service)
        {
            try
            {
                return await Task.Run(() =>
                {
                    var person = service.GetSalaryGrade(id);
                    if (person == null) return Results.NotFound();
                    return Results.Ok(person);
                });

            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }
        private static async Task<IResult> AddSalaryGrade(SalaryGrade salarygrade, ISalaryGradeRepository service)
        {
            try
            {
                if (service.AddSalaryGrade(salarygrade)) return Results.Ok();
                return Results.NotFound();

            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }
        private static async Task<IResult> UpdateSalaryGrade(SalaryGrade salarygrade, ISalaryGradeRepository service)
        {
            try
            {
                return await Task.Run(() =>
                {
                    if (service.UpdateSalaryGrade(salarygrade)) return Results.Ok();
                    return Results.NotFound();
                });

            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }
        private static async Task<IResult> DeleteSalaryGrade(int id, ISalaryGradeRepository service)
        {
            try
            {
                if (service.DeleteSalaryGrade(id)) return Results.Ok();
                return Results.NotFound();

            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }
    }
}
