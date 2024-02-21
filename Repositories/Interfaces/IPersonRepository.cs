using SaudePlus.Models;

namespace SaudePlus.Repositories.Interfaces
{
    public interface IPersonRepository
    {
        Task<List<PersonModel>> GetAllPersons();
        Task<PersonModel> GetPersonById(int id);
        Task<PersonModel> CreatePerson(PersonModel person);
        Task<PersonModel> UpdatePerson(PersonModel person, int id);
        Task<bool> DeletePerson(int id);
    }
}
