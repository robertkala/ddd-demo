using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using DDDDemo.Persistence;
using DDDDemo.UserManagement.Domain.Users;
using DDDDemo.UserManagement.Infrastructure.Persistence.Users;
using NUnit.Framework;

namespace DDDDemo.UserManagement.Domain.Tests
{
    [TestFixture]
    public class UserTest
    {
        [Test]
        public void SetCorrectPassword()
        {
            var dbContext = new DbContext();
            var userRepository = new UserRepository(dbContext);
            var passwordPolicy = new PasswordPolicyMock();

            var user = userRepository.Get(1);
            var password = "DlugieHaslo";
            user.SetPassword(password, passwordPolicy);
            Assert.AreEqual(user.Password, password);
        }

        [Test]
        public void SetIncorrectPassword()
        {
            var dbContext = new DbContext();
            var userRepository = new UserRepository(dbContext);
            var passwordPolicy = new PasswordPolicyMock();

            var user = userRepository.Get(1);
            var password = "short";
            Assert.Throws(typeof (SecurityException), () => user.SetPassword(password, passwordPolicy));
        }
    }
}
