using Duende.IdentityServer.EntityFramework.Entities;
using Duende.IdentityServer.EntityFramework.Mappers;
using Market.Comparison.Auth.Data.DataLoading;
using Microsoft.EntityFrameworkCore;

namespace Market.Comparison.Auth.Data.Extensions;

internal static class DataLoadingExtensions
{
    internal static void Seed(this ModelBuilder modelBuilder)
    {
        var clients = Config.Clients.Select(x => x.ToEntity());
        var resources = Config.IdentityResources.Select(x => x.ToEntity());
        var scopes = Config.ApiScopes.Select(x => x.ToEntity());

        modelBuilder.Entity<Client>().HasData(clients);
        modelBuilder.Entity<IdentityResource>().HasData(resources);
        modelBuilder.Entity<ApiScope>().HasData(scopes);
    }
}
