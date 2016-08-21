using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDDDemo.UserManagement.Domain.Interfaces
{
    public interface IPasswordStrengthPolicyProvider
    {
        IPasswordStrengthPolicy GetAdminPolicy();
        IPasswordStrengthPolicy GetUserPolicy();
    }
}
