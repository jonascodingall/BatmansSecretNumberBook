using BatmansSecretNumberBook.DTOs;
using BatmansSecretNumberBook.Models;
using BatmansSecretNumberBook.Services.ContactServices;
using BatmansSecretNumberBook.Services.PersonServices;
using BatmansSecretNumberBook.Wrapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

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
        public async Task<ActionResult<Contact>> CreateContact(int personId, ContactDto contact)
        {
            var result = await _contactService.CreateContactAsync(personId, contact);
            return UnWrapResponse(result);
        }

        #endregion
        #region R : Read 

        [HttpGet]
        public async Task<ActionResult<List<Contact>>> ReadAllContacts()
        {
            var result = await _contactService.ReadAllContactAsync();
            return UnWrapResponse(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Contact>> ReadSingleContact(int id)
        {
            var result = await _contactService.ReadSingleContactAsync(id);
            return UnWrapResponse(result);
        }

        #endregion 
        #region U : Update

        [HttpPut("{id}")]
        public async Task<ActionResult<Contact>> UpdateContact(int id, ContactDto contact)
        {
            var result = await _contactService.UpdateContactAsync(id, contact);
            return UnWrapResponse(result);
        }

        #endregion
        #region D : Delete

        [HttpDelete("{id}")]
        public async Task<ActionResult<Contact>> DeleteContact(int id)
        {
            var result = await _contactService.DeleteContactAsync(id);
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
