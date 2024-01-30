using BatmansSecretNumberBook.DTOs;
using BatmansSecretNumberBook.Mappers;
using BatmansSecretNumberBook.Services.PersonServices;
using BatmansSecretNumberBook.Wrapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace BatmansSecretNumberBook.Controllers
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

        #region C : Create

        [HttpPost]
        public async Task<ActionResult<PersonDto>> CreatePerson(PersonDto person)
        {
            var result = await _personService.CreatePersonAsync(person);
            return UnWrapResponse(result);
        }

        #endregion
        #region R : Read 

        [HttpGet]
        public async Task<ActionResult<List<PersonDto>>> ReadAllPersons()
        {
            var result = await _personService.ReadAllPersonsAsync();
            return UnWrapResponse(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PersonDto>> ReadSinglePerson(int id)
        {
            var result = await _personService.ReadSinglePersonAsync(id);
            return UnWrapResponse<PersonDto>(result);
        }

        #endregion 
        #region U : Update

        [HttpPut("{id}")]
        public async Task<ActionResult<PersonDto>> UpdatePerson(int id, PersonDto person)
        {
            var result = await _personService.UpdatePersonAsync(id, person);
            return UnWrapResponse(result);
        }

        #endregion
        #region D : Delete

        [HttpDelete("{id}")]
        public async Task<ActionResult<PersonDto>> DeletePerson(int id)
        {
            var result = await _personService.DeletePersonAsync(id);
            return UnWrapResponse(result);
        }

        #endregion

        private ActionResult<T> UnWrapResponse<T>(ResponseWrapper<T> responseWrapper)
        {
            return responseWrapper.StatusCode switch
            {
                200 => (ActionResult<T>)Ok(responseWrapper.Data),
                201 => (ActionResult<T>)CreatedAtAction("ActionName", responseWrapper.Data),
                204 => (ActionResult<T>)NoContent(),
                400 => (ActionResult<T>)BadRequest(responseWrapper.Message),
                401 => (ActionResult<T>)Unauthorized(responseWrapper.Message),
                403 => (ActionResult<T>)Forbid(responseWrapper.Message),
                404 => (ActionResult<T>)NotFound(responseWrapper.Message),
                500 => (ActionResult<T>)StatusCode(500, responseWrapper.Message),
                _ => (ActionResult<T>)StatusCode(responseWrapper.StatusCode, responseWrapper.Message),
            };
        }
    }
}
