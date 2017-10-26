using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace lab29_brian.Migrations
{
    public partial class initallink2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_UserPost",
                table: "UserPost");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_UserPost_userID_UserPostID",
                table: "UserPost");

            migrationBuilder.RenameColumn(
                name: "userID",
                table: "UserPost",
                newName: "UserId");

            migrationBuilder.AlterColumn<int>(
                name: "UserPostID",
                table: "UserPost",
                type: "int",
                nullable: false,
                oldClrType: typeof(int))
                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "UserPost",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(int))
                .OldAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserPost",
                table: "UserPost",
                column: "UserPostID");

            migrationBuilder.CreateIndex(
                name: "IX_UserPost_UserId",
                table: "UserPost",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserPost_User_UserId",
                table: "UserPost",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserPost_User_UserId",
                table: "UserPost");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserPost",
                table: "UserPost");

            migrationBuilder.DropIndex(
                name: "IX_UserPost_UserId",
                table: "UserPost");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "UserPost",
                newName: "userID");

            migrationBuilder.AlterColumn<int>(
                name: "userID",
                table: "UserPost",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true)
                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AlterColumn<int>(
                name: "UserPostID",
                table: "UserPost",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserPost",
                table: "UserPost",
                column: "userID");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_UserPost_userID_UserPostID",
                table: "UserPost",
                columns: new[] { "userID", "UserPostID" });
        }
    }
}
