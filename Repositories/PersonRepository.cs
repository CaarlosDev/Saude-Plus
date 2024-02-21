using Microsoft.EntityFrameworkCore;
using SaudePlus.Data;
using SaudePlus.Models;
using SaudePlus.Repositories.Interfaces;

namespace SaudePlus.Repositories
{
    public class PersonRepository : IPersonRepository
    {
        private readonly SystemDbContext _dbContext;
        public PersonRepository(SystemDbContext SystemDbContext)
        {
            _dbContext = SystemDbContext;
        }
        public async Task<List<PersonModel>> GetAllPersons()
        {
            return await _dbContext.Persons.Include(x => x.User).ToListAsync();
        }

        public async Task<PersonModel> GetPersonById(int id)
        {
            return await _dbContext.Persons.Include(x => x.User).FirstOrDefaultAsync(x => x.Id == id);
        }
        public async Task<PersonModel> CreatePerson(PersonModel person)
        {
            await _dbContext.Persons.AddAsync(person);
            await _dbContext.SaveChangesAsync();
            return person;
        }

        public async Task<PersonModel> UpdatePerson(PersonModel person, int id)
        {
            PersonModel personById = await GetPersonById(id);

            if (personById == null) {
                throw new Exception("Person not found");
            }

            personById.Name = person.Name;
            personById.Cpf = person.Cpf;
            personById.Birthday = person.Birthday;
            personById.Gender = person.Gender;
            personById.City = person.City;
            personById.IfSmoke = person.IfSmoke;
            personById.SmokeQuantity = person.SmokeQuantity;

            _dbContext.Persons.Update(personById);
            await _dbContext.SaveChangesAsync();

            return personById;
        }

        public async Task<bool> DeletePerson(int id)
        {
            PersonModel personById = await GetPersonById(id);
            
            if (personById == null) {
                throw new Exception("Person not found");
            }

            _dbContext.Persons.Remove(personById);
            await _dbContext.SaveChangesAsync();

            return true;
        }
    }
}
