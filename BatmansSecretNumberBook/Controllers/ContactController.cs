using BatmansSecretNumberBook.DTOs;
using BatmansSecretNumberBook.Services.ContactServices;
using BatmansSecretNumberBook.Services.PersonServices;
using BatmansSecretNumberBook.Wrapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BatmansSecretNumberBook.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly IContactServiceAsync _contactService;
        public ContactController(IContactServiceAsync contactService)
        {
            _contactService = contactService;
        }

        #region C : Create

        [HttpPost]
        public async Task<ActionResult<ContactDto>> CreateContact(ContactDto contact)
        {
            throw new NotImplementedException();
        }

        #endregion
        #region R : Read 

        [HttpGet]
        public async Task<ActionResult<List<ContactDto>>> ReadAllContacts()
        {
            throw new NotImplementedException();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ContactDto>> ReadSingleContact(int id)
        {
            throw new NotImplementedException();
        }

        #endregion 
        #region U : Update

        [HttpPut("{id}")]
        public async Task<ActionResult<ContactDto>> UpdateContact(int id, ContactDto contact)
        {
            throw new NotImplementedException();
        }

        #endregion
        #region D : Delete

        [HttpDelete("{id}")]
        public async Task<ActionResult<ContactDto>> DeleteContact(int id)
        {
            throw new NotImplementedException();
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
