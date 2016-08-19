using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DDDDemo.UserManagement.Domian.Interfaces;

namespace DDDDemo.UserManagement.Domian.User.Policies.PasswordStrength
{
    public class UserPasswordStrengthPolicy : IPasswordStrengthPolicy
    {
        public bool IsPasswordGoodEnough(string password)
        {
            return password.Length >= 6;
        }
    }
}
