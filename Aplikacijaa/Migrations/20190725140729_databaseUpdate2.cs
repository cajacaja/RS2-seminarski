using Microsoft.EntityFrameworkCore.Migrations;

namespace Aplikacijaa.Migrations
{
    public partial class databaseUpdate2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Student_ProfileInfo_ProfileInfoId",
                table: "Student");

            migrationBuilder.DropColumn(
                name: "ProfieInforId",
                table: "Student");

            migrationBuilder.AlterColumn<int>(
                name: "ProfileInfoId",
                table: "Student",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Student_ProfileInfo_ProfileInfoId",
                table: "Student",
                column: "ProfileInfoId",
                principalTable: "ProfileInfo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Student_ProfileInfo_ProfileInfoId",
                table: "Student");

            migrationBuilder.AlterColumn<int>(
                name: "ProfileInfoId",
                table: "Student",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "ProfieInforId",
                table: "Student",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Student_ProfileInfo_ProfileInfoId",
                table: "Student",
                column: "ProfileInfoId",
                principalTable: "ProfileInfo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
