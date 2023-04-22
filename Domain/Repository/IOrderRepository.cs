using Domain.Entity;

namespace Domain.Repository
{
    public interface IOrderRepository
    {
        IQueryable<Order> GetAll();
    }
}
