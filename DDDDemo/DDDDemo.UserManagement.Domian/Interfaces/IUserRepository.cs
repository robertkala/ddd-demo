using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DDDDemo.UserManagement.Domian.Users;

namespace DDDDemo.UserManagement.Domian.Interfaces
{
    public interface IUserRepository
    {
        User Get(int id);
        int Add(User user);
        void Update(User user);
    }
}
