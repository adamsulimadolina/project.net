using Microsoft.EntityFrameworkCore.Migrations;

namespace Projekt_PlatformyDoOrganizacjiWydarzen.Migrations.Tickets
{
    public partial class TicketsUpdate11 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "NIP",
                table: "TicketsModel",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "NIP",
                table: "TicketsModel",
                nullable: true,
                oldClrType: typeof(int));
        }
    }
}
