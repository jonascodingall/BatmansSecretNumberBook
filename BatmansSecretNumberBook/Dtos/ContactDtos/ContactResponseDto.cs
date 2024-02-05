namespace BatmansSecretNumberBook.Dtos.Contact
{
#nullable disable
    public class ContactResponseDto
    {
        public int Id { get; set; }
        public int PersonId { get; set; }
        public string Type { get; set; }
        public string PhoneNumberBusiness { get; set; }
        public string PhoneNumber {  get; set; }
    }
}
