using Microsoft.EntityFrameworkCore.Migrations;

namespace AnimalAdoptionCenter.Data.Migrations
{
    public partial class AdoptionInterviewDog : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AdoptionInterviews_AspNetUsers_UserId",
                table: "AdoptionInterviews");

            migrationBuilder.DropForeignKey(
                name: "FK_AdoptionInterviews_Dogs_DogId",
                table: "AdoptionInterviews");

            migrationBuilder.DropIndex(
                name: "IX_AdoptionInterviews_DogId",
                table: "AdoptionInterviews");

            migrationBuilder.DropIndex(
                name: "IX_AdoptionInterviews_UserId",
                table: "AdoptionInterviews");

            migrationBuilder.AddColumn<int>(
                name: "AdoptionInterviewId",
                table: "Dogs",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "AdoptionInterviews",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "AdoptionInterviews",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AdoptionInterviews_DogId",
                table: "AdoptionInterviews",
                column: "DogId");

            migrationBuilder.CreateIndex(
                name: "IX_AdoptionInterviews_UserId",
                table: "AdoptionInterviews",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_AdoptionInterviews_AspNetUsers_UserId",
                table: "AdoptionInterviews",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AdoptionInterviews_Dogs_DogId",
                table: "AdoptionInterviews",
                column: "DogId",
                principalTable: "Dogs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
