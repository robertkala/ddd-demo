using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DDDDemo.UserManagement.Domian.Interfaces;

namespace DDDDemo.UserManagement.Domian.Users.Policies.PasswordStrength
{
    public class AdminPasswordStrengthPolicy : IPasswordStrengthPolicy
    {
        public bool IsPasswordGoodEnough(string password)
        {
            return password.Length >= 8;
        }
    }
}
