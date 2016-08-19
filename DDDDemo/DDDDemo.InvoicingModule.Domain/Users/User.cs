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
        public string FirstName { get; set; }
        public string LastName { get; set; }


        public string City { get; private set; }
        public string PostalCode { get; private set; }
        public string StreetName { get; private set; }
        public string StreetNumber { get; private set; }

        public Address GetAddress()
        {
            return new Address
            {
                City = City,
                PostalCode = PostalCode,
                StreetName = StreetName,
                StreetNumber = StreetNumber
            };
        }

        public void UpdateAddress(Address newAddress)
        {
            if (!newAddress.AllFiledsAreFilled())
                throw new DomainInvariantException("All fileds should be filled in!");

            City = newAddress.City;
            PostalCode = newAddress.PostalCode;
            StreetName = newAddress.StreetName;
            StreetNumber = newAddress.StreetNumber;
        }
    }
}
