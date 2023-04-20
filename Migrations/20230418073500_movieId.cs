using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Asp.netcore_practice.Migrations
{
    public partial class movieId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "id",
                table: "ShoppingCartItems",
                newName: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "ShoppingCartItems",
                newName: "id");
        }
    }
}
