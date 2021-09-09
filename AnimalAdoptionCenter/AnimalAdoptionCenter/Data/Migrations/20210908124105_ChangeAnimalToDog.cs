using Microsoft.EntityFrameworkCore.Migrations;

namespace AnimalAdoptionCenter.Data.Migrations
{
    public partial class ChangeAnimalToDog : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Type",
                table: "Animals");

            migrationBuilder.AddColumn<string>(
                name: "Health",
                table: "Animals",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Health",
                table: "Animals");

            migrationBuilder.AddColumn<int>(
                name: "Type",
                table: "Animals",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
