using CSharpFunctionalExtensions;
using DistanceProxy.Infrastructure.AirportInfoIntegration.Models.Response;

namespace DistanceProxy.Infrastructure.AirportInfoIntegration
{
    public interface IAirportInfoService
    {
        Task<IResult<AirportInfo>> Get(string iata);
    }
}
