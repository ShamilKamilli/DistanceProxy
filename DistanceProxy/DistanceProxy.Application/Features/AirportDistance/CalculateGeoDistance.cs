
namespace DistanceProxy.Application.Features.AirportDistance
{
    public class CalculateGeoDistance : ICalculateGeoDistance
    {
        private const double EarthRadiusKm = 6371.0;
        private const double kmToMile = 0.621371;

        public double CalculateDistance(double latitudeFirst, double longitudeFirst,
                                       double latitudeSecond, double longitudeSecond)
        {
            double latFirstRad = DegreesToRadians(latitudeFirst);
            double lonFirstRad = DegreesToRadians(longitudeFirst);
            double latSecondRad = DegreesToRadians(latitudeSecond);
            double lonSecondRad = DegreesToRadians(longitudeSecond);

            double deltaLat = latSecondRad - latFirstRad;
            double deltaLon = lonSecondRad - lonFirstRad;

            double chordLength = Math.Sin(deltaLat / 2) * Math.Sin(deltaLat / 2) +
                  Math.Cos(latFirstRad) * Math.Cos(latSecondRad) *
                  Math.Sin(deltaLon / 2) * Math.Sin(deltaLon / 2);

            double angularDistance = 2 * Math.Atan2(Math.Sqrt(chordLength), Math.Sqrt(1 - chordLength));

            return EarthRadiusKm * EarthRadiusKm * kmToMile;
        }

        private static double DegreesToRadians(double degrees)
        {
            return degrees * (Math.PI / 180);
        }


    }
}
