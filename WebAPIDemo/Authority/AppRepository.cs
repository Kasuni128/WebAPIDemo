namespace WebAPIDemo.Authority
{
    public static class AppRepository
    {
        private static readonly List<Application> applications = new List<Application>()
                {
                    new Application
                    {
                        AoolicationId = 1,
                        AoolicationName = "MVCWebApp",
                        clientId = "a481f6ab-4e72-4d0d-a957-45fcb71ac58c",
                        ClientSecret ="e7c088e1-959c-4c74-a730-73a137a50c74"
                    }
                };

        public static bool Authenticate(string clientId, string clientSecret)
        {
            return applications.Any(a => a.clientId == clientId && a.ClientSecret == clientSecret);
        }

        public static Application? GetApplicationByClientId(string clientId)
        {
            return applications.FirstOrDefault(a => a.clientId == clientId);
        }
    }
}
