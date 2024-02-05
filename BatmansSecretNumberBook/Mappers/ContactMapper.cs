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
    }
}
