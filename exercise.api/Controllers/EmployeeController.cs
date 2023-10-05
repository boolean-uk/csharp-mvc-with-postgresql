using exercise.api.DTOs;
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
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost]
        public async Task<IResult> CreateEmployee([FromBody] EmployeeInputDTO employeeInput)
        {
            if (!ModelState.IsValid)
            {
                return Results.BadRequest(ModelState);
            }

            // converting the dto to enity
            var employee = new Employee
            {
                Name = employeeInput.Name,
                JobName = employeeInput.JobName,
                SalaryGrade = employeeInput.SalaryGrade,
                Department = employeeInput.Department
            };
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
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPut("{id}")]
        public async Task<IResult> UpdateEmployee(int id, [FromBody] EmployeeInputDTO employeeInput)
        {
            if (!ModelState.IsValid)
            {
                return Results.BadRequest(ModelState);
            }

            var existingEmployee = await _repository.GetById(id);
            if (existingEmployee == null)
            {
                return Results.NotFound("Employee not found.");
            }

            // and update properties from dto
            existingEmployee.Name = employeeInput.Name;
            existingEmployee.JobName = employeeInput.JobName;
            existingEmployee.SalaryGrade = employeeInput.SalaryGrade;
            existingEmployee.Department = employeeInput.Department;

            await _repository.Update(existingEmployee);
            return Results.Created($"/api/employees/{existingEmployee.Id}", existingEmployee);
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
