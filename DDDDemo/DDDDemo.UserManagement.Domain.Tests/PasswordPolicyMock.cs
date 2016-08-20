﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DDDDemo.UserManagement.Domain.Interfaces;

namespace DDDDemo.UserManagement.Domain.Tests
{
    public class PasswordPolicyMock : IPasswordStrengthPolicy
    {
        public bool IsPasswordGoodEnough(string password)
        {
            return password.Length >= 6;
        }
    }
}
