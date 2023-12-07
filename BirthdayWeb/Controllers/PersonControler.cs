using BirthdayWeb.Interfaces;
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
                return BadRequest(ModelState);
            return Ok(people);
        }
    }
}
