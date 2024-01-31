using BatmansSecretNumberBook.DTOs;
using BatmansSecretNumberBook.Mappers;
using BatmansSecretNumberBook.Wrapper;
using Microsoft.EntityFrameworkCore;

namespace BatmansSecretNumberBook.Services.ContactServices
{
    public class ContactService : IContactServiceAsync
    {
        private readonly DataContext _context;
        public ContactService(DataContext context)
        {
            _context = context;
        }
        public async Task<ResponseWrapper<ContactDto>> CreateContactAsync(ContactDto contact)
        {
            if (contact.Type == "private")
            {
                _context.ContactsPrivate.Add(contact.ToContactPrivate());
                await _context.SaveChangesAsync();
                return new ResponseWrapper<ContactDto>
                {
                    StatusCode = 200,
                    Message = "Privater Kontatkt wurde erfolgreich erstellt",
                    Data = null
                };
            }
            else if (contact.Type == "business")
            {
                _context.ContactsBusiness.Add(contact.ToContactBusiness());
                await _context.SaveChangesAsync();
                return new ResponseWrapper<ContactDto>
                {
                    StatusCode = 200,
                    Message = "Geschftlicher Kontatkt wurde erfolgreich erstellt",
                    Data = null
                };
            }
            else
            {
                return new ResponseWrapper<ContactDto>
                {
                    StatusCode = 400,
                    Message = "Invalider Typ von Type",
                    Data = null
                };
            }
        }

        public async Task<ResponseWrapper<ContactDto>> DeleteContactAsync(int id)
        {
            var contact = await _context.ContactsBusiness.FindAsync(id);
            if(contact is not null)
            {
                _context.Contacts.Remove(contact);
                await _context.SaveChangesAsync();
                return new ResponseWrapper<ContactDto>
                {
                    StatusCode = 200,
                    Message = $"Kontakt mit der id: {id} wurder erfolgreich gelöscht",
                    Data = contact.ToContactDto()
                };
            }
            else
            {
                return new ResponseWrapper<ContactDto>
                {
                    StatusCode = 404,
                    Message = $"Kontakt mit der id: {id} konnte nicht gefunden werden",
                    Data = null
                };
            }
        }

        public async Task<ResponseWrapper<List<ContactDto>>> ReadAllContactAsync()
        {
            var contacts = await _context.Contacts.ToListAsync();
            var contacsDto = new List<ContactDto>();
            foreach (var contact in contacts)
            {
                if(contact is ContactPrivate contactPrivate)
                {
                    contacsDto.Add(contactPrivate.ToContactDto());
                }
                else if (contact is ContactBusiness contactBusiness)
                {
                    contacsDto.Add(contactBusiness.ToContactDto());
                }
            }

            return new ResponseWrapper<List<ContactDto>>
            {
                StatusCode = 200,
                Message = "",
                Data = contacsDto
            };
        }

        public async Task<ResponseWrapper<ContactDto>> ReadSingleContactAsync(int id)
        {
            var contact = await _context.Contacts.FindAsync(id);
            if (contact is not null)
            {
                if (contact is ContactPrivate contactPrivate)
                {
                    return new ResponseWrapper<ContactDto>
                    {
                        StatusCode = 200,
                        Message = $"Kontakt mit der id: {id} wurde erfolgreich gelesen",
                        Data = contactPrivate.ToContactDto()
                    };
                }
                else if (contact is ContactBusiness contactBusiness)
                {
                    return new ResponseWrapper<ContactDto>
                    {
                        StatusCode = 200,
                        Message = $"Kontakt mit der id: {id} wurde erfolgreich gelesen",
                        Data = contactBusiness.ToContactDto()
                    };
                }
                else
                {
                    return new ResponseWrapper<ContactDto>
                    {
                        StatusCode = 400,
                        Message = $"Kontalt mit der id: {id} ist nicht von einem uns Bekannten Typ",
                        Data = null
                    };
                }
            }
            else
            {
                return new ResponseWrapper<ContactDto>
                {
                    StatusCode = 404,
                    Message = $"Kontalt mit der id: {id} konnte nicht gefunden werden",
                    Data = null
                };
            }

            
        }

        public async Task<ResponseWrapper<ContactDto>> UpdateContactAsync(int id, ContactDto request)
        {
            var contact = await _context.Contacts.FindAsync(id);
            var contactDto = new ContactDto();
            if (contact is not null)
            {
                if (contact is ContactPrivate contactPrivate)
                {
                    contactDto = contactPrivate.ToContactDto();
                }
                else if (contact is ContactBusiness contactBusiness)
                {
                    contactDto = contactBusiness.ToContactDto();
                }

                contactDto.PhoneNumber = request.PhoneNumber;
                contactDto.PhoneNumberBusiness = request.PhoneNumberBusiness;
                contactDto.FavouriteHero = request.FavouriteHero;

                return new ResponseWrapper<ContactDto>
                {
                    StatusCode = 200,
                    Message = $"Kontakt mit der id: {id} wurde erfolgreich geupdatet",
                    Data = contactDto
                };
            }
            else
            {
                return new ResponseWrapper<ContactDto>
                {
                    StatusCode = 404,
                    Message = $"Kontalt mit der id: {id} konnte nicht gefunden werden",
                    Data = null
                };
            }
        }
    }
}
