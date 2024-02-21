using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SaudePlus.Models;
using SaudePlus.Repositories.Interfaces;

namespace SaudePlus.Controllers
{
    [Authorize]
    [Route("api/persons")]
    [ApiController]

    public class PersonController : ControllerBase {
        private readonly IPersonRepository _personRepository;
        public PersonController(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<PersonModel>>> GetAllPersons() {
            List<PersonModel> persons = await _personRepository.GetAllPersons();
            return Ok(persons);
        }
        
        [HttpGet("{id}")]
        public async Task<ActionResult<PersonModel>> GetPersonById(int id) {
            PersonModel person = await _personRepository.GetPersonById(id);
            return Ok(person);
        }

        [HttpPost]
        public async Task<ActionResult<PersonModel>> CreatePerson(PersonModelRequest person) {
            PersonModel createdPerson = await _personRepository.CreatePerson(buildPersonModel(person));
            return Ok(createdPerson);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<PersonModel>> UpdatePerson(PersonModelRequest person, int id) {
            PersonModel updatedPerson = await _personRepository.UpdatePerson(buildPersonModel(person), id);
            return Ok(updatedPerson);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<PersonModel>> DeletePerson(int id) {
            bool hasDeletedPerson = await _personRepository.DeletePerson(id);
            return Ok(hasDeletedPerson);
        }

        private PersonModel buildPersonModel(PersonModelRequest person) {
            PersonModel newPerson = new PersonModel();
            newPerson.Name = person.Name;
            newPerson.Cpf = person.Cpf;
            newPerson.Birthday = person.Birthday;
            newPerson.Gender = person.Gender;
            newPerson.City = person.City;
            newPerson.IfSmoke = person.IfSmoke;
            newPerson.SmokeQuantity = person.SmokeQuantity;
            newPerson.UserId = person.UserId;

            return newPerson;
        }
    }
}