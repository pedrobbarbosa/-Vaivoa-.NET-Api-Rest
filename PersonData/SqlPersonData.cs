
using System;
using System.Collections.Generic;
using System.Linq;
using VaiVoaApiRest.Models;

namespace VaiVoaApiRest.PersonData
{
    public class SqlPersonData : IPersonData
    {
        private PersonContext _personContext;

        public SqlPersonData(PersonContext personContext)
        {
            _personContext = personContext;
        }
        public Person AddPerson(Person person)
        {
            person.Id = Guid.NewGuid();
            person.VirtualCreditCard = Guid.NewGuid();
            _personContext.Persons.Add(person);
            _personContext.SaveChanges();
            return person;
        }

        public void DeletePerson(Person person)
        {
           _personContext.Persons.Remove(person);
            _personContext.SaveChanges();
        }

        public Person EditPerson(Person person)
        {
            var existingPerson = _personContext.Persons.Find(person.Id);
            if(existingPerson != null )
            {
                existingPerson.Email = person.Email;
                _personContext.Persons.Update(person);
                _personContext.SaveChanges();
            }
            return person;
        }

        public Person GetPersonByEmail(string email)
        {
            return _personContext.Persons.SingleOrDefault(person => person.Email == email);
        }

        public Person GetPersonById(Guid Id)
        {
            return _personContext.Persons.SingleOrDefault(person => person.Id == Id);
        }

        public List<Person> GetPersons()
        {
            return _personContext.Persons.ToList();
        }
    }
}
