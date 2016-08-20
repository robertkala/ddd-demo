using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using DDDDemo.Common.Exceptions;
using DDDDemo.SharedKernel;
using DDDDemo.SharedKernel.Interfaces;
using DDDDemo.UserManagement.Domain.Interfaces;

namespace DDDDemo.UserManagement.Domain.Users
{
    public class User : BaseAggragate
    {
        public User(int? id, string firstName, string lastName, string password, Address address, Coordinates coordinates)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Password = password;
            Address = address;
            Coordinates = coordinates;

        }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string Password { get; private set; }

        public Address Address { get; private set; }
        public Coordinates Coordinates { get; private set; }

        public void SetPassword(string password, IPasswordStrengthPolicy passwordStrengthPolicy)
        {
            if (passwordStrengthPolicy.IsPasswordGoodEnough(password))
            {
                Password = password;
            }
            else
            {
                throw new SecurityException("Too weak password");
            }
        }

        public void SetNewAddress(Address address, IGeocodingService geocodingService)
        {
            Address = address;
            Coordinates = geocodingService.GetCoordinatesForLocation(Address);
        }

    }
}
