﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Vendor_ListingManagement.Context;

#nullable disable

namespace Vendor_ListingManagement.Migrations
{
    [DbContext(typeof(ListingManagementContext))]
    [Migration("20240510130121_ListingItemsPricing")]
    partial class ListingItemsPricing
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Vendor_ListingManagement.Entities.ItemCategories", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("DeletedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("DeleterName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("ModifierName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NameLocalized")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("UpdaterName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ItemCategories");
                });

            modelBuilder.Entity("Vendor_ListingManagement.Entities.ListingItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("DeletedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("DeleterName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DescriptionLocalized")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<int?>("ItemCategoriesId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("ModifierName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NameLocalized")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("State")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("StateCode")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("UpdaterName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("VendorBusinessId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ItemCategoriesId");

                    b.ToTable("ListingItem");
                });

            modelBuilder.Entity("Vendor_ListingManagement.Entities.ListingItemDetail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("DeletedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("DeleterName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<int?>("ListingItemDetailSettingId")
                        .HasColumnType("int");

                    b.Property<int?>("ListingItemId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("ModifierName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("UpdaterName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ValueLocalized")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ListingItemDetailSettingId");

                    b.HasIndex("ListingItemId");

                    b.ToTable("ListingItemDetail");
                });

            modelBuilder.Entity("Vendor_ListingManagement.Entities.ListingItemDetailSetting", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("Code")
                        .HasColumnType("int");

                    b.Property<DateTime?>("DeletedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("DeleterName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("ModifierName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NameLocalized")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Priority")
                        .HasColumnType("int");

                    b.Property<string>("Type")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("TypeCode")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("UpdaterName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Vector")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ListingItemDetailSetting");
                });

            modelBuilder.Entity("Vendor_ListingManagement.Entities.ListingItemPhotos", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("DeletedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("DeleterName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Image")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<int?>("ListingItemId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("ModifierName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("UpdaterName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ListingItemId");

                    b.ToTable("ListingItemPhotos");
                });

            modelBuilder.Entity("Vendor_ListingManagement.Entities.ListingItemsPricing", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<double?>("BaseAmount")
                        .HasColumnType("float");

                    b.Property<DateTime?>("DeletedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("DeleterName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<double?>("ExtraGusetAddtion")
                        .HasColumnType("float");

                    b.Property<int?>("Frequency")
                        .HasColumnType("int");

                    b.Property<bool?>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<int?>("ListingItemId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("ModifierName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("OccNumberPriceApplicable")
                        .HasColumnType("int");

                    b.Property<string>("OfferTitle")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OfferTitleLocalized")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PricingState")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("PricingStateCode")
                        .HasColumnType("int");

                    b.Property<DateTime?>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("UpdateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("UpdaterName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ListingItemId");

                    b.ToTable("ListingItemsPricing");
                });

            modelBuilder.Entity("Vendor_ListingManagement.Entities.Logger.ItemCategoriesLogger", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EntityName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("JsonAfter")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("JsonBefore")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("LogType")
                        .HasColumnType("int");

                    b.Property<int?>("RecordId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("TransactionDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ItemCategoriesLogger");
                });

            modelBuilder.Entity("Vendor_ListingManagement.Entities.Logger.ListingItemDetailLogger", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EntityName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("JsonAfter")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("JsonBefore")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("LogType")
                        .HasColumnType("int");

                    b.Property<int?>("RecordId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("TransactionDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ListingItemDetailLogger");
                });

            modelBuilder.Entity("Vendor_ListingManagement.Entities.Logger.ListingItemDetailSettingLogger", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EntityName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("JsonAfter")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("JsonBefore")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("LogType")
                        .HasColumnType("int");

                    b.Property<int?>("RecordId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("TransactionDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ListingItemDetailSettingLogger");
                });

            modelBuilder.Entity("Vendor_ListingManagement.Entities.Logger.ListingItemLogger", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EntityName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("JsonAfter")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("JsonBefore")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("LogType")
                        .HasColumnType("int");

                    b.Property<int?>("RecordId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("TransactionDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ListingItemLogger");
                });

            modelBuilder.Entity("Vendor_ListingManagement.Entities.Logger.ListingItemsPricingLogger", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EntityName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("JsonAfter")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("JsonBefore")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("LogType")
                        .HasColumnType("int");

                    b.Property<int?>("RecordId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("TransactionDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ListingItemsPricingLogger");
                });

            modelBuilder.Entity("Vendor_ListingManagement.Entities.Logger.Logger", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EntityName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("JsonAfter")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("JsonBefore")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("LogType")
                        .HasColumnType("int");

                    b.Property<int?>("RecordId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("TransactionDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Logger");
                });

            modelBuilder.Entity("Vendor_ListingManagement.Entities.ListingItem", b =>
                {
                    b.HasOne("Vendor_ListingManagement.Entities.ItemCategories", "ItemCategories")
                        .WithMany()
                        .HasForeignKey("ItemCategoriesId");

                    b.Navigation("ItemCategories");
                });

            modelBuilder.Entity("Vendor_ListingManagement.Entities.ListingItemDetail", b =>
                {
                    b.HasOne("Vendor_ListingManagement.Entities.ListingItemDetailSetting", "ListingItemDetailSetting")
                        .WithMany()
                        .HasForeignKey("ListingItemDetailSettingId");

                    b.HasOne("Vendor_ListingManagement.Entities.ListingItem", "ListingItem")
                        .WithMany()
                        .HasForeignKey("ListingItemId");

                    b.Navigation("ListingItem");

                    b.Navigation("ListingItemDetailSetting");
                });

            modelBuilder.Entity("Vendor_ListingManagement.Entities.ListingItemPhotos", b =>
                {
                    b.HasOne("Vendor_ListingManagement.Entities.ListingItem", "ListingItem")
                        .WithMany()
                        .HasForeignKey("ListingItemId");

                    b.Navigation("ListingItem");
                });

            modelBuilder.Entity("Vendor_ListingManagement.Entities.ListingItemsPricing", b =>
                {
                    b.HasOne("Vendor_ListingManagement.Entities.ListingItem", "ListingItem")
                        .WithMany()
                        .HasForeignKey("ListingItemId");

                    b.Navigation("ListingItem");
                });
#pragma warning restore 612, 618
        }
    }
}