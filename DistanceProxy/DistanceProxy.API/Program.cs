using Carter;
using DistanceProxy.API;
using DistanceProxy.Application.Features.AirportDistance;
using DistanceProxy.Common.Extensions;
using DistanceProxy.Common.Validators;
using DistanceProxy.Infrastructure.AirportInfoIntegration;
using FluentValidation;
using DistanceProxyCommonConstant = DistanceProxy.Common.Constants;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddMediatR(c =>
{
    c.RegisterServicesFromAssembly(typeof(ICalculateGeoDistance).Assembly);
    c.AddOpenBehavior(typeof(ValidatorPipelineBehaviour<,>));
});

builder.Services.AddAutoMapper(typeof(MapperProfile));

builder.Services.AddCarter();

builder.Services.AddValidatorsFromAssembly(typeof(ICalculateGeoDistance).Assembly);

builder.Services.AddDistanceApiHttpClient();

builder.Services.AddScoped<ICalculateGeoDistance, CalculateGeoDistance>();
builder.Services.AddScoped<IAirportInfoService, AirportInfoService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapCarter();

app.Run();
