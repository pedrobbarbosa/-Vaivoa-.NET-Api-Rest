 using System;
using System.ComponentModel.DataAnnotations;

namespace VaiVoaApiRest.Models
{
    public class Person
    {
        [Key]
        public Guid Id { get; set; }
        public Guid VirtualCreditCard { get; set;}
        [Required]
        public string Email { get; set; 
        }
    }
}
