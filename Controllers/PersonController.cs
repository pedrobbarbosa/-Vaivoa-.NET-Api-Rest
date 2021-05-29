using Microsoft.AspNetCore.Mvc;
using System;
using VaiVoaApiRest.PersonData;
using VaiVoaApiRest.Models;

namespace VaiVoaApiRest.Controllers
{
    [ApiController]
    public class PersonController : ControllerBase
    {
        private IPersonData _personData;

        public PersonController(IPersonData personData)
        {
            _personData = personData;
        }

        [HttpGet]
        [Route("api/[controller]")]
        public IActionResult GetPerson()
        {
            return Ok(_personData.GetPersons());
        }

        [HttpGet]
        [Route("api/[controller]/{id}")]
        public IActionResult GetPerson(Guid id)
        {
            var person = _personData.GetPersonById(id);
            if (person != null)
            {
                return Ok(person);
            }

            return NotFound($"Person with ID: {id} was not found");
        }

        [HttpPost]
        [Route("api/[controller]")]
        public IActionResult PostPerson(Person person)
        {
            var personEmail = _personData.GetPersonByEmail(person.Email);

            if (personEmail != null)
           {
                return BadRequest("Email already registered");
           }

            _personData.AddPerson(person);

            return Created(HttpContext.Request.Scheme + "://" + 
                HttpContext.Request.Host + HttpContext.Request.Path + "/" + person.Id, person);
        }

        [HttpDelete]
        [Route("api/[controller]/{id}")]
        public IActionResult DeletePerson(Guid id)
        {
            var person = _personData.GetPersonById(id);

            if (person != null)
            {
                _personData.DeletePerson(person);
                return Ok();
            } else {
            return NotFound($"{id} was not founded");
            }
        }

        [HttpPatch]
        [Route("api/[controller]/{id}")]
        public IActionResult PatchPerson(Guid id, Person person)
        {
            var personExists = _personData.GetPersonById(id);
            if (personExists != null)
            {
                person.Id = personExists.Id;
                _personData.EditPerson(personExists);
            }

            return Ok(person);

        }
    }
}
