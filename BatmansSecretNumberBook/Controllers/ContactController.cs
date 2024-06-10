using BatmansSecretNumberBook.Exeptions;
using BatmansSecretNumberBook.Mappers;
using BatmansSecretNumberBook.Services.ContactServices;
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

        [HttpPost]
        public async Task<ActionResult> CreateContact(int personId, ContactRequestDto contactDto)
        {
            try
            {
                var contact = contactDto.ToContact();
                contact.PersonId = personId;
                await _contactService.CreateContactAsync(contact);
                return Created();
            }
            catch (PersonNotFoundException)
            {
                return BadRequest($"Person mit der ID {personId} wurde nicht gefunden");
            }
            catch (Exception ex)
            {
                return BadRequest($"Fehler beim Erstellen des Kontakts: {ex.Message}");
            }
        }

        [HttpGet]
        public async Task<ActionResult<List<ContactResponseDto>>> ReadAllContacts()
        {
            var result = await _contactService.ReadAllContactAsync();
            var resultDto = new List<ContactResponseDto>();
            foreach (var contact in result)
            {
                resultDto.Add(contact.ToContactResponseDto());
            }
            return Ok(resultDto);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ContactResponseDto>> ReadSingleContact(int id)
        {
            try
            {
                var result = await _contactService.ReadSingleContactAsync(id);
                return Ok(result.ToContactResponseDto());
            }
            catch (ContactNotFoundException)
            {
                return NotFound($"Kontakt mit der ID {id} wurde nicht gefunden");
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateContact(int id, ContactRequestDto contact)
        {
            try
            {
                await _contactService.UpdateContactAsync(id, contact.ToContact());
                return Ok();
            }
            catch (ContactNotFoundException)
            {
                return NotFound($"Kontakt mit der ID {id} wurde nicht gefunden");
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteContact(int id)
        {
            try
            {
                await _contactService.DeleteContactAsync(id);
                return Ok();
            }
            catch (ContactNotFoundException)
            {
                return NotFound($"Kontakt mit der ID {id} wurde nicht gefunden");
            }
        }

    }
}
