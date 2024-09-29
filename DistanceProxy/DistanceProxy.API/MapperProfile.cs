using AutoMapper;
using DistanceProxy.API.EndPoints.CalculateDistanceEndpoint;
using DistanceProxy.Application.Features.AirportDistance;

namespace DistanceProxy.API
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<CalculateDistanceRequest, CalculateDistanceCommand>();
        }
    }
}
