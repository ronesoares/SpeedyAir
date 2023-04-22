using Domain.Entity;

namespace Business.Parameter
{
    public class OrderParameter
    {
        public List<Flight> Flights { get; set; }

        public OrderParameter() 
        { 
            Flights = new List<Flight>();
        }
    }
}
