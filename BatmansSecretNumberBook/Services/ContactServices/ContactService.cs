using BatmansSecretNumberBook.DTOs;
using BatmansSecretNumberBook.Mappers;
using BatmansSecretNumberBook.Wrapper;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BatmansSecretNumberBook.Services.ContactServices
{
    public class ContactService : IContactServiceAsync
    {
        private readonly DataContext _context;

        public ContactService(DataContext context)
        {
            _context = context;
        }

        public async Task<ResponseWrapper<Contact>> CreateContactAsync(int personId, ContactDto contact)
        {
            var person = await _context.Personen.FindAsync(personId);
            if (person is null)
            {
                return new ResponseWrapper<Contact>()
                {
                    StatusCode = 404,
                    Message = $"Person mit der id: {personId} konnte nicht gefunden werden",
                    Data = null
                };
            }
            if (contact.Type == "private")
            {
                var contactModel = contact.ToContactPrivate();
                contactModel.PersonId = personId;
                _context.ContactsPrivate.Add(contactModel);
                await _context.SaveChangesAsync();
                return new ResponseWrapper<Contact>
                {
                    StatusCode = 201,
                    Message = "Privater Kontakt wurde erfolgreich erstellt",
                    Data = contactModel
                };
            }
            else if (contact.Type == "business")
            {
                var contactModel = contact.ToContactBusiness();
                contactModel.PersonId = personId;
                _context.ContactsBusiness.Add(contactModel);
                await _context.SaveChangesAsync();
                return new ResponseWrapper<Contact>
                {
                    StatusCode = 200,
                    Message = "Geschäftlicher Kontakt wurde erfolgreich erstellt",
                    Data = contactModel
                };
            }
            else
            {
                return new ResponseWrapper<Contact>
                {
                    StatusCode = 400,
                    Message = "Ungültiger Kontakttyp",
                    Data = null
                };
            }
        }

        public async Task<ResponseWrapper<Contact>> DeleteContactAsync(int id)
        {
            var contact = await _context.ContactsBusiness.FindAsync(id);
            if (contact != null)
            {
                _context.Contacts.Remove(contact);
                await _context.SaveChangesAsync();
                return new ResponseWrapper<Contact>
                {
                    StatusCode = 200,
                    Message = $"Kontakt mit der ID: {id} wurde erfolgreich gelöscht",
                    Data = contact
                };
            }
            else
            {
                return new ResponseWrapper<Contact>
                {
                    StatusCode = 404,
                    Message = $"Kontakt mit der ID: {id} konnte nicht gefunden werden",
                    Data = null
                };
            }
        }

        public async Task<ResponseWrapper<List<Contact>>> ReadAllContactAsync()
        {
            var contacts = await _context.Contacts.ToListAsync();

            return new ResponseWrapper<List<Contact>>
            {
                StatusCode = 200,
                Message = "",
                Data = contacts
            };
        }

        public async Task<ResponseWrapper<Contact>> ReadSingleContactAsync(int id)
        {
            var contact = await _context.Contacts.FindAsync(id);
            if (contact != null)
            {
                return new ResponseWrapper<Contact>
                {
                    StatusCode = 200,
                    Message = $"Kontakt mit der ID: {id} wurde erfolgreich gelesen",
                    Data = contact
                };
            }
            else
            {
                return new ResponseWrapper<Contact>
                {
                    StatusCode = 404,
                    Message = $"Kontakt mit der ID: {id} konnte nicht gefunden werden",
                    Data = null
                };
            }
        }

        public async Task<ResponseWrapper<Contact>> UpdateContactAsync(int id, ContactDto request)
        {
            var contact = await _context.Contacts.FindAsync(id);
            if (contact != null)
            {
                if (contact is ContactPrivate contactPrivate)
                {
                    contactPrivate.FavouriteHero = request.FavouriteHero;
                    contactPrivate.PhoneNumber = request.PhoneNumber;
                }
                else if (contact is ContactBusiness contactBusiness)
                {
                    contactBusiness.PhoneNumberBusiness = request.PhoneNumberBusiness;
                }
                await _context.SaveChangesAsync();

                return new ResponseWrapper<Contact>
                {
                    StatusCode = 200,
                    Message = $"Kontakt mit der ID: {id} wurde erfolgreich aktualisiert",
                    Data = contact
                };
            }
            else
            {
                return new ResponseWrapper<Contact>
                {
                    StatusCode = 404,
                    Message = $"Kontakt mit der ID: {id} konnte nicht gefunden werden",
                    Data = null
                };
            }
        }
    }
}
