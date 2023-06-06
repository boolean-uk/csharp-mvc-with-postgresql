using exercise.api.Endpoint;
using exercise.api.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
//adds the scope for the IEmployeeRepo so we can use EmployRepo
builder.Services.AddScoped<IEmployeeRepo, EmployeeRepo>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.ConfigureEmployeeApi();

app.UseAuthorization();

app.MapControllers();

app.Run();
