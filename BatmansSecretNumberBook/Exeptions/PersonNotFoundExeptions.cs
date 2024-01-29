namespace BatmansSecretNumberBook.Exeptions
{
    public class PersonNotFoundExeptions : Exception
    {
        public PersonNotFoundExeptions() : base()
        {
            
        }
        public PersonNotFoundExeptions(string message) : base(message)
        {

        }
        public PersonNotFoundExeptions(string message, Exception inner) : base(message , inner)
        {

        }
    }
}
