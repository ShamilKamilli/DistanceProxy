using CSharpFunctionalExtensions;
using DistanceProxy.Infrastructure.AirportInfoIntegration;
using MediatR;

namespace DistanceProxy.Application.Features.AirportDistance
{
    public class CalculateDistanceCommandHandler : IRequestHandler<CalculateDistanceCommand, IResult<CalculateDistanceResponse>>
    {
        private readonly IAirportInfoService _airportInfoService;
        private readonly ICalculateGeoDistance _calculateGeoDistance;

        public CalculateDistanceCommandHandler(IAirportInfoService airportInfoService,
            ICalculateGeoDistance calculateGeoDistance)
        {
            _airportInfoService = airportInfoService;
            _calculateGeoDistance = calculateGeoDistance;
        }

        public async Task<IResult<CalculateDistanceResponse>> Handle(CalculateDistanceCommand request
           , CancellationToken cancellationToken)
        {
            var firstAirportResul = await _airportInfoService.Get(request.FirstAirportIata);
            var secondAirportResul = await _airportInfoService.Get(request.SecondAirportIata);

            if (!firstAirportResul.IsSuccess || !secondAirportResul.IsSuccess)
            {
                //todo log
                return Result.Failure<CalculateDistanceResponse>("Error occured while getting airport information from service");
            }

            var result = _calculateGeoDistance.CalculateDistance(firstAirportResul.Value.Location.Lat,
                 firstAirportResul.Value.Location.Lon,
                 secondAirportResul.Value.Location.Lat,
                 secondAirportResul.Value.Location.Lon);

            return Result.Success<CalculateDistanceResponse>(new CalculateDistanceResponse()
            {
                Distance = result
            });
        }
    }
}
