using CSharpFunctionalExtensions;
using DistanceProxy.Infrastructure.AirportInfoIntegration.Models.Response;
using Newtonsoft.Json;
using DistanceProxyCommonConstant = DistanceProxy.Common.Constants;

namespace DistanceProxy.Infrastructure.AirportInfoIntegration
{
    public class AirportInfoService : IAirportInfoService, IDisposable
    {
        private readonly IHttpClientFactory? _httpClientFactory;
        private readonly HttpClient _httpClient;

        public AirportInfoService(IHttpClientFactory? httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
            _httpClient = _httpClientFactory != null ?
                 _httpClientFactory.CreateClient(DistanceProxyCommonConstant.AirportPlacesClientName) :
                 new HttpClient()
                 {
                     BaseAddress = new Uri(DistanceProxyCommonConstant.AirportPlacesUrl)
                 };
        }

        public async Task<IResult<AirportInfo>> Get(string iata)
        {
            string urlPath = $"/airports/{iata}";

            var response = await _httpClient.GetAsync(urlPath);

            if (!response.IsSuccessStatusCode)
            {
                string errorMessage = $"{_httpClient.BaseAddress!.AbsoluteUri} responsed error";
                //to do logger
                return Result.Failure<AirportInfo>(errorMessage);
            }

            var jsonResult = await response.Content.ReadAsStringAsync();

            return Result.Success<AirportInfo>(JsonConvert.DeserializeObject<AirportInfo>(jsonResult)!);
        }

        public void Dispose()
        {
            _httpClient?.Dispose();
        }
    }
}
