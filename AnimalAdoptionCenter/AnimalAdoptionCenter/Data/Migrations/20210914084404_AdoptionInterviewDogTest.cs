using Microsoft.EntityFrameworkCore.Migrations;

namespace AnimalAdoptionCenter.Data.Migrations
{
    public partial class AdoptionInterviewDogTest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dogs_AdoptionInterviews_AdoptionInterviewId",
                table: "Dogs");

            migrationBuilder.DropIndex(
                name: "IX_Dogs_AdoptionInterviewId",
                table: "Dogs");

            migrationBuilder.DropColumn(
                name: "AdoptionInterviewId",
                table: "Dogs");

            migrationBuilder.CreateIndex(
                name: "IX_AdoptionInterviews_DogId",
                table: "AdoptionInterviews",
                column: "DogId");

            migrationBuilder.AddForeignKey(
                name: "FK_AdoptionInterviews_Dogs_DogId",
                table: "AdoptionInterviews",
                column: "DogId",
                principalTable: "Dogs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AdoptionInterviews_Dogs_DogId",
                table: "AdoptionInterviews");

            migrationBuilder.DropIndex(
                name: "IX_AdoptionInterviews_DogId",
                table: "AdoptionInterviews");

            migrationBuilder.AddColumn<int>(
                name: "AdoptionInterviewId",
                table: "Dogs",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Dogs_AdoptionInterviewId",
                table: "Dogs",
                column: "AdoptionInterviewId");

            migrationBuilder.AddForeignKey(
                name: "FK_Dogs_AdoptionInterviews_AdoptionInterviewId",
                table: "Dogs",
                column: "AdoptionInterviewId",
                principalTable: "AdoptionInterviews",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
