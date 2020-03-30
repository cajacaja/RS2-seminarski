using Microsoft.EntityFrameworkCore.Migrations;

namespace Aplikacijaa.Migrations
{
    public partial class fix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ListOfStudents_Teacher_TeacherId",
                table: "ListOfStudents");

            migrationBuilder.RenameColumn(
                name: "TeacherId",
                table: "ListOfStudents",
                newName: "TutorRegistrationFormId");

            migrationBuilder.RenameIndex(
                name: "IX_ListOfStudents_TeacherId",
                table: "ListOfStudents",
                newName: "IX_ListOfStudents_TutorRegistrationFormId");

            migrationBuilder.AddForeignKey(
                name: "FK_ListOfStudents_TutorRegistrationForm_TutorRegistrationFormId",
                table: "ListOfStudents",
                column: "TutorRegistrationFormId",
                principalTable: "TutorRegistrationForm",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ListOfStudents_TutorRegistrationForm_TutorRegistrationFormId",
                table: "ListOfStudents");

            migrationBuilder.RenameColumn(
                name: "TutorRegistrationFormId",
                table: "ListOfStudents",
                newName: "TeacherId");

            migrationBuilder.RenameIndex(
                name: "IX_ListOfStudents_TutorRegistrationFormId",
                table: "ListOfStudents",
                newName: "IX_ListOfStudents_TeacherId");

            migrationBuilder.AddForeignKey(
                name: "FK_ListOfStudents_Teacher_TeacherId",
                table: "ListOfStudents",
                column: "TeacherId",
                principalTable: "Teacher",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
