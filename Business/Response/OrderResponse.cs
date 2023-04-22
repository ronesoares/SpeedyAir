using Domain.Entity;

namespace Business.Response
{
    public class OrderResponse
    {
        public List<Order> Orders { get; set; }

        public OrderResponse() 
        {
            Orders = new List<Order>();
        }
    }
}
