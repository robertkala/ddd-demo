using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DDDDemo.Common.Operations;

namespace DDDDemo.UserManagement.Application.Users
{
    public interface IUserService
    {
        Response CreateUser(UserCreationRequest userCreationRequest);
    }
}
