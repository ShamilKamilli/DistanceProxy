using DistanceProxy.Application.Features.AirportDistance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DistanceProxy.Application.UnitTests
{
    public class CalculateDistanceTest
    {
        private readonly ICalculateGeoDistance _calculateGeoDistance;
        public CalculateDistanceTest()
        {
            _calculateGeoDistance = new CalculateGeoDistance();
        }

        [Fact]
        public async Task CalculateDistance_Valid()
        {
            var firstLat = 52.309069;
            var firstLon = 4.76338;
            var secondLat = 40.485;
            var secondLon = 49.983611;

            var result = _calculateGeoDistance.CalculateDistance(firstLat, firstLon, secondLat, secondLon);

            Assert.Equal(result, 25221225.817811);
            Assert.NotEqual(result, 25221227.817811);
        }
    }
}
