using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Projekt_PlatformyDoOrganizacjiWydarzen.Migrations.Tickets
{
    public partial class updatetickets : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "event_id",
                table: "TicketsModel",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "hour",
                table: "TicketsModel",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "name",
                table: "TicketsModel",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "place",
                table: "TicketsModel",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "username",
                table: "TicketsModel",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "event_id",
                table: "TicketsModel");

            migrationBuilder.DropColumn(
                name: "hour",
                table: "TicketsModel");

            migrationBuilder.DropColumn(
                name: "name",
                table: "TicketsModel");

            migrationBuilder.DropColumn(
                name: "place",
                table: "TicketsModel");

            migrationBuilder.DropColumn(
                name: "username",
                table: "TicketsModel");
        }
    }
}
