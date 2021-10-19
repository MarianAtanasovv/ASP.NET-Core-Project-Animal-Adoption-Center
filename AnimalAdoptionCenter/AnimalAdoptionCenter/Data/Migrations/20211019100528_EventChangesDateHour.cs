using Microsoft.EntityFrameworkCore.Migrations;

namespace AnimalAdoptionCenter.Data.Migrations
{
    public partial class EventChangesDateHour : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "StartTime",
                table: "Events",
                newName: "Hour");

            migrationBuilder.RenameColumn(
                name: "EndTime",
                table: "Events",
                newName: "Date");

            migrationBuilder.AddColumn<string>(
                name: "FullName",
                table: "Events",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FullName",
                table: "Events");

            migrationBuilder.RenameColumn(
                name: "Hour",
                table: "Events",
                newName: "StartTime");

            migrationBuilder.RenameColumn(
                name: "Date",
                table: "Events",
                newName: "EndTime");
        }
    }
}
