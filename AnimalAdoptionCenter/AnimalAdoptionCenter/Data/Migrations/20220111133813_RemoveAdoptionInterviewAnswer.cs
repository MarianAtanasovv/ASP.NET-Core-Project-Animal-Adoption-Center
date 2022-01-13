using Microsoft.EntityFrameworkCore.Migrations;

namespace AnimalAdoptionCenter.Data.Migrations
{
    public partial class RemoveAdoptionInterviewAnswer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AdoptionInterviewAnswers");

            migrationBuilder.DropTable(
                name: "PotentialAdopters");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AdoptionInterviewAnswers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Answer = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SentOn = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdoptionInterviewAnswers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PotentialAdopters",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DogId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PotentialAdopters", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PotentialAdopters_Animals_DogId",
                        column: x => x.DogId,
                        principalTable: "Animals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PotentialAdopters_DogId",
                table: "PotentialAdopters",
                column: "DogId");
        }
    }
}
