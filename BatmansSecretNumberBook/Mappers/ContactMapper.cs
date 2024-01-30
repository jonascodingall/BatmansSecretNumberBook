using BatmansSecretNumberBook.DTOs;

namespace BatmansSecretNumberBook.Mappers
{
    public static class ContactMapper
    {
        public static ContactDto ToContactDto(this ContactBusiness contactModel)
        {
            return new ContactDto
            {
                PhoneNumberBusiness = contactModel.PhoneNumberBusiness,
            };
        }
        public static ContactDto ToContactDto(this ContactPrivate contactModel)
        {
            return new ContactDto
            {
                FavouriteHero = contactModel.FavouriteHero,
                PhoneNumber = contactModel.PhoneNumber,
            };
        }

        public static ContactBusiness ToContactBusiness(this ContactDto contactDtoModel)
        {
            return new ContactBusiness
            {
                PhoneNumberBusiness = contactDtoModel.PhoneNumberBusiness,
            };
        }
        public static ContactPrivate ToContactPrivate(this ContactDto contactDtoModel)
        {
            return new ContactPrivate
            {
                FavouriteHero = contactDtoModel.FavouriteHero,
                PhoneNumber = contactDtoModel.PhoneNumber,
            };
        }
    }
}
