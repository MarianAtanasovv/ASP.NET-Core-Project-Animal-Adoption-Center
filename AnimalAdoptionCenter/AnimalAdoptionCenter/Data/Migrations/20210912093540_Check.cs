using Microsoft.EntityFrameworkCore.Migrations;

namespace AnimalAdoptionCenter.Data.Migrations
{
    public partial class Check : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PotentialAdopter_Dogs_DogId",
                table: "PotentialAdopter");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PotentialAdopter",
                table: "PotentialAdopter");

            migrationBuilder.RenameTable(
                name: "PotentialAdopter",
                newName: "PotentialAdopters");

            migrationBuilder.RenameIndex(
                name: "IX_PotentialAdopter_DogId",
                table: "PotentialAdopters",
                newName: "IX_PotentialAdopters_DogId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PotentialAdopters",
                table: "PotentialAdopters",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PotentialAdopters_Dogs_DogId",
                table: "PotentialAdopters",
                column: "DogId",
                principalTable: "Dogs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PotentialAdopters_Dogs_DogId",
                table: "PotentialAdopters");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PotentialAdopters",
                table: "PotentialAdopters");

            migrationBuilder.RenameTable(
                name: "PotentialAdopters",
                newName: "PotentialAdopter");

            migrationBuilder.RenameIndex(
                name: "IX_PotentialAdopters_DogId",
                table: "PotentialAdopter",
                newName: "IX_PotentialAdopter_DogId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PotentialAdopter",
                table: "PotentialAdopter",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PotentialAdopter_Dogs_DogId",
                table: "PotentialAdopter",
                column: "DogId",
                principalTable: "Dogs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
