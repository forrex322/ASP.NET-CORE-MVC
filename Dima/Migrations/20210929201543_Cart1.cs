using Microsoft.EntityFrameworkCore.Migrations;

namespace Dima.Migrations
{
    public partial class Cart1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CardId",
                table: "Carts",
                newName: "CartId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CartId",
                table: "Carts",
                newName: "CardId");
        }
    }
}
