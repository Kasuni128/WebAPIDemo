namespace WebApp.Data
{
    public interface IWebApiExcuter
    {
        Task<T?> InvokeGet<T>(string relativeUrl);
    }
}