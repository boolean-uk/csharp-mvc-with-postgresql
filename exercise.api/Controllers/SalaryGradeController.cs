using exercise.api.DTOs;
using exercise.api.Factorys;
using exercise.api.Models;
using exercise.api.Repository;
using Microsoft.AspNetCore.Mvc;

namespace exercise.api.Controllers
{
    [Route("api/salarygrades")]
    [ApiController]
    public class SalaryGradeController : ControllerBase
    {
        private readonly IRepository<SalaryGrade> _repository;
        // added factory
        private readonly IFactory<SalaryGrade, SalaryGradeInputDTO, SalaryGradeOutputDTO> _salaryGradeFactory;

        public SalaryGradeController(IRepository<SalaryGrade> repository, IFactory<SalaryGrade, SalaryGradeInputDTO, SalaryGradeOutputDTO> salaryGradeFactory)
        {
            _repository = repository;
            _salaryGradeFactory = salaryGradeFactory;
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost]
        public async Task<IResult> CreateSalaryGrade([FromBody] SalaryGradeInputDTO salaryGradeInput)
        {
            if (!ModelState.IsValid)
            {
                return Results.BadRequest(ModelState);
            }

            var salaryGrade = _salaryGradeFactory.FromDTO(salaryGradeInput);

            await _repository.Add(salaryGrade);
            return Results.Created($"/api/salarygrades/{salaryGrade.Id}", salaryGrade);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpGet]
        public async Task<IResult> GetSalaryGrades()
        {
            var salaryGrades = await _repository.GetAll();
            var salaryGradeDTOs = salaryGrades.Select(_salaryGradeFactory.ToDTO).ToList();
            return Results.Ok(salaryGradeDTOs);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpGet("{id}")]
        public async Task<IResult> GetSpecificSalaryGrade(int id)
        {
            var salaryGrade = await _repository.GetById(id);
            if (salaryGrade == null)
            {
                return Results.NotFound();
            }
            var salaryGradeDTO = _salaryGradeFactory.ToDTO(salaryGrade);
            return Results.Ok(salaryGradeDTO);
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPut("{id}")]
        public async Task<IResult> UpdateSalaryGrade(int id, [FromBody] SalaryGradeInputDTO salaryGradeInput)
        {
            if (!ModelState.IsValid)
            {
                return Results.BadRequest(ModelState);
            }

            var existingSalaryGrade = await _repository.GetById(id);
            if (existingSalaryGrade == null)
            {
                return Results.NotFound("Salary grade not found.");
            }

            _salaryGradeFactory.UpdateFromDTO(existingSalaryGrade, salaryGradeInput);

            await _repository.Update(existingSalaryGrade);
            return Results.Created($"/api/salarygrades/{existingSalaryGrade.Id}", existingSalaryGrade);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpDelete("{id}")]
        public async Task<IResult> DeleteSalaryGrade(int id)
        {
            var salaryGrade = await _repository.GetById(id);
            if (salaryGrade == null)
            {
                return Results.NotFound();
            }
            await _repository.Delete(id);
            return Results.Ok(salaryGrade);
        }
    }
}