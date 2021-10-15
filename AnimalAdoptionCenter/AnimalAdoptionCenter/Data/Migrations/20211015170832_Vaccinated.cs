using Microsoft.EntityFrameworkCore.Migrations;

namespace AnimalAdoptionCenter.Data.Migrations
{
    public partial class Vaccinated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Vaccinated",
                table: "Dogs",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Vaccinated",
                table: "Dogs");
        }
    }
}
