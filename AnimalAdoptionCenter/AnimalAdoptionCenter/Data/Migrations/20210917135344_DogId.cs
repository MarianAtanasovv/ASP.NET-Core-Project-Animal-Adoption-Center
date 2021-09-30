using Microsoft.EntityFrameworkCore.Migrations;

namespace AnimalAdoptionCenter.Data.Migrations
{
    public partial class DogId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DogId",
                table: "Dogs",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Dogs_DogId",
                table: "Dogs",
                column: "DogId");

            migrationBuilder.AddForeignKey(
                name: "FK_Dogs_Dogs_DogId",
                table: "Dogs",
                column: "DogId",
                principalTable: "Dogs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dogs_Dogs_DogId",
                table: "Dogs");

            migrationBuilder.DropIndex(
                name: "IX_Dogs_DogId",
                table: "Dogs");

            migrationBuilder.DropColumn(
                name: "DogId",
                table: "Dogs");
        }
    }
}
