using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DDDDemo.SharedKernel.Interfaces;

namespace DDDDemo.SharedKernel
{
    public class GeocodingServiceMock : IGeocodingService
    {
        public Coordinates GetCoordinatesForLocation(Address address)
        {
            var rnd = new Random();
            return new Coordinates(rnd.Next(), rnd.Next());
        }
    }
}
