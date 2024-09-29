using DistanceProxy.Infrastructure.AirportInfoIntegration;

namespace DistanceProxy.Infrastructure.Integration.Tests
{
    public class AirportInfoTests
    {
        private readonly IAirportInfoService _airportInfoService;
        private readonly IList<Tuple<string, double, double>> addresses;
        public AirportInfoTests()
        {
            _airportInfoService = new AirportInfoService(null);
            addresses = new List<Tuple<string, double, double>>()
            {
                new Tuple<string, double,double>("AMS",4.763385,52.309069),
                new Tuple<string, double,double>("ZXT",49.983611,40.485)
            };
        }

        [Fact]
        public async Task AirportInfo_Get_ValidData_Tests()
        {
            foreach (var item in addresses)
            {
                var result = await _airportInfoService.Get(item.Item1);

                Assert.NotNull(result);
                Assert.True(result.IsSuccess);
                Assert.NotNull(result.Value.Location);

                Assert.Equal(result.Value.Location.Lon,item.Item2);
                Assert.Equal(result.Value.Location.Lat, item.Item3);
            }
        }

        [Fact]
        public async Task AirportInfo_Get_InValidData_Test()
        {
            var result = await _airportInfoService.Get("RFTG");

            Assert.NotNull(result);
            Assert.False(result.IsSuccess);
        }
    }
}
