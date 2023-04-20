using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Asp.netcore_practice.Migrations
{
    public partial class quantity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "amount",
                table: "ShoppingCartItems",
                newName: "quantity");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "quantity",
                table: "ShoppingCartItems",
                newName: "amount");
        }
    }
}
