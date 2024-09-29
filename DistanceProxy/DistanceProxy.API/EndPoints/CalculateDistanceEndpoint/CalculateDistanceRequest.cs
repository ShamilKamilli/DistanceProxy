namespace DistanceProxy.API.EndPoints.CalculateDistanceEndpoint
{
    public class CalculateDistanceRequest
    {
        public string FirstAirportIata { get; set; }

        public string SecondAirportIata { get; set; }
    }
}
