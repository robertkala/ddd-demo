using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDDDemo.SharedKernel
{
    public class Address
    {
        public string City { get; set; }
        public string PostalCode { get; set; }
        public string StreetName { get; set; }
        public string StreetNumber { get; set; }

        protected bool Equals(Address other)
        {
            return string.Equals(City, other.City) &&
                   string.Equals(PostalCode, other.PostalCode) && string.Equals(StreetName, other.StreetName) &&
                   string.Equals(StreetNumber, other.StreetNumber);
        }

        public bool AllFiledsAreFilled()
            =>
                !string.IsNullOrEmpty(City) && !string.IsNullOrEmpty(PostalCode) &&
                !string.IsNullOrEmpty(StreetName) && !string.IsNullOrEmpty(StreetNumber);

        public override string ToString()
        {
            return $"{StreetName} {StreetNumber}, {PostalCode} {City}";
        }


    }
}
