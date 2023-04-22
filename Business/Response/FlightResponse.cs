using Domain.Entity;

namespace Business.Response
{
    public class FlightResponse
    {
        public List<Flight> Flights { get; set; }

        public FlightResponse() 
        {
            Flights = new List<Flight>();
        }
    }
}
