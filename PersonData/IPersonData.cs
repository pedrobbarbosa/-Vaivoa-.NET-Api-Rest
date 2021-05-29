using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VaiVoaApiRest.Models;

namespace VaiVoaApiRest.PersonData
{
   public interface IPersonData
    {
        List<Person> GetPersons();
        Person GetPersonById(Guid id);
        Person GetPersonByEmail(string email);
        Person AddPerson(Person person);
        void DeletePerson(Person person);
        Person EditPerson(Person person);


    }
}
