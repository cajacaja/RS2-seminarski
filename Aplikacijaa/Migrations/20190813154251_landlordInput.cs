using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Aplikacijaa.Migrations
{
    public partial class landlordInput : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CityId",
                table: "LandLord",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "GenderId",
                table: "LandLord",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<byte[]>(
                name: "ProfilePicture",
                table: "LandLord",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StatusId",
                table: "LandLord",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UserStatusId",
                table: "LandLord",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_LandLord_CityId",
                table: "LandLord",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_LandLord_GenderId",
                table: "LandLord",
                column: "GenderId");

            migrationBuilder.CreateIndex(
                name: "IX_LandLord_UserStatusId",
                table: "LandLord",
                column: "UserStatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_LandLord_City_CityId",
                table: "LandLord",
                column: "CityId",
                principalTable: "City",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LandLord_Gender_GenderId",
                table: "LandLord",
                column: "GenderId",
                principalTable: "Gender",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LandLord_UserStatus_UserStatusId",
                table: "LandLord",
                column: "UserStatusId",
                principalTable: "UserStatus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LandLord_City_CityId",
                table: "LandLord");

            migrationBuilder.DropForeignKey(
                name: "FK_LandLord_Gender_GenderId",
                table: "LandLord");

            migrationBuilder.DropForeignKey(
                name: "FK_LandLord_UserStatus_UserStatusId",
                table: "LandLord");

            migrationBuilder.DropIndex(
                name: "IX_LandLord_CityId",
                table: "LandLord");

            migrationBuilder.DropIndex(
                name: "IX_LandLord_GenderId",
                table: "LandLord");

            migrationBuilder.DropIndex(
                name: "IX_LandLord_UserStatusId",
                table: "LandLord");

            migrationBuilder.DropColumn(
                name: "CityId",
                table: "LandLord");

            migrationBuilder.DropColumn(
                name: "GenderId",
                table: "LandLord");

            migrationBuilder.DropColumn(
                name: "ProfilePicture",
                table: "LandLord");

            migrationBuilder.DropColumn(
                name: "StatusId",
                table: "LandLord");

            migrationBuilder.DropColumn(
                name: "UserStatusId",
                table: "LandLord");
        }
    }
}
