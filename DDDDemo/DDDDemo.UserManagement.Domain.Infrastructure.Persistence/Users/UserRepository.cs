using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DDDDemo.Persistence;
using DDDDemo.UserManagement.Domian.Interfaces;
using DDDDemo.UserManagement.Domian.Users;

namespace DDDDemo.UserManagement.Domain.Infrastructure.Persistence.Users
{
    public class UserRepository : IUserRepository
    {
        public User Get(int id)
        {
            throw new NotImplementedException();
        }

        public int Add(User user)
        {
            throw new NotImplementedException();
        }

        public void Update(User user)
        {
            throw new NotImplementedException();
        }
    }
}
