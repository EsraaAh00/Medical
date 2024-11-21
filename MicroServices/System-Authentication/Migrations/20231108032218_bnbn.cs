using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace System_Authentication.Migrations
{
    /// <inheritdoc />
    public partial class bnbn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NameAr",
                table: "RoleGroup");

            migrationBuilder.RenameColumn(
                name: "NameEn",
                table: "UserType",
                newName: "NameLocalized");

            migrationBuilder.RenameColumn(
                name: "NameAr",
                table: "UserType",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "NameEn",
                table: "RoleGroup",
                newName: "NameLocalized");

            migrationBuilder.RenameColumn(
                name: "NameEn",
                table: "Role",
                newName: "NameLocalized");

            migrationBuilder.RenameColumn(
                name: "NameAr",
                table: "Role",
                newName: "Name");

            migrationBuilder.CreateTable(
                name: "Logger",
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
                    table.PrimaryKey("PK_Logger", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TestLookUpFeature",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TestInt = table.Column<int>(type: "int", nullable: true),
                    TestDouble = table.Column<double>(type: "float", nullable: true),
                    TestString = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TestBool = table.Column<bool>(type: "bit", nullable: true),
                    TestDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TestTime = table.Column<TimeSpan>(type: "time", nullable: true),
                    TestImage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TestLocalizedDesc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TestLocalizedDescLocalized = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TestState = table.Column<int>(type: "int", nullable: true),
                    NameLocalized = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: true),
                    DeleterName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdaterName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifierName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TestLookUpFeature", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Logger");

            migrationBuilder.DropTable(
                name: "TestLookUpFeature");

            migrationBuilder.RenameColumn(
                name: "NameLocalized",
                table: "UserType",
                newName: "NameEn");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "UserType",
                newName: "NameAr");

            migrationBuilder.RenameColumn(
                name: "NameLocalized",
                table: "RoleGroup",
                newName: "NameEn");

            migrationBuilder.RenameColumn(
                name: "NameLocalized",
                table: "Role",
                newName: "NameEn");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Role",
                newName: "NameAr");

            migrationBuilder.AddColumn<string>(
                name: "NameAr",
                table: "RoleGroup",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
