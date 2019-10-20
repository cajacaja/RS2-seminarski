using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Aplikacijaa.Migrations
{
    public partial class migracija : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Teacher_City_CityId",
                table: "Teacher");

            migrationBuilder.DropForeignKey(
                name: "FK_Teacher_Contact_ContactInfoId",
                table: "Teacher");

            migrationBuilder.DropForeignKey(
                name: "FK_Teacher_Gender_GenderId",
                table: "Teacher");

            migrationBuilder.DropForeignKey(
                name: "FK_Teacher_ProfileInfo_ProfileInfoId",
                table: "Teacher");

            migrationBuilder.DropForeignKey(
                name: "FK_Teacher_Subject_SubjectId",
                table: "Teacher");

            migrationBuilder.DropForeignKey(
                name: "FK_Teacher_Title_TitleId",
                table: "Teacher");

            migrationBuilder.DropForeignKey(
                name: "FK_Teacher_UserStatus_UserStatusId",
                table: "Teacher");

            migrationBuilder.DropIndex(
                name: "IX_Teacher_CityId",
                table: "Teacher");

            migrationBuilder.DropIndex(
                name: "IX_Teacher_ContactInfoId",
                table: "Teacher");

            migrationBuilder.DropIndex(
                name: "IX_Teacher_GenderId",
                table: "Teacher");

            migrationBuilder.DropIndex(
                name: "IX_Teacher_ProfileInfoId",
                table: "Teacher");

            migrationBuilder.DropIndex(
                name: "IX_Teacher_SubjectId",
                table: "Teacher");

            migrationBuilder.DropIndex(
                name: "IX_Teacher_TitleId",
                table: "Teacher");

            migrationBuilder.DropColumn(
                name: "DateAdded",
                table: "TutorRegistrationForm");

            migrationBuilder.DropColumn(
                name: "PasswordHash",
                table: "TutorRegistrationForm");

            migrationBuilder.DropColumn(
                name: "PasswordSalt",
                table: "TutorRegistrationForm");

            migrationBuilder.DropColumn(
                name: "Username",
                table: "TutorRegistrationForm");

            migrationBuilder.DropColumn(
                name: "CityId",
                table: "Teacher");

            migrationBuilder.DropColumn(
                name: "CollageName",
                table: "Teacher");

            migrationBuilder.DropColumn(
                name: "ContactInfoId",
                table: "Teacher");

            migrationBuilder.DropColumn(
                name: "DateOfBirth",
                table: "Teacher");

            migrationBuilder.DropColumn(
                name: "FName",
                table: "Teacher");

            migrationBuilder.DropColumn(
                name: "GenderId",
                table: "Teacher");

            migrationBuilder.DropColumn(
                name: "LName",
                table: "Teacher");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "Teacher");

            migrationBuilder.DropColumn(
                name: "ProfileInfoId",
                table: "Teacher");

            migrationBuilder.DropColumn(
                name: "ProfilePicture",
                table: "Teacher");

            migrationBuilder.DropColumn(
                name: "SubjectId",
                table: "Teacher");

            migrationBuilder.DropColumn(
                name: "TitleId",
                table: "Teacher");

            migrationBuilder.RenameColumn(
                name: "UserStatusId",
                table: "Teacher",
                newName: "TutorRegistrationFormId");

            migrationBuilder.RenameIndex(
                name: "IX_Teacher_UserStatusId",
                table: "Teacher",
                newName: "IX_Teacher_TutorRegistrationFormId");

            migrationBuilder.AddColumn<bool>(
                name: "IsAceppted",
                table: "TutorRegistrationForm",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsRead",
                table: "TutorRegistrationForm",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "ProfileInfoId",
                table: "TutorRegistrationForm",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_TutorRegistrationForm_ProfileInfoId",
                table: "TutorRegistrationForm",
                column: "ProfileInfoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Teacher_TutorRegistrationForm_TutorRegistrationFormId",
                table: "Teacher",
                column: "TutorRegistrationFormId",
                principalTable: "TutorRegistrationForm",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TutorRegistrationForm_ProfileInfo_ProfileInfoId",
                table: "TutorRegistrationForm",
                column: "ProfileInfoId",
                principalTable: "ProfileInfo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Teacher_TutorRegistrationForm_TutorRegistrationFormId",
                table: "Teacher");

            migrationBuilder.DropForeignKey(
                name: "FK_TutorRegistrationForm_ProfileInfo_ProfileInfoId",
                table: "TutorRegistrationForm");

            migrationBuilder.DropIndex(
                name: "IX_TutorRegistrationForm_ProfileInfoId",
                table: "TutorRegistrationForm");

            migrationBuilder.DropColumn(
                name: "IsAceppted",
                table: "TutorRegistrationForm");

            migrationBuilder.DropColumn(
                name: "IsRead",
                table: "TutorRegistrationForm");

            migrationBuilder.DropColumn(
                name: "ProfileInfoId",
                table: "TutorRegistrationForm");

            migrationBuilder.RenameColumn(
                name: "TutorRegistrationFormId",
                table: "Teacher",
                newName: "UserStatusId");

            migrationBuilder.RenameIndex(
                name: "IX_Teacher_TutorRegistrationFormId",
                table: "Teacher",
                newName: "IX_Teacher_UserStatusId");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateAdded",
                table: "TutorRegistrationForm",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "PasswordHash",
                table: "TutorRegistrationForm",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PasswordSalt",
                table: "TutorRegistrationForm",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Username",
                table: "TutorRegistrationForm",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CityId",
                table: "Teacher",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "CollageName",
                table: "Teacher",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ContactInfoId",
                table: "Teacher",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateOfBirth",
                table: "Teacher",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "FName",
                table: "Teacher",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "GenderId",
                table: "Teacher",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "LName",
                table: "Teacher",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "Teacher",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "ProfileInfoId",
                table: "Teacher",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "ProfilePicture",
                table: "Teacher",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SubjectId",
                table: "Teacher",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TitleId",
                table: "Teacher",
                nullable: false,
                defaultValue: 0);

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

            migrationBuilder.AddForeignKey(
                name: "FK_Teacher_City_CityId",
                table: "Teacher",
                column: "CityId",
                principalTable: "City",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Teacher_Contact_ContactInfoId",
                table: "Teacher",
                column: "ContactInfoId",
                principalTable: "Contact",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Teacher_Gender_GenderId",
                table: "Teacher",
                column: "GenderId",
                principalTable: "Gender",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Teacher_ProfileInfo_ProfileInfoId",
                table: "Teacher",
                column: "ProfileInfoId",
                principalTable: "ProfileInfo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Teacher_Subject_SubjectId",
                table: "Teacher",
                column: "SubjectId",
                principalTable: "Subject",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Teacher_Title_TitleId",
                table: "Teacher",
                column: "TitleId",
                principalTable: "Title",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Teacher_UserStatus_UserStatusId",
                table: "Teacher",
                column: "UserStatusId",
                principalTable: "UserStatus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
