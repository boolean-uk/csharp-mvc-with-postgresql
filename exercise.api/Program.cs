using exercise.api.EndPoint;
using exercise.api.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
builder.Services.AddScoped<ISalaryGradeRepository, SalaryGradeRepository>();
builder.Services.AddScoped<IDepartmentRepository, DepartmentRepository>();


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//builder.Services.AddDbContext<>

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.ConfigureEmployeeApi();
app.ConfigureSalaryGradeApi();
app.ConfigureDepartmentApi();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
