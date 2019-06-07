using Microsoft.EntityFrameworkCore.Migrations;

namespace Projekt_PlatformyDoOrganizacjiWydarzen.Migrations.Tickets
{
    public partial class TicketsUpdate6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "user_surname",
                table: "TicketsModel",
                nullable: true,
                oldClrType: typeof(string));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "user_surname",
                table: "TicketsModel",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
