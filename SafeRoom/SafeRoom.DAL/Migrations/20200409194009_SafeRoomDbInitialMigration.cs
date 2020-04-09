﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace SafeRoom.DAL.Migrations
{
    public partial class SafeRoomDbInitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    RoleId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleName = table.Column<string>(maxLength: 64, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.RoleId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(maxLength: 128, nullable: false),
                    ChatroomId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "Chatrooms",
                columns: table => new
                {
                    ChatroomId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OwnerId = table.Column<int>(nullable: false),
                    ChatroomName = table.Column<string>(maxLength: 128, nullable: false),
                    Status = table.Column<string>(maxLength: 64, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Chatrooms", x => x.ChatroomId);
                    table.ForeignKey(
                        name: "FK_Chatrooms_Users_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserRole",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false),
                    RoleId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRole", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_UserRole_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "RoleId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserRole_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "ChatroomId", "Email" },
                values: new object[] { 1, null, "Email01@test.com" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "ChatroomId", "Email" },
                values: new object[] { 2, null, "Email02@test.com" });

            migrationBuilder.InsertData(
                table: "Chatrooms",
                columns: new[] { "ChatroomId", "ChatroomName", "OwnerId", "Status" },
                values: new object[] { 1, "Chatroom Name 01", 1, "Closed" });

            migrationBuilder.InsertData(
                table: "Chatrooms",
                columns: new[] { "ChatroomId", "ChatroomName", "OwnerId", "Status" },
                values: new object[] { 2, "Chatroom Name 02", 1, "Open" });

            migrationBuilder.CreateIndex(
                name: "IX_Chatrooms_OwnerId",
                table: "Chatrooms",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRole_RoleId",
                table: "UserRole",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_ChatroomId",
                table: "Users",
                column: "ChatroomId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Email",
                table: "Users",
                column: "Email",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Chatrooms_ChatroomId",
                table: "Users",
                column: "ChatroomId",
                principalTable: "Chatrooms",
                principalColumn: "ChatroomId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Chatrooms_Users_OwnerId",
                table: "Chatrooms");

            migrationBuilder.DropTable(
                name: "UserRole");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Chatrooms");
        }
    }
}
