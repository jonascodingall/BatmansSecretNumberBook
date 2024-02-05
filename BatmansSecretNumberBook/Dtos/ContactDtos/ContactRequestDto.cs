namespace BatmansSecretNumberBook.Dtos.Contact
{
#nullable disable
    public class ContactRequestDto
    {
        public string Type { get; set; }
        public string PhoneNumber { get; set; }
        string PhoneNumberBusiness {  get; set; }
        public int PersonId { get; set; }
    }
}
