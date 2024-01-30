using BatmansSecretNumberBook.DTOs;

namespace BatmansSecretNumberBook.Mappers
{
    public static class PersonMapper
    {
        public static PersonDto ToPersonDto(this Person personModel)
        {
            return new PersonDto
            {
                FirstName = personModel.FirstName,
                LastName = personModel.LastName,
            };
        }
        public static Person ToPerson(this PersonDto personDtoModel)
        {
            return new Person
            {
                FirstName = personDtoModel.FirstName,
                LastName = personDtoModel.LastName,
            };
        }
    }
}
