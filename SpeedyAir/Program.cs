using Business.AppService;
using Business.Interface;
using Business.Parameter;
using Business.Response;
using Domain.Entity;
using Domain.Repository;
using Infra.Repository;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

internal class Program
{
    private static async Task Main(string[] args)
    {
        using IHost host = Host.CreateDefaultBuilder(args).
            ConfigureServices(services =>
            {
                services.AddTransient<IFlightAppService, FlightAppService>();
                services.AddTransient<IOrderAppService, OrderAppService>();
                services.AddScoped<IOrderRepository, OrderRepository>();
            }).
            Build();

        using IServiceScope serviceScope = host.Services.CreateScope();
        IServiceProvider provider = serviceScope.ServiceProvider;

        IFlightAppService flightAppService = provider.GetRequiredService<IFlightAppService>();
        IOrderAppService orderAppService = provider.GetRequiredService<IOrderAppService>();
        IOrderRepository orderRepository = provider.GetRequiredService<IOrderRepository>();

        await host.RunAsync();


        FlightResponse flightResponse = InitializeFlights(flightAppService);

        var orderParameter = new OrderParameter() { Flights = flightResponse.Flights };
        ProcessOrders(orderAppService, orderParameter);
    }

    private static FlightResponse InitializeFlights(IFlightAppService flightAppService)
    {
        const string _PrintFlight = "Flight: {0}, departure: {1}, arrival: {2}, day: {3}";

        var flightParameter = new FlightParameter() { Day = 2 };
        FlightResponse flightResponse = flightAppService.Process(flightParameter);

        foreach (Flight flight in flightResponse.Flights)
        {
            Console.WriteLine(string.Format(_PrintFlight,
                flight.Number,
                flight.Departure.Code,
                flight.Arrival.Code,
                flight.Day));
        }

        return flightResponse;
    }

    private static void ProcessOrders(IOrderAppService orderAppService, OrderParameter orderParameter)
    {
        const string _PrintOrderWithFlight = "Order: {0}, flightNumber: {1}, departure: {2}, arrival: {3}, day: {4}";
        const string _PrintOrderWithOutFlight = "Order: {0}, flightNumber: not scheduled";

        OrderResponse orderResponse = orderAppService.Process(orderParameter);

        foreach (Order order in orderResponse.Orders)
        {
            if (order.Flight != null)
            {
                Console.WriteLine(string.Format(_PrintOrderWithFlight,
                    order.Id,
                    order.Flight.Number,
                    order.Flight.Departure.Code,
                    order.Flight.Arrival.Code,
                    order.Flight.Day));
            }
            else
            {
                Console.WriteLine(string.Format(_PrintOrderWithOutFlight,
                    order.Id));
            }
            
        }
    }
}