using BatmansSecretNumberBook.Exeptions;
using BatmansSecretNumberBook.Mappers;
using BatmansSecretNumberBook.Services.PersonServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace BatmansSecretNumberBook.Controllers.Person
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly IPersonServiceAsync _personService;
        public PersonController(IPersonServiceAsync personService)
        {
            _personService = personService;
        }


        [HttpPost]
        public async Task<ActionResult<PersonResponseDto>> CreatePerson(PersonRequestDto person)
        {
            try
            {
                var result = await _personService.CreatePersonAsync(person.ToPerson());
                return CreatedAtAction(nameof(ReadSinglePerson), new { id = result.Id }, result.ToPersonResponseDto());
            }
            catch (Exception ex)
            {
                return BadRequest($"Error creating person: {ex.Message}");
            }
        }

        [HttpGet]
        public async Task<ActionResult<List<PersonResponseDto>>> ReadAllPersons()
        {
            var result = await _personService.ReadAllPersonsAsync();
            var resultDto = new List<PersonResponseDto>();
            foreach (var person in result)
            {
                resultDto.Add(person.ToPersonResponseDto());
            }
            return Ok(resultDto);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PersonResponseDto>> ReadSinglePerson(int id)
        {
            try
            {
                var result = await _personService.ReadSinglePersonAsync(id);
                return Ok(result.ToPersonResponseDto());
            }
            catch (PersonNotFoundException)
            {
                return NotFound($"Person with ID {id} not found");
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<PersonResponseDto>> UpdatePerson(int id, PersonRequestDto person)
        {
            try
            {
                var result = await _personService.UpdatePersonAsync(id, person.ToPerson());
                return Ok(result.ToPersonResponseDto());
            }
            catch (PersonNotFoundException)
            {
                return NotFound($"Person with ID {id} not found");
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<PersonResponseDto>> DeletePerson(int id)
        {
            try
            {
                var result = await _personService.DeletePersonAsync(id);
                return Ok(result.ToPersonResponseDto());
            }
            catch (PersonNotFoundException)
            {
                return NotFound($"Person with ID {id} not found");
            }
        }

    }
}
