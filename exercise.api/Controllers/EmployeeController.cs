using exercise.api.DTOs;
using exercise.api.Factorys;
using exercise.api.Repository;
using Microsoft.AspNetCore.Mvc;

namespace exercise.api.Controllers
{
    [Route("api/employees")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeRepository _repository;
        // added factory
        private readonly IEmployeeFactory _employeeFactory;

        public EmployeeController(IEmployeeRepository repository, IEmployeeFactory employeeFactory)
        {
            _repository = repository;
            _employeeFactory = employeeFactory;
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
            // used the factory for not newing in the creation itself
            var employee = _employeeFactory.FromDTO(employeeInput);

            await _repository.Add(employee);
            return Results.Created($"/api/employees/{employee.Id}", employee);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpGet]
        public async Task<IResult> GetEmployees()
        {
            var employees = await _repository.GetAll();
            var employeeDTOs = employees.Select(_employeeFactory.ToDTO).ToList();
            return Results.Ok(employeeDTOs);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpGet("{id}")]
        public async Task<IResult> GetSpecificEmployee(int id)
        {
            var employee = await _repository.GetById(id);
            if (employee == null)
            {
                return Results.NotFound();
            }
            var employeeDTO = _employeeFactory.ToDTO(employee);
            return Results.Ok(employeeDTO);
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
            // used factory for not newing in updating
            _employeeFactory.UpdateFromDTO(existingEmployee, employeeInput);

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
