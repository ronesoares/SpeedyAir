using Business.Interface;
using Business.Parameter;
using Business.Response;
using Domain.Entity;
using Domain.Repository;

namespace Business.AppService
{
    public class OrderAppService : AppService<OrderParameter, OrderResponse>, IOrderAppService
    {
        private readonly IOrderRepository orderRepository;

        public OrderAppService(IOrderRepository orderRepository) : base()
        {
            this.orderRepository = orderRepository;
        }

        protected override OrderResponse Insert(OrderParameter request)
        {
            var response = new OrderResponse();

            response.Orders = orderRepository.GetAll().ToList();

            foreach (Order order in response.Orders)
            {
                Flight? flightSelected = request.Flights.
                    OrderBy(o => o.Day).
                    Where(x => x.Arrival.Code == order.Destination.Code && x.Capacity > 0).
                    FirstOrDefault();

                if (flightSelected != null)
                {
                    flightSelected.SetConsumeOneCapacity();

                    order.SetFlight(flightSelected);
                }
            }

            return response;
        }
    }
}
