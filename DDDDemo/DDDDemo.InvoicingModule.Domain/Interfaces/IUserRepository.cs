using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DDDDemo.InvoicingModule.Domain.Users;

namespace DDDDemo.InvoicingModule.Domain.Interfaces
{
    public interface IUserRepository
    {
        User Get(int id);
    }
}
