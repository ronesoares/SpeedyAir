using Domain.Service;

namespace Domain.Entity
{
    public class Flight
    {
        public int Number { get; protected set; }
        public int Day { get; protected set; }
        public Airport Departure { get; protected set; }
        public Airport Arrival { get; protected set; }
        public int Capacity { get; protected set; }

        public Flight(int number, int day, Airport departure, Airport arrival, int capacity)
        {
            ValidationService.SetValue(number, "Number", 1, 6);
            ValidationService.SetValue(day, "Day", 1, 2);
            ValidationService.SetDuplication(departure.Code, arrival.Code, "Departure", "Arrival");
            ValidationService.SetValue(capacity, "Capacity", 0, 20);

            Number = number;
            Day = day;
            Departure = departure;
            Arrival = arrival;
            Capacity = capacity;
        }

        public void SetConsumeOneCapacity()
        {
            Capacity--;
        }
    }
}
