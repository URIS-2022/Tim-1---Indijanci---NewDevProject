using Duende.IdentityServer.Models;
using Duende.IdentityServer;

namespace Licitacija.Services.Identity
{
    public class SD
    {
        public static IConfiguration config;
        private static string SecretKey;

        //public static void Initialze(IConfiguration Config)
        //{
        //    config = Config;
        //    SecretKey = config.GetSection("SecretKey").Value;
        //}

        public static IEnumerable<IdentityResource> IdentityResources => new List<IdentityResource>
        {
            new IdentityResources.OpenId(),
            new IdentityResources.Email(),
            new IdentityResources.Profile()
        };

        public static IEnumerable<ApiScope> ApiScopes => new List<ApiScope>
        {
            new ApiScope("licitacija", "Licitacija Server"),
            new ApiScope("read", "Read your data."),
            new ApiScope("write", "Write your data."),
            new ApiScope("delete", "Delete your data.")
        };

        public static IEnumerable<Client> Clients => new List<Client>
        {
            new Client
            {
                ClientId = "licitacija",
                AllowedGrantTypes = GrantTypes.Code,
                ClientSecrets = {new Secret("2124cf1f-bffd-444f-92bb-a6b78d0e3894".Sha256().Sha256())},
                AllowedScopes = new List<string>
                {
                    IdentityServerConstants.StandardScopes.OpenId,
                    IdentityServerConstants.StandardScopes.Profile,
                    IdentityServerConstants.StandardScopes.Email,
                    "licitacija"
                }
            },
        };
    }
}
