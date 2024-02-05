namespace BatmansSecretNumberBook.Mappers
{
    public static class PersonMapper
    {
        #region Request To Person Mapper
        public static Person ToPerson(this PersonRequestDto personDto)
        {
            return new Person
            {
                FirstName = personDto.FirstName,
                LastName = personDto.LastName,
            };
        } 
        #endregion

        #region Person To ResponseMapper
        public static PersonResponseDto ToPersonResponseDto(this Person personModel)
        {
            return new PersonResponseDto
            {
                Id = personModel.Id,
                FirstName = personModel.FirstName,
                LastName = personModel.LastName,
            };
        }
        #endregion

        #region Person To Person
        public static void Update(this Person person, Person newPerson)
        {
            person.FirstName = newPerson.FirstName;
            person.LastName = newPerson.LastName;
        }
        #endregion
    }
}
