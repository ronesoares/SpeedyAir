namespace Business.Interface
{
    public interface IAppService<TRequest, TResponse>
        where TRequest : class
        where TResponse : class
    {
        TResponse Process(TRequest request);
    }
}
