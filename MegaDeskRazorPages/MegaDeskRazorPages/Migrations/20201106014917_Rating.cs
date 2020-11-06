using Microsoft.EntityFrameworkCore.Migrations;

namespace MegaDeskRazorPages.Migrations
{
    public partial class Rating : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Drawers",
                table: "MegaDesk",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Drawers",
                table: "MegaDesk",
                nullable: true,
                oldClrType: typeof(int));
        }
    }
}
