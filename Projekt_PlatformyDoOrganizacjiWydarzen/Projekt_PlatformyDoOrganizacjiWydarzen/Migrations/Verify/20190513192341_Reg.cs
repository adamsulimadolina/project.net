using Microsoft.EntityFrameworkCore.Migrations;

namespace Projekt_PlatformyDoOrganizacjiWydarzen.Migrations.Verify
{
    public partial class Reg : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Registered",
                table: "VerifyModel",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Registered",
                table: "VerifyModel");
        }
    }
}
