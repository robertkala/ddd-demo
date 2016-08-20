using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DDDDemo.Persistence;
using DDDDemo.UserManagement.Domain.Interfaces;
using DDDDemo.UserManagement.Domain.Users;

namespace DDDDemo.UserManagement.Infrastructure.Persistence.Users
{
    public class UserRepository : IUserRepository
    {
        public User Get(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(User user)
        {
            throw new NotImplementedException();
        }

        public int Add(User user)
        {
            throw new NotImplementedException();
        }
    }
}
