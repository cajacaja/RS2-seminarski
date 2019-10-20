using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Aplikacijaa.Migrations
{
    public partial class _01 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FieldId",
                table: "Subject",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "AdministrastorRole",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdministrastorRole", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Field",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Field", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LandLord",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Fname = table.Column<string>(nullable: true),
                    LName = table.Column<string>(nullable: true),
                    DateOfBirth = table.Column<DateTime>(nullable: false),
                    DateAdded = table.Column<DateTime>(nullable: false),
                    ContactInfoId = table.Column<int>(nullable: false),
                    ProfileInfoId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LandLord", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LandLord_Contact_ContactInfoId",
                        column: x => x.ContactInfoId,
                        principalTable: "Contact",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LandLord_ProfileInfo_ProfileInfoId",
                        column: x => x.ProfileInfoId,
                        principalTable: "ProfileInfo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ListOfStudents",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    TeacherId = table.Column<int>(nullable: false),
                    StudentTypeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ListOfStudents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ListOfStudents_StudentType_StudentTypeId",
                        column: x => x.StudentTypeId,
                        principalTable: "StudentType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ListOfStudents_Teacher_TeacherId",
                        column: x => x.TeacherId,
                        principalTable: "Teacher",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ReportedStudent",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    TeacherId = table.Column<int>(nullable: false),
                    StudentId = table.Column<int>(nullable: false),
                    ResaonForReport = table.Column<string>(nullable: true),
                    DateOfReporting = table.Column<DateTime>(nullable: false),
                    IsRead = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReportedStudent", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReportedStudent_Student_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Student",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ReportedStudent_Teacher_TeacherId",
                        column: x => x.TeacherId,
                        principalTable: "Teacher",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ReportedTeacher",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    StudentId = table.Column<int>(nullable: false),
                    TeacherId = table.Column<int>(nullable: false),
                    DateOfReporting = table.Column<DateTime>(nullable: false),
                    IsRead = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReportedTeacher", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReportedTeacher_Student_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Student",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ReportedTeacher_Teacher_TeacherId",
                        column: x => x.TeacherId,
                        principalTable: "Teacher",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TutorRegistrationForm",
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
                    Username = table.Column<string>(nullable: true),
                    PasswordHash = table.Column<string>(nullable: true),
                    PasswordSalt = table.Column<string>(nullable: true),
                    TitleId = table.Column<int>(nullable: false),
                    ContactInfoId = table.Column<int>(nullable: false),
                    CityId = table.Column<int>(nullable: false),
                    SubjectId = table.Column<int>(nullable: false),
                    GenderId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TutorRegistrationForm", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TutorRegistrationForm_City_CityId",
                        column: x => x.CityId,
                        principalTable: "City",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TutorRegistrationForm_Contact_ContactInfoId",
                        column: x => x.ContactInfoId,
                        principalTable: "Contact",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TutorRegistrationForm_Gender_GenderId",
                        column: x => x.GenderId,
                        principalTable: "Gender",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TutorRegistrationForm_Subject_SubjectId",
                        column: x => x.SubjectId,
                        principalTable: "Subject",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TutorRegistrationForm_Title_TitleId",
                        column: x => x.TitleId,
                        principalTable: "Title",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TypeOfClass",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeOfClass", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Administrator",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FName = table.Column<string>(nullable: true),
                    LName = table.Column<string>(nullable: true),
                    DateAdded = table.Column<DateTime>(nullable: false),
                    ContactInfoId = table.Column<int>(nullable: false),
                    ProfileInfoId = table.Column<int>(nullable: false),
                    CityId = table.Column<int>(nullable: false),
                    AdministrastorRoleId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Administrator", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Administrator_AdministrastorRole_AdministrastorRoleId",
                        column: x => x.AdministrastorRoleId,
                        principalTable: "AdministrastorRole",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Administrator_City_CityId",
                        column: x => x.CityId,
                        principalTable: "City",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Administrator_Contact_ContactInfoId",
                        column: x => x.ContactInfoId,
                        principalTable: "Contact",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Administrator_ProfileInfo_ProfileInfoId",
                        column: x => x.ProfileInfoId,
                        principalTable: "ProfileInfo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ClassRequest",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    StudentId = table.Column<int>(nullable: false),
                    TeacherId = table.Column<int>(nullable: false),
                    TypeOfClassIdId = table.Column<int>(nullable: true),
                    TypeOfClassId1 = table.Column<int>(nullable: true),
                    DateOfRequest = table.Column<DateTime>(nullable: false),
                    DateFrom = table.Column<DateTime>(nullable: false),
                    DateTo = table.Column<DateTime>(nullable: false),
                    HourFrom = table.Column<TimeSpan>(nullable: false),
                    HourTo = table.Column<TimeSpan>(nullable: false),
                    IsRead = table.Column<bool>(nullable: false),
                    IsAceppted = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClassRequest", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClassRequest_Student_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Student",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClassRequest_Teacher_TeacherId",
                        column: x => x.TeacherId,
                        principalTable: "Teacher",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ClassRequest_TypeOfClass_TypeOfClassId1",
                        column: x => x.TypeOfClassId1,
                        principalTable: "TypeOfClass",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ClassRequest_TypeOfClass_TypeOfClassIdId",
                        column: x => x.TypeOfClassIdId,
                        principalTable: "TypeOfClass",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Subject_FieldId",
                table: "Subject",
                column: "FieldId");

            migrationBuilder.CreateIndex(
                name: "IX_Administrator_AdministrastorRoleId",
                table: "Administrator",
                column: "AdministrastorRoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Administrator_CityId",
                table: "Administrator",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_Administrator_ContactInfoId",
                table: "Administrator",
                column: "ContactInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_Administrator_ProfileInfoId",
                table: "Administrator",
                column: "ProfileInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_ClassRequest_StudentId",
                table: "ClassRequest",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_ClassRequest_TeacherId",
                table: "ClassRequest",
                column: "TeacherId");

            migrationBuilder.CreateIndex(
                name: "IX_ClassRequest_TypeOfClassId1",
                table: "ClassRequest",
                column: "TypeOfClassId1");

            migrationBuilder.CreateIndex(
                name: "IX_ClassRequest_TypeOfClassIdId",
                table: "ClassRequest",
                column: "TypeOfClassIdId");

            migrationBuilder.CreateIndex(
                name: "IX_LandLord_ContactInfoId",
                table: "LandLord",
                column: "ContactInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_LandLord_ProfileInfoId",
                table: "LandLord",
                column: "ProfileInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_ListOfStudents_StudentTypeId",
                table: "ListOfStudents",
                column: "StudentTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ListOfStudents_TeacherId",
                table: "ListOfStudents",
                column: "TeacherId");

            migrationBuilder.CreateIndex(
                name: "IX_ReportedStudent_StudentId",
                table: "ReportedStudent",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_ReportedStudent_TeacherId",
                table: "ReportedStudent",
                column: "TeacherId");

            migrationBuilder.CreateIndex(
                name: "IX_ReportedTeacher_StudentId",
                table: "ReportedTeacher",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_ReportedTeacher_TeacherId",
                table: "ReportedTeacher",
                column: "TeacherId");

            migrationBuilder.CreateIndex(
                name: "IX_TutorRegistrationForm_CityId",
                table: "TutorRegistrationForm",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_TutorRegistrationForm_ContactInfoId",
                table: "TutorRegistrationForm",
                column: "ContactInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_TutorRegistrationForm_GenderId",
                table: "TutorRegistrationForm",
                column: "GenderId");

            migrationBuilder.CreateIndex(
                name: "IX_TutorRegistrationForm_SubjectId",
                table: "TutorRegistrationForm",
                column: "SubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_TutorRegistrationForm_TitleId",
                table: "TutorRegistrationForm",
                column: "TitleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Subject_Field_FieldId",
                table: "Subject",
                column: "FieldId",
                principalTable: "Field",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Subject_Field_FieldId",
                table: "Subject");

            migrationBuilder.DropTable(
                name: "Administrator");

            migrationBuilder.DropTable(
                name: "ClassRequest");

            migrationBuilder.DropTable(
                name: "Field");

            migrationBuilder.DropTable(
                name: "LandLord");

            migrationBuilder.DropTable(
                name: "ListOfStudents");

            migrationBuilder.DropTable(
                name: "ReportedStudent");

            migrationBuilder.DropTable(
                name: "ReportedTeacher");

            migrationBuilder.DropTable(
                name: "TutorRegistrationForm");

            migrationBuilder.DropTable(
                name: "AdministrastorRole");

            migrationBuilder.DropTable(
                name: "TypeOfClass");

            migrationBuilder.DropIndex(
                name: "IX_Subject_FieldId",
                table: "Subject");

            migrationBuilder.DropColumn(
                name: "FieldId",
                table: "Subject");
        }
    }
}
