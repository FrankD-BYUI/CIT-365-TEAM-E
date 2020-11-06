using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MegaDeskRazorPages.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MegaDesk",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    WidthDesk = table.Column<int>(nullable: false),
                    DepthDesk = table.Column<int>(nullable: false),
                    SizeDesk = table.Column<int>(nullable: false),
                    Drawers = table.Column<string>(nullable: true),
                    Material = table.Column<string>(nullable: true),
                    CustomerName = table.Column<string>(nullable: true),
                    RushDays = table.Column<string>(nullable: true),
                    QuoteDate = table.Column<DateTime>(nullable: false),
                    TotalCost = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MegaDesk", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MegaDesk");
        }
    }
}
