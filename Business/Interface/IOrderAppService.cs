using Business.Parameter;
using Business.Response;

namespace Business.Interface
{
    public interface IOrderAppService : IAppService<OrderParameter, OrderResponse>
    {
    }
}
