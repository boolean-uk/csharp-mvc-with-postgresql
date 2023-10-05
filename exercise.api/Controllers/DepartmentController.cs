using exercise.api.DTOs;
using exercise.api.Factorys;
using exercise.api.Repository;
using Microsoft.AspNetCore.Mvc;

namespace exercise.api.Controllers
{
    [Route("api/departments")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartmentRepository _repository;

        private readonly IDepartmentFactory _departmentFactory;

        public DepartmentController(IDepartmentRepository repository, IDepartmentFactory departmentFactory)
        {
            _repository = repository;
            _departmentFactory = departmentFactory;
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost]
        public async Task<IResult> CreateDepartment([FromBody] DepartmentDTO departmentDTO)
        {
            if (!ModelState.IsValid)
            {
                return Results.BadRequest(ModelState);
            }

            var department = _departmentFactory.Create(departmentDTO);

            await _repository.Add(department);
            return Results.Created($"/api/departments/{department.Id}", department);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpGet]
        public async Task<IResult> GetDepartments()
        {
            var departments = await _repository.GetAll();
            var departmentDTOs = departments.Select(_departmentFactory.ToDTO).ToList();
            return Results.Ok(departmentDTOs);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpGet("{id}")]
        public async Task<IResult> GetSpecificDepartment(int id)
        {
            var department = await _repository.GetById(id);
            if (department == null)
            {
                return Results.NotFound();
            }
            var departmentDTO = _departmentFactory.ToDTO(department);
            return Results.Ok(departmentDTO);
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPut("{id}")]
        public async Task<IResult> UpdateDepartment(int id, [FromBody] DepartmentDTO departmentDTO)
        {
            if (!ModelState.IsValid)
            {
                return Results.BadRequest(ModelState);
            }

            var existingDepartment = await _repository.GetById(id);
            if (existingDepartment == null)
            {
                return Results.NotFound("Department not found.");
            }

            _departmentFactory.UpdateFromDTO(existingDepartment, departmentDTO);

            await _repository.Update(existingDepartment);
            return Results.Created($"/api/departments/{existingDepartment.Id}", existingDepartment);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpDelete("{id}")]
        public async Task<IResult> DeleteDepartment(int id)
        {
            var department = await _repository.GetById(id);
            if (department == null)
            {
                return Results.NotFound();
            }
            await _repository.Delete(id);
            return Results.Ok(department);
        }
    }
}
