using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VaiVoaApiRest.Models
{
    public class PersonContext: DbContext
    {
        public PersonContext(DbContextOptions<PersonContext> options): base(options)
        {

        }

        public DbSet<Person> Persons { get; set; }
    }
}
