using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Vendor_ListingManagement.Migrations
{
    /// <inheritdoc />
    public partial class ListingItemsPricing : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ListingItemsPricing",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ListingItemId = table.Column<int>(type: "int", nullable: true),
                    BaseAmount = table.Column<double>(type: "float", nullable: true),
                    PricingState = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PricingStateCode = table.Column<int>(type: "int", nullable: true),
                    Frequency = table.Column<int>(type: "int", nullable: true),
                    ExtraGusetAddtion = table.Column<double>(type: "float", nullable: true),
                    OccNumberPriceApplicable = table.Column<int>(type: "int", nullable: true),
                    OfferTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OfferTitleLocalized = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
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
                    table.PrimaryKey("PK_ListingItemsPricing", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ListingItemsPricing_ListingItem_ListingItemId",
                        column: x => x.ListingItemId,
                        principalTable: "ListingItem",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ListingItemsPricingLogger",
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
                    table.PrimaryKey("PK_ListingItemsPricingLogger", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ListingItemsPricing_ListingItemId",
                table: "ListingItemsPricing",
                column: "ListingItemId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ListingItemsPricing");

            migrationBuilder.DropTable(
                name: "ListingItemsPricingLogger");
        }
    }
}
