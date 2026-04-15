namespace WebApp.Data
{
    public interface IWebApiExcuter
    {
        Task<T?> InvokeGet<T>(string relativeUrl);
        Task<T?> InvokePost<T>(string relativeUrl, T obj);
    }
}