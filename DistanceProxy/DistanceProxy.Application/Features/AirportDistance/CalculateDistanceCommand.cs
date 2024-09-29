using CSharpFunctionalExtensions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DistanceProxy.Application.Features.AirportDistance
{
    public record CalculateDistanceCommand : IRequest<IResult<CalculateDistanceResponse>>
    {
        public string FirstAirportIata { get; set; }
        public string SecondAirportIata { get; set; }
    }
}
