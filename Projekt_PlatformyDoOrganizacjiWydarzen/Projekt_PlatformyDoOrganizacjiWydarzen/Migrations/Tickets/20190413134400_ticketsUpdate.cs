using Microsoft.EntityFrameworkCore.Migrations;

namespace Projekt_PlatformyDoOrganizacjiWydarzen.Migrations.Tickets
{
    public partial class ticketsUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "username",
                table: "TicketsModel",
                newName: "user_surname");

            migrationBuilder.AddColumn<string>(
                name: "user_mail",
                table: "TicketsModel",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "user_name",
                table: "TicketsModel",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "user_mail",
                table: "TicketsModel");

            migrationBuilder.DropColumn(
                name: "user_name",
                table: "TicketsModel");

            migrationBuilder.RenameColumn(
                name: "user_surname",
                table: "TicketsModel",
                newName: "username");
        }
    }
}
