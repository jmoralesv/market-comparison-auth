using Duende.IdentityServer.EntityFramework.Entities;
using Duende.IdentityServer.EntityFramework.Mappers;
using Market.Comparison.Auth.Data.DataLoading;
using Microsoft.EntityFrameworkCore;

namespace Market.Comparison.Auth.Data.Extensions;

internal static class DataLoadingExtensions
{
    internal static void Seed(this ModelBuilder modelBuilder)
    {
        // This is used to ensure that, in any future migration, the created date of initial data is not updated
        var initialDateTime = new DateTime(2023, 12, 3, 5, 14, 6, 262, DateTimeKind.Utc).AddTicks(6230);

        var clientGrantTypes = new List<ClientGrantType>();
        var clientSecrets = new List<ClientSecret>();
        var clientScopes = new List<ClientScope>();
        var clientRedirectUris = new List<ClientRedirectUri>();
        var clientPostLogoutRedirectUris = new List<ClientPostLogoutRedirectUri>();
        var identityResourceClaims = new List<IdentityResourceClaim>();

        var clients = Config.Clients
            .Select(x => x.ToEntity())
            .Select((item, i) =>
            {
                item.Id = i + 1;
                item.Created = initialDateTime;

                if (item.AllowedGrantTypes.Count != 0)
                {
                    item.AllowedGrantTypes = item.AllowedGrantTypes
                        .Select(agt => { agt.ClientId = item.Id; return agt; })
                        .ToList();

                    clientGrantTypes.AddRange(item.AllowedGrantTypes);
                }

                if (item.ClientSecrets.Count != 0)
                {
                    item.ClientSecrets = item.ClientSecrets
                        .Select(cs => { cs.ClientId = item.Id; cs.Created = initialDateTime; return cs; })
                        .ToList();

                    clientSecrets.AddRange(item.ClientSecrets);
                }

                if (item.AllowedScopes.Count != 0)
                {
                    item.AllowedScopes = item.AllowedScopes
                        .Select(s => { s.ClientId = item.Id; return s; })
                        .ToList();

                    clientScopes.AddRange(item.AllowedScopes);
                }

                if (item.RedirectUris.Count != 0)
                {
                    item.RedirectUris = item.RedirectUris
                        .Select(ru => { ru.ClientId = item.Id; return ru; })
                        .ToList();

                    clientRedirectUris.AddRange(item.RedirectUris);
                }

                if (item.PostLogoutRedirectUris.Count != 0)
                {
                    item.PostLogoutRedirectUris = item.PostLogoutRedirectUris
                        .Select(plru => { plru.ClientId = item.Id; return plru; })
                        .ToList();

                    clientPostLogoutRedirectUris.AddRange(item.PostLogoutRedirectUris);
                }

                item.AllowedGrantTypes = null;
                item.ClientSecrets = null;
                item.AllowedScopes = null;
                item.RedirectUris = null;
                item.PostLogoutRedirectUris = null;

                return item;
            })
            .ToList();

        clientGrantTypes = clientGrantTypes
            .Select((item, i) => { item.Id = i + 1; return item; })
            .ToList();

        clientSecrets = clientSecrets
            .Select((item, i) => { item.Id = i + 1; return item; })
            .ToList();

        clientScopes = clientScopes
            .Select((item, i) => { item.Id = i + 1; return item; })
            .ToList();

        clientRedirectUris = clientRedirectUris
            .Select((item, i) => { item.Id = i + 1; return item; })
            .ToList();

        clientPostLogoutRedirectUris = clientPostLogoutRedirectUris
            .Select((item, i) => { item.Id = i + 1; return item; })
            .ToList();

        var resources = Config.IdentityResources
            .Select(x => x.ToEntity())
            .Select((item, i) =>
            {
                item.Id = i + 1;
                item.Created = initialDateTime;

                if (item.UserClaims.Count != 0)
                {
                    item.UserClaims = item.UserClaims
                        .Select(uc => { uc.IdentityResourceId = item.Id; return uc; })
                        .ToList();

                    identityResourceClaims.AddRange(item.UserClaims);
                }

                item.UserClaims = null;

                return item;
            })
            .ToList();

        identityResourceClaims = identityResourceClaims
            .Select((item, i) => { item.Id = i + 1; return item; })
            .ToList();

        var scopes = Config.ApiScopes
            .Select(x => x.ToEntity())
            .Select((item, i) => { item.Id = i + 1; item.Created = initialDateTime; return item; })
            .ToList();

        modelBuilder.Entity<Client>().HasData(clients);
        modelBuilder.Entity<ClientGrantType>().HasData(clientGrantTypes);
        modelBuilder.Entity<ClientSecret>().HasData(clientSecrets);
        modelBuilder.Entity<ClientScope>().HasData(clientScopes);
        modelBuilder.Entity<ClientRedirectUri>().HasData(clientRedirectUris);
        modelBuilder.Entity<ClientPostLogoutRedirectUri>().HasData(clientPostLogoutRedirectUris);
        modelBuilder.Entity<IdentityResource>().HasData(resources);
        modelBuilder.Entity<IdentityResourceClaim>().HasData(identityResourceClaims);
        modelBuilder.Entity<ApiScope>().HasData(scopes);
    }
}
