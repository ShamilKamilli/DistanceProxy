using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DistanceProxy.Application.Features.AirportDistance
{
    public interface ICalculateGeoDistance
    {
        public double CalculateDistance(double latitudeFirst, double longitudeFirst,
                                       double latitudeSecond, double longitudeSecond);
    }
}
