namespace Licitacija.Services.Gateway
{
    public static class SD
    {
        public static string IdentityAPIBase { get; set; }
        public static string AdresaAPIBase { get; set; }
        public static string UplataAPIBase { get; set; }
        public static string PredradnjeNadmetanjaAPIBase { get; set; }
        public static string LicitacijaAPIBase { get; set; }

        public enum ApiType
        {
            GET,
            POST,
            PUT,
            DELETE
        }
    }
}
