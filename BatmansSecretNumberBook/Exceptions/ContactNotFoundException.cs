namespace BatmansSecretNumberBook.Exeptions
{
    public class ContactNotFoundException : Exception
    {
        public ContactNotFoundException() : base() { }
        public ContactNotFoundException(string message) : base(message) { }
        public ContactNotFoundException(string message, Exception inner) : base(message, inner) { }
    }
}
