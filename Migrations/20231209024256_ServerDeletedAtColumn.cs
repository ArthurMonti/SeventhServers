using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SeventhServers.Migrations
{
    public partial class ServerDeletedAtColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                table: "Server",
                type: "timestamp without time zone",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "Server");
        }
    }
}
