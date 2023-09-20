using Duende.IdentityServer.Models;

namespace Market.Comparison.Auth;

public static class Config
{
    private const string MarketComparisonApiScope = "Market.Comparison.Api";

    public static IEnumerable<ApiScope> ApiScopes =>
        new List<ApiScope>
        {
            new ApiScope(MarketComparisonApiScope, "Market Comparison API")
        };

    public static IEnumerable<Client> Clients =>
        new List<Client>
        {
            new Client
            {
                ClientId = "client",
                AllowedGrantTypes = GrantTypes.ClientCredentials,// no interactive user, use the clientid/secret for authentication
                ClientSecrets =
                {
                    new Secret("secret".Sha256())// secret for authentication
                },
                AllowedScopes = { MarketComparisonApiScope }// scopes that client has access to
            }
        };
}
