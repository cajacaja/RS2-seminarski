using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Aplikacijaa.Migrations
{
    public partial class slike : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Proof",
                table: "Teacher");

            migrationBuilder.AlterColumn<string>(
                name: "ProfilePicture",
                table: "Teacher",
                nullable: true,
                oldClrType: typeof(byte[]),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProofId",
                table: "Teacher",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Proof",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PictureName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Proof", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Teacher_ProofId",
                table: "Teacher",
                column: "ProofId");

            migrationBuilder.AddForeignKey(
                name: "FK_Teacher_Proof_ProofId",
                table: "Teacher",
                column: "ProofId",
                principalTable: "Proof",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Teacher_Proof_ProofId",
                table: "Teacher");

            migrationBuilder.DropTable(
                name: "Proof");

            migrationBuilder.DropIndex(
                name: "IX_Teacher_ProofId",
                table: "Teacher");

            migrationBuilder.DropColumn(
                name: "ProofId",
                table: "Teacher");

            migrationBuilder.AlterColumn<byte[]>(
                name: "ProfilePicture",
                table: "Teacher",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "Proof",
                table: "Teacher",
                nullable: true);
        }
    }
}
