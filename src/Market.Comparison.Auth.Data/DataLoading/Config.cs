using Duende.IdentityModel;
using Duende.IdentityServer;
using Duende.IdentityServer.Models;

namespace Market.Comparison.Auth.Data.DataLoading;

internal static class Config
{
    private const string MarketComparisonApiScope = "Market.Comparison.Api";
    private const string VerificationIdentityResource = "verification";

    internal static IEnumerable<IdentityResource> IdentityResources =>
        [
            new IdentityResources.OpenId(),
            new IdentityResources.Profile(),
            new()
            {
                Name = VerificationIdentityResource,
                UserClaims =
                [
                    JwtClaimTypes.Email,
                    JwtClaimTypes.EmailVerified
                ]
            }
        ];

    internal static IEnumerable<ApiScope> ApiScopes =>
        [
            new(MarketComparisonApiScope, "Market Comparison API")
        ];

    internal static IEnumerable<Client> Clients =>
        [
            new()
            {
                ClientId = "client",
                AllowedGrantTypes = GrantTypes.ClientCredentials,// no interactive user, use the clientid/secret for authentication
                ClientSecrets =
                {
                    new Secret("secret".Sha256())// secret for authentication
                },
                AllowedScopes = { MarketComparisonApiScope }// scopes that client has access to
            },
            // interactive ASP.NET Core Web App
            new()
            {
                ClientId = "web",
                ClientSecrets = { new Secret("secret".Sha256()) },

                AllowedGrantTypes = GrantTypes.Code,
            
                // where to redirect to after login
                RedirectUris = { "https://localhost:7102/signin-oidc" },

                // where to redirect to after logout
                PostLogoutRedirectUris = { "https://localhost:7102/signout-callback-oidc" },

                AllowOfflineAccess = true,

                AllowedScopes =
                [
                    IdentityServerConstants.StandardScopes.OpenId,
                    IdentityServerConstants.StandardScopes.Profile,
                    VerificationIdentityResource,
                    MarketComparisonApiScope,
                ]
            }
        ];
}
