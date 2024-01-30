using BatmansSecretNumberBook.DTOs;
using BatmansSecretNumberBook.Mappers;
using BatmansSecretNumberBook.Wrapper;
using Microsoft.EntityFrameworkCore;

namespace BatmansSecretNumberBook.Services.PersonServices
{
    public class PersonService : IPersonServiceAsync
    {
        private readonly DataContext _context;
        public PersonService(DataContext context)
        {
            _context = context;
        }

        public async Task<ResponseWrapper<PersonDto>> CreatePersonAsync(PersonDto person)
        {
            _context.Add(person);
            await _context.SaveChangesAsync();

            return new ResponseWrapper<PersonDto>
            {
                StatusCode = 200,
                Message = "Person erfolgreich erstellt",
                Data = person
            };
        }

        public async Task<ResponseWrapper<PersonDto>> DeletePersonAsync(int id)
        {
            var person = await _context.Personen.FindAsync(id);
            if (person is not null)
            {
                _context.Remove(person);
                await _context.SaveChangesAsync();
                return new ResponseWrapper<PersonDto>
                {
                    StatusCode = 204,
                    Message = $"Person mit der id: {id} wurde erfolgreich gelöscht",
                    Data = person.ToPersonDto()
                };
            }
            else
            {
                return new ResponseWrapper<PersonDto>
                {
                    StatusCode = 404,
                    Message = $"Person mit der id: {id} konnte nicht gefunden werden",
                    Data = null
                };
            }
        }


        public async Task<ResponseWrapper<List<PersonDto>>> ReadAllPersonsAsync()
        {
            var persons = await _context.Personen.Select(p => p.ToPersonDto()).ToListAsync();
            return new ResponseWrapper<List<PersonDto>>
            {
                StatusCode = 200,
                Message = "Personen erfolgreich gelesen",
                Data = persons
            };
        }

        public async Task<ResponseWrapper<PersonDto>> ReadSinglePersonAsync(int id)
        {
            var person = await _context.Personen.FindAsync(id);
            if (person is not null)
            {
                return new ResponseWrapper<PersonDto>
                {
                    StatusCode = 200,
                    Message = $"Person mit der id: {id} erfolgreich gelesen",
                    Data = person.ToPersonDto()
                };
            }
            else
            {
                return new ResponseWrapper<PersonDto>
                {
                    StatusCode = 404,
                    Message = $"Person mit der id {id} konnte nicht gefunden werden",
                    Data = null
                };
            }
        }

        public async Task<ResponseWrapper<PersonDto>> UpdatePersonAsync(int id, PersonDto request)
        {
            var person = await _context.Personen.FindAsync(id);
            if (person is not null)
            {
                person.FirstName = request.FirstName;
                person.LastName = request.LastName;

                await _context.SaveChangesAsync();

                return new ResponseWrapper<PersonDto>
                {
                    StatusCode = 200,
                    Message = $"Person mit der id: {id} erfolgreich geupdatet",
                    Data = person.ToPersonDto()
                };
            }
            else
            {
                return new ResponseWrapper<PersonDto>
                {
                    StatusCode = 404,
                    Message = $"Person mit der id: {id} konnte nicht gefunden werden",
                    Data = null
                };
            }

        }
    }
}
