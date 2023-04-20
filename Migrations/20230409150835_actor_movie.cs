using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Asp.netcore_practice.Migrations
{
    public partial class actor_movie : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "id",
                table: "Actors_Movies");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "id",
                table: "Actors_Movies",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
