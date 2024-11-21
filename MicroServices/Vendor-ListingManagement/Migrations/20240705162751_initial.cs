using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Vendor_ListingManagement.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DemandDrivenPricingLogger",
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
                    table.PrimaryKey("PK_DemandDrivenPricingLogger", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ItemCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BusinessTypeCategoryId = table.Column<int>(type: "int", nullable: true),
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
                    table.PrimaryKey("PK_ItemCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ItemCategoriesLogger",
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
                    table.PrimaryKey("PK_ItemCategoriesLogger", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ItemSubCategoriesLogger",
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
                    table.PrimaryKey("PK_ItemSubCategoriesLogger", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LengthOfStayDiscountLogger",
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
                    table.PrimaryKey("PK_LengthOfStayDiscountLogger", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ListingItemDetailLogger",
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
                    table.PrimaryKey("PK_ListingItemDetailLogger", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ListingItemDetailSettingLogger",
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
                    table.PrimaryKey("PK_ListingItemDetailSettingLogger", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ListingItemLogger",
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
                    table.PrimaryKey("PK_ListingItemLogger", x => x.Id);
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

            migrationBuilder.CreateTable(
                name: "ListingItemsTaxLogger",
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
                    table.PrimaryKey("PK_ListingItemsTaxLogger", x => x.Id);
                });

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
                name: "OccupancyBasedPricingLogger",
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
                    table.PrimaryKey("PK_OccupancyBasedPricingLogger", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Season",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VendorBusinessId = table.Column<int>(type: "int", nullable: true),
                    StartsOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EndsOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StateCode = table.Column<int>(type: "int", nullable: true),
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
                    table.PrimaryKey("PK_Season", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SeasonalPricingLogger",
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
                    table.PrimaryKey("PK_SeasonalPricingLogger", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SeasonLogger",
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
                    table.PrimaryKey("PK_SeasonLogger", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ItemSubCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ItemCategoriesId = table.Column<int>(type: "int", nullable: true),
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
                    table.PrimaryKey("PK_ItemSubCategories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ItemSubCategories_ItemCategories_ItemCategoriesId",
                        column: x => x.ItemCategoriesId,
                        principalTable: "ItemCategories",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ListingItemDetailSetting",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ItemCategoryId = table.Column<int>(type: "int", nullable: true),
                    Code = table.Column<int>(type: "int", nullable: true),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TypeCode = table.Column<int>(type: "int", nullable: true),
                    Vector = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Priority = table.Column<int>(type: "int", nullable: true),
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
                    table.PrimaryKey("PK_ListingItemDetailSetting", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ListingItemDetailSetting_ItemCategories_ItemCategoryId",
                        column: x => x.ItemCategoryId,
                        principalTable: "ItemCategories",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "DemandDrivenPricing",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VendorBusinessId = table.Column<int>(type: "int", nullable: true),
                    ItemSubCategoriesId = table.Column<int>(type: "int", nullable: true),
                    DemandFactor = table.Column<double>(type: "float", nullable: true),
                    RateMultiplier = table.Column<double>(type: "float", nullable: true),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StateCode = table.Column<int>(type: "int", nullable: true),
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
                    table.PrimaryKey("PK_DemandDrivenPricing", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DemandDrivenPricing_ItemSubCategories_ItemSubCategoriesId",
                        column: x => x.ItemSubCategoriesId,
                        principalTable: "ItemSubCategories",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "LengthOfStayDiscount",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VendorBusinessId = table.Column<int>(type: "int", nullable: true),
                    ItemSubCategoriesId = table.Column<int>(type: "int", nullable: true),
                    MinNights = table.Column<int>(type: "int", nullable: true),
                    DiscountRate = table.Column<int>(type: "int", nullable: true),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StateCode = table.Column<int>(type: "int", nullable: true),
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
                    table.PrimaryKey("PK_LengthOfStayDiscount", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LengthOfStayDiscount_ItemSubCategories_ItemSubCategoriesId",
                        column: x => x.ItemSubCategoriesId,
                        principalTable: "ItemSubCategories",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ListingItem",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ItemSubCategoriesId = table.Column<int>(type: "int", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DescriptionLocalized = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VendorBusinessId = table.Column<int>(type: "int", nullable: true),
                    maxticketnumber = table.Column<int>(type: "int", nullable: true),
                    IsOccupied = table.Column<bool>(type: "bit", nullable: true),
                    OccupiedFrom = table.Column<DateTime>(type: "datetime2", nullable: true),
                    OccupiedTo = table.Column<DateTime>(type: "datetime2", nullable: true),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StateCode = table.Column<int>(type: "int", nullable: true),
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
                    table.PrimaryKey("PK_ListingItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ListingItem_ItemSubCategories_ItemSubCategoriesId",
                        column: x => x.ItemSubCategoriesId,
                        principalTable: "ItemSubCategories",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "OccupancyBasedPricing",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VendorBusinessId = table.Column<int>(type: "int", nullable: true),
                    ItemSubCategoriesId = table.Column<int>(type: "int", nullable: true),
                    OccupancyRateThreshold = table.Column<double>(type: "float", nullable: true),
                    RateMultiplier = table.Column<double>(type: "float", nullable: true),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StateCode = table.Column<int>(type: "int", nullable: true),
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
                    table.PrimaryKey("PK_OccupancyBasedPricing", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OccupancyBasedPricing_ItemSubCategories_ItemSubCategoriesId",
                        column: x => x.ItemSubCategoriesId,
                        principalTable: "ItemSubCategories",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "SeasonalPricing",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ItemSubCategoriesId = table.Column<int>(type: "int", nullable: true),
                    SeasonId = table.Column<int>(type: "int", nullable: true),
                    RateMultiplier = table.Column<double>(type: "float", nullable: true),
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
                    table.PrimaryKey("PK_SeasonalPricing", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SeasonalPricing_ItemSubCategories_ItemSubCategoriesId",
                        column: x => x.ItemSubCategoriesId,
                        principalTable: "ItemSubCategories",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SeasonalPricing_Season_SeasonId",
                        column: x => x.SeasonId,
                        principalTable: "Season",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ListingItemDetail",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ListingItemId = table.Column<int>(type: "int", nullable: true),
                    ListingItemDetailSettingId = table.Column<int>(type: "int", nullable: true),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ValueLocalized = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    table.PrimaryKey("PK_ListingItemDetail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ListingItemDetail_ListingItemDetailSetting_ListingItemDetailSettingId",
                        column: x => x.ListingItemDetailSettingId,
                        principalTable: "ListingItemDetailSetting",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ListingItemDetail_ListingItem_ListingItemId",
                        column: x => x.ListingItemId,
                        principalTable: "ListingItem",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ListingItemPhotos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ListingItemId = table.Column<int>(type: "int", nullable: true),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    table.PrimaryKey("PK_ListingItemPhotos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ListingItemPhotos_ListingItem_ListingItemId",
                        column: x => x.ListingItemId,
                        principalTable: "ListingItem",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ListingItemsPricing",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ListingItemId = table.Column<int>(type: "int", nullable: true),
                    BaseAmount = table.Column<double>(type: "float", nullable: true),
                    ChargeFrequencyType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ChargeFrequencyTypeCode = table.Column<int>(type: "int", nullable: true),
                    ChargeFrequency = table.Column<int>(type: "int", nullable: true),
                    ApplicableType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ApplicableTypeCode = table.Column<int>(type: "int", nullable: true),
                    ApplicableTypeNumber = table.Column<int>(type: "int", nullable: true),
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
                name: "ListingItemsTax",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ListingItemId = table.Column<int>(type: "int", nullable: true),
                    TaxAmount = table.Column<double>(type: "float", nullable: true),
                    Percentege = table.Column<bool>(type: "bit", nullable: true),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StateCode = table.Column<int>(type: "int", nullable: true),
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
                    table.PrimaryKey("PK_ListingItemsTax", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ListingItemsTax_ListingItem_ListingItemId",
                        column: x => x.ListingItemId,
                        principalTable: "ListingItem",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_DemandDrivenPricing_ItemSubCategoriesId",
                table: "DemandDrivenPricing",
                column: "ItemSubCategoriesId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemSubCategories_ItemCategoriesId",
                table: "ItemSubCategories",
                column: "ItemCategoriesId");

            migrationBuilder.CreateIndex(
                name: "IX_LengthOfStayDiscount_ItemSubCategoriesId",
                table: "LengthOfStayDiscount",
                column: "ItemSubCategoriesId");

            migrationBuilder.CreateIndex(
                name: "IX_ListingItem_ItemSubCategoriesId",
                table: "ListingItem",
                column: "ItemSubCategoriesId");

            migrationBuilder.CreateIndex(
                name: "IX_ListingItemDetail_ListingItemDetailSettingId",
                table: "ListingItemDetail",
                column: "ListingItemDetailSettingId");

            migrationBuilder.CreateIndex(
                name: "IX_ListingItemDetail_ListingItemId",
                table: "ListingItemDetail",
                column: "ListingItemId");

            migrationBuilder.CreateIndex(
                name: "IX_ListingItemDetailSetting_ItemCategoryId",
                table: "ListingItemDetailSetting",
                column: "ItemCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ListingItemPhotos_ListingItemId",
                table: "ListingItemPhotos",
                column: "ListingItemId");

            migrationBuilder.CreateIndex(
                name: "IX_ListingItemsPricing_ListingItemId",
                table: "ListingItemsPricing",
                column: "ListingItemId");

            migrationBuilder.CreateIndex(
                name: "IX_ListingItemsTax_ListingItemId",
                table: "ListingItemsTax",
                column: "ListingItemId");

            migrationBuilder.CreateIndex(
                name: "IX_OccupancyBasedPricing_ItemSubCategoriesId",
                table: "OccupancyBasedPricing",
                column: "ItemSubCategoriesId");

            migrationBuilder.CreateIndex(
                name: "IX_SeasonalPricing_ItemSubCategoriesId",
                table: "SeasonalPricing",
                column: "ItemSubCategoriesId");

            migrationBuilder.CreateIndex(
                name: "IX_SeasonalPricing_SeasonId",
                table: "SeasonalPricing",
                column: "SeasonId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DemandDrivenPricing");

            migrationBuilder.DropTable(
                name: "DemandDrivenPricingLogger");

            migrationBuilder.DropTable(
                name: "ItemCategoriesLogger");

            migrationBuilder.DropTable(
                name: "ItemSubCategoriesLogger");

            migrationBuilder.DropTable(
                name: "LengthOfStayDiscount");

            migrationBuilder.DropTable(
                name: "LengthOfStayDiscountLogger");

            migrationBuilder.DropTable(
                name: "ListingItemDetail");

            migrationBuilder.DropTable(
                name: "ListingItemDetailLogger");

            migrationBuilder.DropTable(
                name: "ListingItemDetailSettingLogger");

            migrationBuilder.DropTable(
                name: "ListingItemLogger");

            migrationBuilder.DropTable(
                name: "ListingItemPhotos");

            migrationBuilder.DropTable(
                name: "ListingItemsPricing");

            migrationBuilder.DropTable(
                name: "ListingItemsPricingLogger");

            migrationBuilder.DropTable(
                name: "ListingItemsTax");

            migrationBuilder.DropTable(
                name: "ListingItemsTaxLogger");

            migrationBuilder.DropTable(
                name: "Logger");

            migrationBuilder.DropTable(
                name: "OccupancyBasedPricing");

            migrationBuilder.DropTable(
                name: "OccupancyBasedPricingLogger");

            migrationBuilder.DropTable(
                name: "SeasonalPricing");

            migrationBuilder.DropTable(
                name: "SeasonalPricingLogger");

            migrationBuilder.DropTable(
                name: "SeasonLogger");

            migrationBuilder.DropTable(
                name: "ListingItemDetailSetting");

            migrationBuilder.DropTable(
                name: "ListingItem");

            migrationBuilder.DropTable(
                name: "Season");

            migrationBuilder.DropTable(
                name: "ItemSubCategories");

            migrationBuilder.DropTable(
                name: "ItemCategories");
        }
    }
}
