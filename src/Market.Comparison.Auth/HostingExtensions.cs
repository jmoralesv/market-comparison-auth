using Duende.IdentityServer;
using Market.Comparison.Auth.Data.Contexts;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace Market.Comparison.Auth;

internal static class HostingExtensions
{
    internal static WebApplication ConfigureServices(this WebApplicationBuilder builder)
    {
        var migrationsAssembly = typeof(CustomConfigurationDbContext).Assembly.GetName().Name;
        var connectionString = builder.Configuration.GetConnectionString("AuthConnection");

        builder.Services.AddRazorPages();

        builder.Services.AddIdentityServer()
            .AddConfigurationStore<CustomConfigurationDbContext>(options =>
            {
                options.ConfigureDbContext = b => b.UseSqlServer(connectionString,
                    sql => sql.MigrationsAssembly(migrationsAssembly));
            })
            .AddOperationalStore(options =>
            {
                options.ConfigureDbContext = b => b.UseSqlServer(connectionString,
                    sql => sql.MigrationsAssembly(migrationsAssembly));
            })
            .AddTestUsers(TestUsers.Users);

        builder.Services.AddAuthentication()
            .AddGoogle(GoogleDefaults.AuthenticationScheme, options =>
            {
                options.SignInScheme = IdentityServerConstants.ExternalCookieAuthenticationScheme;

                options.ClientId = builder.Configuration["Authentication:Google:ClientId"]!;
                options.ClientSecret = builder.Configuration["Authentication:Google:ClientSecret"]!;
            })
            .AddOpenIdConnect("oidc", "Demo IdentityServer", options =>
            {
                options.SignInScheme = IdentityServerConstants.ExternalCookieAuthenticationScheme;
                options.SignOutScheme = IdentityServerConstants.SignoutScheme;
                options.SaveTokens = true;

                options.Authority = "https://demo.duendesoftware.com";
                options.ClientId = "interactive.confidential";
                options.ClientSecret = "secret";
                options.ResponseType = "code";

                options.TokenValidationParameters = new TokenValidationParameters
                {
                    NameClaimType = "name",
                    RoleClaimType = "role"
                };
            });

        return builder.Build();
    }

    internal static WebApplication ConfigurePipeline(this WebApplication app)
    {
        if (app.Environment.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }

        app.UseHttpsRedirection();
        app.UseStaticFiles();
        app.UseRouting();
        app.UseIdentityServer();
        app.UseAuthorization();
        app.MapRazorPages()
            .RequireAuthorization();

        return app;
    }
}
