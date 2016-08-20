using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DDDDemo.InvoicingModule.Domain.Interfaces;
using DDDDemo.InvoicingModule.Domain.Users;

namespace DDDDemo.InvoicingModule.Infrastructure.Persistence.Users
{
    public class UserRepository : IUserRepository
    {
        public User Get(int id)
        {
            throw new NotImplementedException();
        }
    }
}
