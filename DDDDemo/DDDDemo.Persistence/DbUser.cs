using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDDDemo.Persistence
{
    public class DbUser
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public string StreetName { get; set; }
        public string StreetNumber { get; set; }

        public DbUser(int id, string firstName, string lastName, string password, string city, string postalCode, string streetName, string streetNumber)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Password = password;
            City = city;
            PostalCode = postalCode;
            StreetName = streetName;
            StreetNumber = streetNumber;
        }
    }
}
