using Business.Interface;
using Business.Parameter;
using Business.Response;
using Domain.Entity;

namespace Business.AppService
{
    public class FlightAppService : AppService<FlightParameter, FlightResponse>, IFlightAppService
    {
        public FlightAppService() : base()
        {
        }

        protected override FlightResponse Insert(FlightParameter request)
        {
            var response = new FlightResponse();

            var YUL = new Airport("YUL", "Montreal");
            var YYZ = new Airport("YYZ", "Toronto");
            var YYC = new Airport("YYC", "Calgary");
            var YVR = new Airport("YVR", "Vancouver");

            int flightNumber = 1;

            for (int i = 1; i <= request.Day; i++)
            {
                response.Flights.Add(new Flight(flightNumber++, i, YUL, YYZ, 20));
                response.Flights.Add(new Flight(flightNumber++, i, YUL, YYC, 20));
                response.Flights.Add(new Flight(flightNumber++, i, YUL, YVR, 20));
            }

            return response;
        }
    }
}