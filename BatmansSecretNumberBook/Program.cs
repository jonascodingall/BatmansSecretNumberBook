using BatmansSecretNumberBook;
using BatmansSecretNumberBook.Data;
using BatmansSecretNumberBook.Models;

class Program
{
    public static void Main()
    {
        var tb = new Telefonbuch();

        tb.DeletePerson(new Person()
        {
            Id = 1
        });
    }
}