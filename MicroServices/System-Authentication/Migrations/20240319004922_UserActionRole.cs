using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace System_Authentication.Migrations
{
    /// <inheritdoc />
    public partial class UserActionRole : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RoleGroupId",
                table: "ActionRole",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "UserActionRole",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ActionRoleId = table.Column<int>(type: "int", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: true),
                    DeleterName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdaterName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifierName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NameLocalized = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserActionRole", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserActionRole_ActionRole_ActionRoleId",
                        column: x => x.ActionRoleId,
                        principalTable: "ActionRole",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UserActionRole_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "UserActionRoleLogger",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RecordId = table.Column<int>(type: "int", nullable: true),
                    EntityName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LogType = table.Column<int>(type: "int", nullable: true),
                    JsonBefore = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    JsonAfter = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TransactionDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserActionRoleLogger", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ActionRole_RoleGroupId",
                table: "ActionRole",
                column: "RoleGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_UserActionRole_ActionRoleId",
                table: "UserActionRole",
                column: "ActionRoleId");

            migrationBuilder.CreateIndex(
                name: "IX_UserActionRole_UserId",
                table: "UserActionRole",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_ActionRole_RoleGroup_RoleGroupId",
                table: "ActionRole",
                column: "RoleGroupId",
                principalTable: "RoleGroup",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ActionRole_RoleGroup_RoleGroupId",
                table: "ActionRole");

            migrationBuilder.DropTable(
                name: "UserActionRole");

            migrationBuilder.DropTable(
                name: "UserActionRoleLogger");

            migrationBuilder.DropIndex(
                name: "IX_ActionRole_RoleGroupId",
                table: "ActionRole");

            migrationBuilder.DropColumn(
                name: "RoleGroupId",
                table: "ActionRole");
        }
    }
}
