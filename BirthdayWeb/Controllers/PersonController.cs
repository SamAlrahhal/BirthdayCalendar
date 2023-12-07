using BirthdayWeb.Interfaces;
using BirthdayWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace BirthdayWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : Controller
    {
        private readonly IPersonRepository _personRepository;
        public PersonController(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<PersonController>))]
        public IActionResult GetPeople()
        {
            var people = _personRepository.GetAllPeople();

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(people);
        }
        [HttpGet("{personId}")]
        [ProducesResponseType(200, Type = typeof(Person))]
        [ProducesResponseType(400)]

        public IActionResult GetPerson(int personId)
        {
            if (!_personRepository.PersonExists(personId))
            {
                return NotFound();
            }
            var person = _personRepository.GetPerson(personId);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(person);
        }

    }
}
