using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DistanceProxy.Application.Features.AirportDistance
{
    public record CalculateDistanceResponse
    {
        public double Distance { get; set; }
    }
}
