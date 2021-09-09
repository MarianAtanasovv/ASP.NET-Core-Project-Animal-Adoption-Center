using Microsoft.EntityFrameworkCore.Migrations;

namespace AnimalAdoptionCenter.Data.Migrations
{
    public partial class Dogs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Images_Animals_AnimalId",
                table: "Images");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Animals",
                table: "Animals");

            migrationBuilder.RenameTable(
                name: "Animals",
                newName: "Dogs");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Dogs",
                table: "Dogs",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Images_Dogs_AnimalId",
                table: "Images",
                column: "AnimalId",
                principalTable: "Dogs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Images_Dogs_AnimalId",
                table: "Images");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Dogs",
                table: "Dogs");

            migrationBuilder.RenameTable(
                name: "Dogs",
                newName: "Animals");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Animals",
                table: "Animals",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Images_Animals_AnimalId",
                table: "Images",
                column: "AnimalId",
                principalTable: "Animals",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
