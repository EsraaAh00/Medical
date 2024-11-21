using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace System_Authentication.Migrations
{
    /// <inheritdoc />
    public partial class sdds : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TestLookUpFeature");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TestLookUpFeature",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeleterName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifierName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NameLocalized = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TestBool = table.Column<bool>(type: "bit", nullable: true),
                    TestDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TestDouble = table.Column<double>(type: "float", nullable: true),
                    TestImage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TestInt = table.Column<int>(type: "int", nullable: true),
                    TestLocalizedDesc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TestLocalizedDescLocalized = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TestState = table.Column<int>(type: "int", nullable: true),
                    TestString = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TestTime = table.Column<TimeSpan>(type: "time", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdaterName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TestLookUpFeature", x => x.Id);
                });
        }
    }
}
