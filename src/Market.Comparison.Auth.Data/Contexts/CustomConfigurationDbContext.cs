using Duende.IdentityServer.EntityFramework.DbContexts;
using Market.Comparison.Auth.Data.Extensions;
using Microsoft.EntityFrameworkCore;

namespace Market.Comparison.Auth.Data.Contexts;

public class CustomConfigurationDbContext(DbContextOptions<CustomConfigurationDbContext> options)
    : ConfigurationDbContext<CustomConfigurationDbContext>(options)
{
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //Enable this to debug when adding a new migration
        //This is for the Seed method below
        //System.Diagnostics.Debugger.Launch();

        ArgumentNullException.ThrowIfNull(modelBuilder);

        base.OnModelCreating(modelBuilder);

        modelBuilder.Seed();
    }
}
