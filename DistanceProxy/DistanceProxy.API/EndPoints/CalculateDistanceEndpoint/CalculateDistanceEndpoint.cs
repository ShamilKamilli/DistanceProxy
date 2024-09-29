using Carter;
using MediatR;
using AutoMapper;
using DistanceProxy.Application.Features.AirportDistance;

namespace DistanceProxy.API.EndPoints.CalculateDistanceEndpoint
{
    public class CalculateDistanceEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPost("/calculatedistance", 
                async (CalculateDistanceRequest calculateDistance, 
                ISender sender,
                IMapper mapper) =>
            {

                var command = mapper.Map<CalculateDistanceCommand>(calculateDistance);
                var response = await sender.Send(command);

                if (!response.IsSuccess)
                {
                    return Results.Problem();
                }

                return Results.Json(response.Value);
            });
        }
    }
}
