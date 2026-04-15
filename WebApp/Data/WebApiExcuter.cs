namespace WebApp.Data
{
    public class WebApiExcuter : IWebApiExcuter
    {
        private const string apiName = "ShirtsApi";
        private readonly IHttpClientFactory _httpClientFactory;

        public WebApiExcuter(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<T?> InvokeGet<T>(string relativeUrl)
        {
            var client = _httpClientFactory.CreateClient(apiName);
            return await client.GetFromJsonAsync<T>(relativeUrl);
        }
    }
}
