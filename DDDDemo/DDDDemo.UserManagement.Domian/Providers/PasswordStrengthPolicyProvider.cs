using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DDDDemo.UserManagement.Domain.Interfaces;
using DDDDemo.UserManagement.Domain.Users.Policies.PasswordStrength;

namespace DDDDemo.UserManagement.Domain.Providers
{
    public class PasswordStrengthPolicyProvider : IPasswordStrengthPolicyProvider
    {
        public IPasswordStrengthPolicy GetAdminPolicy()
        {
            return new AdminPasswordStrengthPolicy();
        }

        public IPasswordStrengthPolicy GetUserPolicy()
        {
            return new UserPasswordStrengthPolicy();
        }
    }
}
