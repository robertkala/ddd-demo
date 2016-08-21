using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDDDemo.SharedKernel
{
    public class Address
    {
        public Address(string city, string postalCode, string streetName, string streetNumber, string country)
        {
            City = city;
            Country = country;
            PostalCode = postalCode;
            StreetName = streetName;
            StreetNumber = streetNumber;
        }

        public string Country { get; }
        public string City { get; }
        public string PostalCode { get; }
        public string StreetName { get;  }
        public string StreetNumber { get; }

        protected bool Equals(Address other)
        {
            return string.Equals(Country, other.Country) && 
                string.Equals(City, other.City) && 
                string.Equals(PostalCode, other.PostalCode) && 
                string.Equals(StreetName, other.StreetName) && 
                string.Equals(StreetNumber, other.StreetNumber);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Address) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = (Country != null ? Country.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (City != null ? City.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (PostalCode != null ? PostalCode.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (StreetName != null ? StreetName.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (StreetNumber != null ? StreetNumber.GetHashCode() : 0);
                return hashCode;
            }
        }

        public bool AllFiledsAreFilled()
            =>
                !string.IsNullOrEmpty(Country) && !string.IsNullOrEmpty(City) && !string.IsNullOrEmpty(PostalCode) &&
                !string.IsNullOrEmpty(StreetName) && !string.IsNullOrEmpty(StreetNumber);

        public override string ToString()
        {
            return $"{StreetName} {StreetNumber}, {PostalCode} {City}";
        }

        public Address ChangeStreetNumber(string streetNumber)
        {
            return new Address(City, PostalCode, StreetName, streetNumber, Country);
        }

    }
}
