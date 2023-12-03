using Duende.IdentityServer.EntityFramework.DbContexts;
using Market.Comparison.Auth.Data.Extensions;
using Microsoft.EntityFrameworkCore;

namespace Market.Comparison.Auth.Data.Contexts;

public class CustomConfigurationDbContext(DbContextOptions<ConfigurationDbContext> options) : ConfigurationDbContext(options)
{
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        ArgumentNullException.ThrowIfNull(modelBuilder);

        base.OnModelCreating(modelBuilder);

        modelBuilder.Seed();
    }
}
