namespace BatmansSecretNumberBook.Exeptions
{
    public class PersonNotFoundExeption : Exception
    {
        public PersonNotFoundExeption(): base() { }

        public PersonNotFoundExeption(string message) : base(message) { }

        public PersonNotFoundExeption(string message, Exception inner) : base(message, inner) { }
    }
}
