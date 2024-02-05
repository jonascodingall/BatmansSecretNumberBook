namespace BatmansSecretNumberBook.Exeptions
{
    public class ContactNotFoundExeption : Exception
    {
        public ContactNotFoundExeption() : base() { }
        public ContactNotFoundExeption(string message) : base(message) { }
        public ContactNotFoundExeption(string message, Exception inner) : base(message, inner) { }
    }
}
