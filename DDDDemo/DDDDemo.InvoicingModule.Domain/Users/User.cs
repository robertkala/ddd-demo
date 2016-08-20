using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using DDDDemo.Common.Exceptions;
using DDDDemo.SharedKernel;

namespace DDDDemo.InvoicingModule.Domain.Users
{
    public class User : BaseAggragate
    {
        public User(int id, string firstName, string lastName, Address address)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Address = address;

        }
        public string FirstName { get; }
        public string LastName { get; }
       
        public Address Address { get; }

        public override string ToString()
        {
            return $"FirstName: {FirstName}, LastName: {LastName}, Address: {Address}";
        }
    }
}
