using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Aplikacijaa.Migrations
{
    public partial class database3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Subject",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subject", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Title",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    TitleName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Title", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Teacher",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FName = table.Column<string>(nullable: true),
                    LName = table.Column<string>(nullable: true),
                    DateOfBirth = table.Column<DateTime>(nullable: false),
                    DateAdded = table.Column<DateTime>(nullable: false),
                    ProfilePicture = table.Column<byte[]>(nullable: true),
                    CollageName = table.Column<string>(nullable: true),
                    Proof = table.Column<byte[]>(nullable: true),
                    Price = table.Column<decimal>(nullable: false),
                    ProfileInfoId = table.Column<int>(nullable: false),
                    TitleId = table.Column<int>(nullable: false),
                    ContactInfoId = table.Column<int>(nullable: false),
                    CityId = table.Column<int>(nullable: false),
                    SubjectId = table.Column<int>(nullable: false),
                    UserStatusId = table.Column<int>(nullable: false),
                    GenderId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teacher", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Teacher_City_CityId",
                        column: x => x.CityId,
                        principalTable: "City",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Teacher_Contact_ContactInfoId",
                        column: x => x.ContactInfoId,
                        principalTable: "Contact",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Teacher_Gender_GenderId",
                        column: x => x.GenderId,
                        principalTable: "Gender",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Teacher_ProfileInfo_ProfileInfoId",
                        column: x => x.ProfileInfoId,
                        principalTable: "ProfileInfo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Teacher_Subject_SubjectId",
                        column: x => x.SubjectId,
                        principalTable: "Subject",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Teacher_Title_TitleId",
                        column: x => x.TitleId,
                        principalTable: "Title",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Teacher_UserStatus_UserStatusId",
                        column: x => x.UserStatusId,
                        principalTable: "UserStatus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Teacher_CityId",
                table: "Teacher",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_Teacher_ContactInfoId",
                table: "Teacher",
                column: "ContactInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_Teacher_GenderId",
                table: "Teacher",
                column: "GenderId");

            migrationBuilder.CreateIndex(
                name: "IX_Teacher_ProfileInfoId",
                table: "Teacher",
                column: "ProfileInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_Teacher_SubjectId",
                table: "Teacher",
                column: "SubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Teacher_TitleId",
                table: "Teacher",
                column: "TitleId");

            migrationBuilder.CreateIndex(
                name: "IX_Teacher_UserStatusId",
                table: "Teacher",
                column: "UserStatusId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Teacher");

            migrationBuilder.DropTable(
                name: "Subject");

            migrationBuilder.DropTable(
                name: "Title");
        }
    }
}
