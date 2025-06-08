using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Market.Comparison.Auth.Data.Migrations.IdentityServer.ConfigurationDb
{
    /// <inheritdoc />
    public partial class June2025Upgrade : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PushedAuthorizationLifetime",
                table: "Clients",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "RequirePushedAuthorization",
                table: "Clients",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "ApiScopes",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2023, 12, 3, 5, 14, 6, 262, DateTimeKind.Utc).AddTicks(6230));

            migrationBuilder.UpdateData(
                table: "ClientSecrets",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2023, 12, 3, 5, 14, 6, 262, DateTimeKind.Utc).AddTicks(6230));

            migrationBuilder.UpdateData(
                table: "ClientSecrets",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2023, 12, 3, 5, 14, 6, 262, DateTimeKind.Utc).AddTicks(6230));

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PushedAuthorizationLifetime", "RefreshTokenUsage", "RequirePushedAuthorization" },
                values: new object[] { null, 0, false });

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Created", "PushedAuthorizationLifetime", "RefreshTokenUsage", "RequirePushedAuthorization" },
                values: new object[] { new DateTime(2023, 12, 3, 5, 14, 6, 262, DateTimeKind.Utc).AddTicks(6230), null, 0, false });

            migrationBuilder.UpdateData(
                table: "IdentityResources",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2023, 12, 3, 5, 14, 6, 262, DateTimeKind.Utc).AddTicks(6230));

            migrationBuilder.UpdateData(
                table: "IdentityResources",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2023, 12, 3, 5, 14, 6, 262, DateTimeKind.Utc).AddTicks(6230));

            migrationBuilder.UpdateData(
                table: "IdentityResources",
                keyColumn: "Id",
                keyValue: 3,
                column: "Created",
                value: new DateTime(2023, 12, 3, 5, 14, 6, 262, DateTimeKind.Utc).AddTicks(6230));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PushedAuthorizationLifetime",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "RequirePushedAuthorization",
                table: "Clients");

            migrationBuilder.UpdateData(
                table: "ApiScopes",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2023, 12, 3, 5, 14, 6, 262, DateTimeKind.Utc).AddTicks(7246));

            migrationBuilder.UpdateData(
                table: "ClientSecrets",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2023, 12, 3, 5, 14, 6, 262, DateTimeKind.Utc).AddTicks(6239));

            migrationBuilder.UpdateData(
                table: "ClientSecrets",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2023, 12, 3, 5, 14, 6, 262, DateTimeKind.Utc).AddTicks(6653));

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 1,
                column: "RefreshTokenUsage",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Created", "RefreshTokenUsage" },
                values: new object[] { new DateTime(2023, 12, 3, 5, 14, 6, 262, DateTimeKind.Utc).AddTicks(6652), 1 });

            migrationBuilder.UpdateData(
                table: "IdentityResources",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2023, 12, 3, 5, 14, 6, 262, DateTimeKind.Utc).AddTicks(6924));

            migrationBuilder.UpdateData(
                table: "IdentityResources",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2023, 12, 3, 5, 14, 6, 262, DateTimeKind.Utc).AddTicks(6959));

            migrationBuilder.UpdateData(
                table: "IdentityResources",
                keyColumn: "Id",
                keyValue: 3,
                column: "Created",
                value: new DateTime(2023, 12, 3, 5, 14, 6, 262, DateTimeKind.Utc).AddTicks(7176));
        }
    }
}
