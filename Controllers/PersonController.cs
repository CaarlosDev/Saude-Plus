using Microsoft.AspNetCore.Mvc;
using SaudePlus.Models;
using SaudePlus.Repositories.Interfaces;

namespace SaudePlus.Controllers
{
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
        public async Task<ActionResult<PersonModel>> CreatePerson(PersonModel person) {
            PersonModel createdPerson = await _personRepository.CreatePerson(person);
            return Ok(createdPerson);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<PersonModel>> UpdatePerson(PersonModel person, int id) {
            PersonModel createdPerson = await _personRepository.UpdatePerson(person, id);
            return Ok(createdPerson);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<PersonModel>> DeletePerson(int id) {
            bool hasDeletedPerson = await _personRepository.DeletePerson(id);
            return Ok(hasDeletedPerson);
        }
    }
}