using exercise.api.Models;
using exercise.api.Repositoy;
using Microsoft.AspNetCore.Mvc;

namespace exercise.api.Controllers
{
    [Route("api/employees")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeRepository _repository;

        public EmployeeController(IEmployeeRepository repository)
        {
            _repository = repository;
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        [HttpPost]
        public async Task<IResult> CreateEmployee(Employee employee)
        {
            await _repository.Add(employee);
            return Results.Created($"/api/employees/{employee.Id}", employee);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpGet]
        public async Task<IResult> GetEmployees()
        {
            var employees = await _repository.GetAll();
            return Results.Ok(employees);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpGet("{id}")]
        public async Task<IResult> GetSpecificEmployee(int id)
        {
            var employee = await _repository.GetById(id);
            if (employee == null)
            {
                return (IResult)NotFound();
            }
            return Results.Ok(employee);
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        [HttpPut("{id}")]
        public async Task<IResult> UpdateEmployee(int id, Employee updatedEmployee)
        {
            if (id != updatedEmployee.Id)
            {
                return Results.BadRequest("Employee ID mismatch.");
            }

            await _repository.Update(updatedEmployee);
            return Results.Created($"/api/employees/{updatedEmployee.Id}", updatedEmployee);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpDelete("{id}")]
        public async Task<IResult> DeleteEmployee(int id)
        {
            var employee = await _repository.GetById(id);
            if (employee == null)
            {
                return Results.NotFound();
            }
            await _repository.Delete(id);
            return Results.Ok(employee);
        }
    }
}
