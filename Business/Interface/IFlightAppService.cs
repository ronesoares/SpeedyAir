using Business.Parameter;
using Business.Response;

namespace Business.Interface
{
    public interface IFlightAppService : IAppService<FlightParameter, FlightResponse>
    {
    }
}
