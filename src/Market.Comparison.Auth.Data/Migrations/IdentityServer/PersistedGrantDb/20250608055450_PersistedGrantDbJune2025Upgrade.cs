﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Market.Comparison.Auth.Data.Migrations.IdentityServer.PersistedGrantDb
{
    /// <inheritdoc />
    public partial class PersistedGrantDbJune2025Upgrade : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ServerSideSessions",
                table: "ServerSideSessions");

            migrationBuilder.AlterColumn<long>(
                name: "Id",
                table: "ServerSideSessions",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ServerSideSessions",
                table: "ServerSideSessions",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "PushedAuthorizationRequests",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReferenceValueHash = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    ExpiresAtUtc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Parameters = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PushedAuthorizationRequests", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PushedAuthorizationRequests_ExpiresAtUtc",
                table: "PushedAuthorizationRequests",
                column: "ExpiresAtUtc");

            migrationBuilder.CreateIndex(
                name: "IX_PushedAuthorizationRequests_ReferenceValueHash",
                table: "PushedAuthorizationRequests",
                column: "ReferenceValueHash",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PushedAuthorizationRequests");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ServerSideSessions",
                table: "ServerSideSessions");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "ServerSideSessions",
                type: "int",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint")
                .Annotation("SqlServer:Identity", "1, 1")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ServerSideSessions",
                table: "ServerSideSessions",
                column: "Id");
        }
    }
}
