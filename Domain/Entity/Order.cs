using Domain.Service;

namespace Domain.Entity
{
    public class Order
    {
        public string Id { get; protected set; }
        public Airport Destination { get; protected set; }
        public Flight? Flight { get; protected set; }

        public Order(string id, Airport destination, Flight? flight)
        {
            ValidationService.SetDescription(id, "Id", 9, 9);

            Id = id;
            Destination = destination;
            Flight = flight;
        }

        public void SetFlight(Flight flight)
        {
            Flight = flight;
        }
    }
}
