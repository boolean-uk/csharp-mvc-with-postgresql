using exercise.api.Data;
using exercise.api.DTOs;
using exercise.api.Factorys;
using exercise.api.Models;
using exercise.api.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var configuration = builder.Configuration;

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "avadakedavr0.api",
        Version = "v1"
    });
});
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IRepository<Employee>, EmployeeRepository>();
builder.Services.AddScoped<IRepository<Department>, DepartmentRepository>();
builder.Services.AddScoped<IRepository<SalaryGrade>, SalaryGradeRepository>();

builder.Services.AddTransient<IFactory<Department, DepartmentDTO, DepartmentOutputDTO>, DepartmentFactory>();
builder.Services.AddTransient<IFactory<Employee, EmployeeInputDTO, EmployeeOutputDTO>, EmployeeFactory>();
builder.Services.AddTransient<IFactory<SalaryGrade, SalaryGradeInputDTO, SalaryGradeOutputDTO>, SalaryGradeFactory>();

var app = builder.Build();

// seeding the database
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    try
    {
        var context = services.GetRequiredService<AppDbContext>();
        var seeder = new Seeder(context);
        seeder.SeedData();
    }
    catch (Exception ex)
    {
        // logging any errors 
        var logger = services.GetRequiredService<ILogger<Program>>();
        logger.LogError(ex, "An error occurred while seeding the database.");
    }
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "avadakedavr0.api v1");
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
