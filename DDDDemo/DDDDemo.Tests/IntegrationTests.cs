using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DDDDemo.Common.Events;
using DDDDemo.ConsoleApplication.DIBootstrapper;
using DDDDemo.SharedKernel.Events;
using DDDDemo.UserManagement.Application.Users;
using NUnit.Framework;

namespace DDDDemo.Tests
{
    [TestFixture]
    public class IntegrationTests
    {
        private IUserService _userService;
        [SetUp]
        public void Init()
        {
            var container = new Bootstrapper().CreateContainer();
            _userService = container.Resolve<IUserService>();
        }


        [Test]
        public void VaildRequest()
        {
            var successRequest = new UserCreationRequest()
            {
                City = "Katowice",
                Country = "Polska",
                FirstName = "Adam",
                LastName = "Nowak",
                IsAdmin = false,
                Password = "1234567",
                PostalCode = "40-000",
                StreetName = "3 Maja",
                StreetNumber = "23"
            };

            var result = _userService.CreateUser(successRequest);

            Assert.That(result.Succeeded, Is.True);
        }

        [Test]
        public void InvaildRequestTooWeakPassword()
        {
            var successRequest = new UserCreationRequest()
            {
                City = "Katowice",
                Country = "Polska",
                FirstName = "Adam",
                LastName = "Nowak",
                IsAdmin = false,
                Password = "week",
                PostalCode = "40-000",
                StreetName = "3 Maja",
                StreetNumber = "23"
            };

            var result = _userService.CreateUser(successRequest);

            Assert.That(result.Succeeded, Is.False);
        }
    }
}
