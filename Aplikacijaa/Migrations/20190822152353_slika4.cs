using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Aplikacijaa.Migrations
{
    public partial class slika4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Proof",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    TutorRegistrationFormId = table.Column<int>(nullable: false),
                    PictureName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Proof", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Proof_TutorRegistrationForm_TutorRegistrationFormId",
                        column: x => x.TutorRegistrationFormId,
                        principalTable: "TutorRegistrationForm",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Proof_TutorRegistrationFormId",
                table: "Proof",
                column: "TutorRegistrationFormId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Proof");
        }
    }
}
