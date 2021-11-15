using Microsoft.EntityFrameworkCore.Migrations;

namespace AnimalAdoptionCenter.Data.Migrations
{
    public partial class RemovedEndHour : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ReservedHours_Events_EventId",
                table: "ReservedHours");

            migrationBuilder.DropIndex(
                name: "IX_ReservedHours_EventId",
                table: "ReservedHours");

            migrationBuilder.DropColumn(
                name: "EventId",
                table: "ReservedHours");

            migrationBuilder.DropColumn(
                name: "EndHour",
                table: "Events");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EventId",
                table: "ReservedHours",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EndHour",
                table: "Events",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_ReservedHours_EventId",
                table: "ReservedHours",
                column: "EventId");

            migrationBuilder.AddForeignKey(
                name: "FK_ReservedHours_Events_EventId",
                table: "ReservedHours",
                column: "EventId",
                principalTable: "Events",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
