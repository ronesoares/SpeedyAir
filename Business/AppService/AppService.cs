using Business.Interface;

namespace Business.AppService
{
    public class AppService<TRequest, TResponse> : IAppService<TRequest, TResponse>
        where TRequest : class
        where TResponse : class
    {
        public AppService()
        {   
        }

        public TResponse Process(TRequest request)
        {
            TResponse response = Insert(request);

            return response;
        }

        protected virtual TResponse Insert(TRequest request)
        {
            TResponse? response = null;
            return response;
        }
    }
}
