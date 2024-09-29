using Microsoft.Extensions.DependencyInjection;
using DistanceProxyCommonConstant = DistanceProxy.Common.Constants;

namespace DistanceProxy.Common.Extensions
{
    public static class IServiceCollectionExtensions
    {
        public static void AddDistanceApiHttpClient(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddHttpClient(DistanceProxyCommonConstant.AirportPlacesClientName, client =>
            {
                client.BaseAddress = new Uri(DistanceProxyCommonConstant.AirportPlacesUrl);
            });
        }
    }
}
