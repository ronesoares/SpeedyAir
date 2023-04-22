using Domain.Entity;
using Domain.Repository;

namespace Infra.Repository
{
    public class OrderRepository : BaseRepository<Order>, IOrderRepository
    {
        public OrderRepository() 
        {
            Load("Infra.File.coding-assigment-orders.json");
        }

        protected override void Mapping(dynamic list)
        {
            data.Clear();
            foreach (var item in list)
            {
                data.Add(new Order(
                    item.Path.ToString(), 
                    new Airport(item.Value.destination.ToString(), "Empty"), 
                    null));
            }
        }
    }
}