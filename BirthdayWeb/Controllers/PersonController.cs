using BirthdayWeb.Dto;
using BirthdayWeb.Interfaces;
using BirthdayWeb.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Diagnostics.Metrics;

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


        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreatePerson([FromBody] PersonDto personDto)
        {
            if (personDto == null)
                return BadRequest(ModelState);

            var existingPerson = _personRepository.GetAllPeople()
                .FirstOrDefault(c => c.FirstName.Trim().ToUpper() == personDto.FirstName.Trim().ToUpper() &&
                                    c.LastName.Trim().ToUpper() == personDto.LastName.Trim().ToUpper());

            if (existingPerson != null)
            {
                ModelState.AddModelError("", "Person with the same first name and last name already exists");
                return StatusCode(422, ModelState);
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var personToCreate = new Person
            {
                FirstName = personDto.FirstName,
                LastName = personDto.LastName,
                BirthDate = personDto.BirthDate
            };

            if (!_personRepository.CreatePerson(personToCreate))
            {
                ModelState.AddModelError("", $"Something went wrong saving {personToCreate.FirstName} {personToCreate.LastName}");
                return StatusCode(500, ModelState);
            }

            return Ok("Successfully created");
        }

        //update person
        [HttpPut("{personId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]

        public IActionResult UpdatePerson(int personId, [FromBody] PersonDto personDto)
        {
            Debug.WriteLine("something");
            if (personDto == null)
            {
                return BadRequest(ModelState);
            }

            //if (personId != personDto.Id)
            //{
            //    return BadRequest(ModelState);
            //}

            var person = _personRepository.GetPerson(personId);
            if (person == null)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            person.FirstName = personDto.FirstName;
            person.LastName = personDto.LastName;
            person.BirthDate = personDto.BirthDate;

            if (!_personRepository.UpdatePerson(person))
            {
                ModelState.AddModelError("", $"Something went wrong updating {person.FirstName} {person.LastName}");
                return StatusCode(500, ModelState);
            }

            return Ok("Successfully updated");
        }

        //delete person
        [HttpDelete("{personId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult DeletePerson(int personId)
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

            if (!_personRepository.DeletePerson(person))
            {
                ModelState.AddModelError("", $"Something went wrong deleting {person.FirstName} {person.LastName}");
                return StatusCode(500, ModelState);
            }

            return Ok("Successfully deleted");
        }

    }
}
