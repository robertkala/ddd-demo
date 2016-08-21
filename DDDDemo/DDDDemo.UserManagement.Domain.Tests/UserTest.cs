using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using DDDDemo.Persistence;
using DDDDemo.SharedKernel;
using DDDDemo.SharedKernel.Interfaces;
using DDDDemo.UserManagement.Domain.Interfaces;
using DDDDemo.UserManagement.Domain.Providers;
using DDDDemo.UserManagement.Domain.Users;
using DDDDemo.UserManagement.Infrastructure.Persistence.Users;
using NUnit.Framework;

namespace DDDDemo.UserManagement.Domain.Tests
{
    [TestFixture]
    public class UserTest
    {
        private IUserRepository _userRepository;
        private IPasswordStrengthPolicyProvider _passwordStrengthPolicyProvider;
        private IGeocodingService _geocodingService;
        [SetUp]
        public void Init()
        {
            var dbContext = new DbContext();
            _userRepository = new UserRepository(dbContext);
            _passwordStrengthPolicyProvider = new PasswordStrengthPolicyProvider();
            _geocodingService = new GeocodingServiceMock();
        }

        [Test]
        public void SetCorrectPassword()
        {
            var user = _userRepository.Get(1);
            var password = "DlugieHaslo";
            user.SetPassword(password, _passwordStrengthPolicyProvider.GetUserPolicy());
            Assert.AreEqual(user.Password, password);
        }

        [Test]
        public void SetIncorrectPassword()
        {
            var user = _userRepository.Get(1);
            var password = "short";
            Assert.Throws(typeof (SecurityException), () => user.SetPassword(password, _passwordStrengthPolicyProvider.GetUserPolicy()));
        }

        //Equality of value objects

        [Test]
        public void NotEqualAddresses()
        {
            var user = _userRepository.Get(1);
            var newAddress = user.Address.ChangeStreetNumber("5");
            Assert.AreNotEqual(newAddress, user.Address);
        }

        [Test]
        public void EqualAddresses()
        {
            var user = _userRepository.Get(1);
            var newAddress = user.Address;
            Assert.AreEqual(newAddress, user.Address);
        }

        [Test]
        public void ChangeCoordinatesDuringAddressChange()
        {
            var user = _userRepository.Get(1);
            var newAddress = user.Address.ChangeStreetNumber("5");
            var previousCoordinates = user.Coordinates;

            user.SetNewAddress(newAddress, _geocodingService);

            Assert.AreNotEqual(previousCoordinates, user.Coordinates);
        }
    }
}
