using BatmansSecretNumberBook.Models.ContactModels;

namespace BatmansSecretNumberBook.Mappers
{
    public static class ContactMapper
    {
        #region Request To Contact Mapper
        public static Contact ToContact(this ContactRequestDto contactDto)
        {
            if (contactDto.Type == nameof(ContactBusiness))
            {
                return contactDto.ToContactBusiness();
            }
            else if (contactDto.Type == nameof(ContactPrivate))
            {
                return contactDto.ToContactPrivate();
            }
            else
            {
                throw new Exception("Falscher Typ");
            }
        }

        public static ContactPrivate ToContactPrivate(this ContactRequestDto contactDto)
        {
            return new ContactPrivate
            {
                PhoneNumber = contactDto.PhoneNumber,
                FavouriteHero = contactDto.FavouriteHero,
            };
        }

        public static ContactBusiness ToContactBusiness(this ContactRequestDto contactDto)
        {
            return new ContactBusiness
            {
                PhoneNumberBusiness = contactDto.PhoneNumberBusiness,
            };
        }
        #endregion

        #region Contact To Response Mapper
        public static ContactResponseDto ToContactResponseDto(this Contact contactModel)
        {
            if (contactModel is ContactPrivate contactPrivate)
            {
                var contactDto = contactPrivate.ToContactResponseDto();
                contactDto.Type = nameof(ContactPrivate);
                return contactDto;
            }
            else if (contactModel is ContactBusiness contactBusiness)
            {
                var contactDto = contactBusiness.ToContactResponseDto();
                contactDto.Type = nameof(ContactBusiness);
                return contactDto;
            }
            else
            {
                throw new Exception();
            }
        }

        public static ContactResponseDto ToContactResponseDto(this ContactPrivate contactModel)
        {
            return new ContactResponseDto
            {
                Id = contactModel.Id,
                PersonId = contactModel.PersonId,
                PhoneNumber = contactModel.PhoneNumber,
                FavouriteHero = contactModel.FavouriteHero,
            };
        }

        public static ContactResponseDto ToContactResponseDto(this ContactBusiness contactModel)
        {
            return new ContactResponseDto
            {
                Id= contactModel.Id,
                PersonId = contactModel.PersonId,
                PhoneNumberBusiness = contactModel.PhoneNumberBusiness,
            };
        }
        #endregion

        #region Contact To Contact
        public static void UpdateContact(this Contact contact, Contact newContact)
        {
            if (contact.GetType() != newContact.GetType())
            {
                throw new Exception($"Cant Update Contacts that are not the same Type. contact: {contact.GetType()} newContact: {newContact.GetType()}");
            }

            if (contact is ContactBusiness contactBusiness)
            {
                contactBusiness.Update((ContactBusiness)newContact);
            }
            else if (contact is ContactPrivate contactPrivate)
            {
                contactPrivate.Update((ContactPrivate)newContact);
            }
        }
        public static void Update(this ContactPrivate contact, ContactPrivate newContact)
        {
            contact.FavouriteHero = newContact.FavouriteHero;
            contact.PhoneNumber = newContact.PhoneNumber;
        }

        public static void Update(this ContactBusiness contact, ContactBusiness newContact)
        {
            contact.PersonId = newContact.PersonId;
            contact.PhoneNumberBusiness = newContact.PhoneNumberBusiness;
        }
        #endregion
    }
}
