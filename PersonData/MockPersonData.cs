using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VaiVoaApiRest.Models;

namespace VaiVoaApiRest.PersonData
{
    public class MockPersonData : IPersonData
    {
        private List<Person> persons = new List<Person>()
        {
            new Person()
            {
                Id = Guid.NewGuid(),
                Email = "email01@teste.com"
            },
            new Person()
            {
                Id = Guid.NewGuid(),
                Email = "email02@teste.com"
            }
        };

        public Person AddPerson(Person person)
        {
            person.Id = Guid.NewGuid();
            persons.Add(person);
            return person;
        }

        public void DeletePerson(Person person)
        {
            persons.Remove(person);
        }

        public Person EditPerson(Person person)
        {
            var personExists = GetPersonById(person.Id);
            personExists.Email = person.Email;
            return personExists;
        }

        public Person GetPersonById(Guid id)
        {
            return persons.SingleOrDefault(person => person.Id == id);
        }
        public Person GetPersonByEmail(string Email)
        {
            return persons.SingleOrDefault(person => person.Email == Email);
        }
        public List<Person> GetPersons()
        {
            return persons;
        }
    }
}
