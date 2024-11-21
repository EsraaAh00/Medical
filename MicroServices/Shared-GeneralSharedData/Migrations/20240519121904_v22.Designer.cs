﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Shared_GeneralSharedData.Context;

#nullable disable

namespace Shared_GeneralSharedData.Migrations
{
    [DbContext(typeof(GeneralSharedDataContext))]
    [Migration("20240519121904_v22")]
    partial class v22
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Shared_GeneralSharedData.Entities.AirPort", b =>
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

                    b.Property<double?>("Lat")
                        .HasColumnType("float");

                    b.Property<double?>("Lng")
                        .HasColumnType("float");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("ModifierName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NameKayes")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NameLocalized")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("RegionId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("UpdaterName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("RegionId");

                    b.ToTable("AirPort");
                });

            modelBuilder.Entity("Shared_GeneralSharedData.Entities.Country", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Active")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ActiveCode")
                        .HasColumnType("int");

                    b.Property<string>("Code")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("DeletedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("DeleterName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Image")
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

                    b.Property<int?>("PhoneNumberDigetsCount")
                        .HasColumnType("int");

                    b.Property<string>("ShortName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("UpdaterName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Country");
                });

            modelBuilder.Entity("Shared_GeneralSharedData.Entities.Currency", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("CountryId")
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

                    b.Property<string>("Prefix")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PrefixLocalized")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Symbol")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("UpdaterName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CountryId");

                    b.ToTable("Currency");
                });

            modelBuilder.Entity("Shared_GeneralSharedData.Entities.Governorate", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("CountryId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("DeletedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("DeleterName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<double?>("Lat")
                        .HasColumnType("float");

                    b.Property<double?>("Lng")
                        .HasColumnType("float");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("ModifierName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NameKays")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NameLocalized")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("UpdaterName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CountryId");

                    b.ToTable("Governorate");
                });

            modelBuilder.Entity("Shared_GeneralSharedData.Entities.Logger.AirPortLogger", b =>
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

                    b.ToTable("AirPortLogger");
                });

            modelBuilder.Entity("Shared_GeneralSharedData.Entities.Logger.CountryLogger", b =>
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

                    b.ToTable("CountryLogger");
                });

            modelBuilder.Entity("Shared_GeneralSharedData.Entities.Logger.CurrencyLogger", b =>
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

                    b.ToTable("CurrencyLogger");
                });

            modelBuilder.Entity("Shared_GeneralSharedData.Entities.Logger.GovernorateLogger", b =>
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

                    b.ToTable("GovernorateLogger");
                });

            modelBuilder.Entity("Shared_GeneralSharedData.Entities.Logger.Logger", b =>
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

            modelBuilder.Entity("Shared_GeneralSharedData.Entities.Logger.RegionLogger", b =>
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

                    b.ToTable("RegionLogger");
                });

            modelBuilder.Entity("Shared_GeneralSharedData.Entities.Region", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("DeletedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("DeleterName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("GovernorateId")
                        .HasColumnType("int");

                    b.Property<bool?>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<double?>("Lat")
                        .HasColumnType("float");

                    b.Property<double?>("Lng")
                        .HasColumnType("float");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("ModifierName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NameKayes")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NameLocalized")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("UpdaterName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("GovernorateId");

                    b.ToTable("Region");
                });

            modelBuilder.Entity("Shared_GeneralSharedData.Entities.AirPort", b =>
                {
                    b.HasOne("Shared_GeneralSharedData.Entities.Region", "Region")
                        .WithMany()
                        .HasForeignKey("RegionId");

                    b.Navigation("Region");
                });

            modelBuilder.Entity("Shared_GeneralSharedData.Entities.Currency", b =>
                {
                    b.HasOne("Shared_GeneralSharedData.Entities.Country", "Country")
                        .WithMany()
                        .HasForeignKey("CountryId");

                    b.Navigation("Country");
                });

            modelBuilder.Entity("Shared_GeneralSharedData.Entities.Governorate", b =>
                {
                    b.HasOne("Shared_GeneralSharedData.Entities.Country", "Country")
                        .WithMany()
                        .HasForeignKey("CountryId");

                    b.Navigation("Country");
                });

            modelBuilder.Entity("Shared_GeneralSharedData.Entities.Region", b =>
                {
                    b.HasOne("Shared_GeneralSharedData.Entities.Governorate", "Governorate")
                        .WithMany()
                        .HasForeignKey("GovernorateId");

                    b.Navigation("Governorate");
                });
#pragma warning restore 612, 618
        }
    }
}
