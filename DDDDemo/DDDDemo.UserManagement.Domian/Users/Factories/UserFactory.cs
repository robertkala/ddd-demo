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
        private readonly IPasswordStrengthPolicyProvider _passwordStrengthPolicyProvider;

        public UserFactory(IGeocodingService geocodingService, IPasswordStrengthPolicyProvider passwordStrengthPolicyProvider)
        {
            _geocodingService = geocodingService;
            _passwordStrengthPolicyProvider = passwordStrengthPolicyProvider;
        }

        public User CreateUser(string firstName, string lastName, string password, string city, string postalCode, string streetName, string streetNumber, string country)
        {
            var address = new Address(city,postalCode, streetName, streetNumber, country);

            var coordinates = _geocodingService.GetCoordinatesForLocation(address);

            var passwordStrengthPolicy = _passwordStrengthPolicyProvider.GetUserPolicy();

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

            var passwordStrengthPolicy = _passwordStrengthPolicyProvider.GetAdminPolicy();

            if (!passwordStrengthPolicy.IsPasswordGoodEnough(password))
            {
                throw new SecurityException("Too weak password");
            }

            var user = new User(null, firstName, lastName, password, address, coordinates);
            return user;
        }
    }
}
