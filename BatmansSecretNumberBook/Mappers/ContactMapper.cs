namespace BatmansSecretNumberBook.Mappers
{
    public static class ContactMapper
    {
        #region Request To Contact Mapper
        public static ContactPrivate ToContactPrivate(this ContactRequestDto contactDto)
        {
            return new ContactPrivate
            {
                PersonId = contactDto.PersonId,
                PhoneNumber = contactDto.PhoneNumber,
                FavouriteHero = contactDto.FavouriteHero,
            };
        }

        public static ContactBusiness ToContactBusiness(this ContactRequestDto contactDto)
        {
            return new ContactBusiness
            {
                PersonId = contactDto.PersonId,
                PhoneNumberBusiness = contactDto.PhoneNumberBusiness,
            };
        }
        #endregion

        #region Contact To Response Mapper
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
        public static void Update(this Contact contact, Contact newContact)
        {
            if (contact.GetType() != newContact.GetType())
            {
                throw new Exception($"Cant Update Contacts that are not the same Type. contact: {contact.GetType()} newContact: {newContact.GetType()}");
            }

            if (contact is ContactBusiness contactBusiness)
            {
                contactBusiness.Update(contact);
            }
            else if (contact is ContactPrivate contactPrivate)
            {
                contactPrivate.Update(newContact);
            }
        }
        public static void Update(this ContactPrivate contact, ContactPrivate newContact)
        {
            contact.PersonId = newContact.PersonId;
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
