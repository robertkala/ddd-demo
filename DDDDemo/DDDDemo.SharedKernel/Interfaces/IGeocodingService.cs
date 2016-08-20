using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDDDemo.SharedKernel.Interfaces
{
    public interface IGeocodingService
    {
        Coordinates GetCoordinatesForLocation(Address address);
    }
}
