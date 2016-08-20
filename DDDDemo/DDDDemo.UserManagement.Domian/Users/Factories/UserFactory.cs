using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using DDDDemo.SharedKernel;
using DDDDemo.SharedKernel.Interfaces;
using DDDDemo.UserManagement.Domain.Interfaces;
using DDDDemo.UserManagement.Domain.Users.Policies.PasswordStrength;

namespace DDDDemo.UserManagement.Domain.Users.Factories
{
    public class UserFactory
    {
        private readonly IGeocodingService _geocodingService;

        public UserFactory(IGeocodingService geocodingService)
        {
            _geocodingService = geocodingService;
        }

        public User CreateUser(string firstName, string lastName, string password, string city, string postalCode, string streetName, string streetNumber, string country)
        {
            var address = new Address(city,postalCode, streetName, streetNumber, country);

            var coordinates = _geocodingService.GetCoordinatesForLocation(address);

            IPasswordStrengthPolicy passwordStrengthPolicy = new UserPasswordStrengthPolicy();

            if (!passwordStrengthPolicy.IsPasswordGoodEnough(password))
            {
                throw new SecurityException("Too weak password");
            }

            var user = new User(null, firstName, lastName, password, address, coordinates);
            return user;
        }

        public User CreateAdmin(string firstName, string lastName, string password, string city, string postalCode, string streetName, string streetNumber, string country)
        {
            var address = new Address(city, postalCode, streetName, streetNumber, country);

            var coordinates = _geocodingService.GetCoordinatesForLocation(address);

            IPasswordStrengthPolicy passwordStrengthPolicy = new AdminPasswordStrengthPolicy();

            if (!passwordStrengthPolicy.IsPasswordGoodEnough(password))
            {
                throw new SecurityException("Too weak password");
            }

            var user = new User(null, firstName, lastName, password, address, coordinates);
            return user;
        }
    }
}
