namespace BatmansSecretNumberBook.Exeptions
{
    public class PersonNotFoundException : Exception
    {
        public PersonNotFoundException(): base() { }

        public PersonNotFoundException(string message) : base(message) { }

        public PersonNotFoundException(string message, Exception inner) : base(message, inner) { }
    }
}
