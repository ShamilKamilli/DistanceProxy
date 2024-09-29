
using Newtonsoft.Json;

namespace DistanceProxy.Infrastructure.AirportInfoIntegration.Models.Response
{
    public record AirportInfo
    {
        public string Iata { get; set; }
        public string Name { get; set; }
        public string City { get; set; }

        [JsonProperty("city_iata")]
        public string CityIata { get; set; }
        public string Country { get; set; }

        [JsonProperty("country_iata")]
        public string CountryIata { get; set; }
        public AirportLocation Location { get; set; }
        public int Rating { get; set; }
        public int Hubs { get; set; }
        public string TimezoneRegionName { get; set; }
        public string Type { get; set; }
    }
}
