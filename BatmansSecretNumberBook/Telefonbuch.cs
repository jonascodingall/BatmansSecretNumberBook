using BatmansSecretNumberBook.Data;
using BatmansSecretNumberBook.Exeptions;
using BatmansSecretNumberBook.Models;

namespace BatmansSecretNumberBook
{
    public class Telefonbuch
    {
        #region CRUD Person

        //CREATE
        public void CreatePerson(Person person)
        {
            using var dbContext = new DatabaseContext();
            dbContext.Add(person);
            dbContext.SaveChanges();
        }
        //READ
        public List<Person> ReadPersons()
        {
            using var dbContext = new DatabaseContext();
            return [.. dbContext.Personen];
        }
        public List<Person> ReadPersonsByCriteria(Func<Person, bool> criteria)
        {
            using var dbContext = new DatabaseContext();
            return [.. dbContext.Personen.Where(criteria)];
        }
        //UPDATE
        public void UpdatePerson(Person oldPerson, Person newPerson)
        {
            using var dbContext = new DatabaseContext();
            dbContext.Entry(oldPerson).CurrentValues.SetValues(newPerson);
            dbContext.SaveChanges();
        }
        //DELETE
        public void DeletePerson(Person person)
        {
            using var dbContext = new DatabaseContext();
            dbContext.Remove(person);
            dbContext.SaveChanges();
        }
        public void DeletePersonsByCriteria(Func<Person, bool> criteria)
        {
            using var dbContext = new DatabaseContext();
            var personsToDelete = dbContext.Personen.Where(criteria).ToList();
            dbContext.Personen.RemoveRange(personsToDelete);
            dbContext.SaveChanges();
        }
        #endregion

        #region CRUD Kontakt

        //CREATE
        public void AddKontaktToPerson(Person person, Kontakt kontakt)
        {
            using var dbContext = new DatabaseContext();
            var existingPerson = dbContext.Personen.Find(person.Id);
            if (existingPerson != null)
            {
                kontakt.PersonId = existingPerson.Id;
                dbContext.Add(kontakt);
                dbContext.SaveChanges();
            }
            else
            {
                throw new PersonNotFoundExeptions();
            }
        }
        //READ
        public List<Kontakt> ReadKontakte()
        {
            using var dbContext = new DatabaseContext();
            return [.. dbContext.Kontakte];
        }
        public List<Kontakt> ReadKontakteByCriteria(Func<Kontakt, bool> criteria)
        {
            using var dbContext = new DatabaseContext();
            return [.. dbContext.Kontakte.Where(criteria)];
        }
        //Update
        public void UpdateKontakt(Kontakt oldKontakt, Kontakt newKontakt)
        {
            using var dbContext = new DatabaseContext();
            dbContext.Entry(oldKontakt).CurrentValues.SetValues(newKontakt);
            dbContext.SaveChanges();
        }
        //Delete
        public void DeleteKontakt(Kontakt kontakt)
        {
            using var dbContext = new DatabaseContext();
            dbContext.Remove(kontakt);
            dbContext.SaveChanges();
        }
        public void DeleteKontakteByCriteria(Func<Kontakt, bool> criteria)
        {
            using var dbContext = new DatabaseContext();
            var kontakteToDelete = dbContext.Kontakte.Where(criteria).ToList();
            dbContext.Kontakte.RemoveRange(kontakteToDelete);
            dbContext.SaveChanges();
        }
        #endregion
    }
}