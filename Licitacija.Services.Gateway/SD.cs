namespace Licitacija.Services.Gateway
{
    public static class SD
    {
        public static string IdentityAPIBase { get; set; }

        public enum ApiType
        {
            GET,
            POST,
            PUT,
            DELETE
        }
    }
}
