﻿// <auto-generated />
using System;
using AdvoSecure.Infrastructure.Persistance.Tenant;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace AdvoSecure.Infrastructure.Persistance.Management.Migrations
{
    [DbContext(typeof(MgmtDbContext))]
    [Migration("20230411055347_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("AdvoSecure.Domain.Entities.RefreshToken", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Created")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("Expires")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("TenantIdentifier")
                        .HasColumnType("uuid");

                    b.Property<string>("Token")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("UserIdentifier")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.ToTable("RefreshTokens");
                });

            modelBuilder.Entity("AdvoSecure.Domain.Entities.TenantBilling", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("CreatedDateTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("DeletedBy")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime?>("DeletedDateTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("FirmAddress")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("FirmAddress2")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("FirmBankAccount")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("FirmBankBIC")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("FirmBankName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("FirmCity")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("FirmCountry")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("FirmName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("FirmPhone")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("FirmState")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("FirmVATid")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("FirmWeb")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("FirmZip")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("ModifiedBy")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime?>("ModifiedDateTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("TenantId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("TenantId")
                        .IsUnique();

                    b.ToTable("TenantBillings");
                });

            modelBuilder.Entity("AdvoSecure.Domain.Entities.TenantDirectory", b =>
                {
                    b.Property<int>("TenantId")
                        .HasColumnType("integer");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("CreatedDateTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("DeletedBy")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime?>("DeletedDateTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("ModifiedBy")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime?>("ModifiedDateTime")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("TenantId", "UserId");

                    b.HasIndex("UserId");

                    b.ToTable("TenantDirectories", (string)null);
                });

            modelBuilder.Entity("AdvoSecure.Domain.Entities.TenantSetting", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int?>("AdminId")
                        .HasColumnType("integer");

                    b.Property<string>("ConnectionString")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("CreatedDateTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("DeletedBy")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime?>("DeletedDateTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("ModifiedBy")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime?>("ModifiedDateTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("SchemaName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("TenantIdentifier")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.ToTable("TenantSettings");
                });

            modelBuilder.Entity("AdvoSecure.Domain.Entities.TenantUser", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("CreatedDateTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("DeletedBy")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime?>("DeletedDateTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("ModifiedBy")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime?>("ModifiedDateTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("UserIdentifier")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.ToTable("TenantUsers");
                });

            modelBuilder.Entity("AdvoSecure.Domain.Entities.TenantBilling", b =>
                {
                    b.HasOne("AdvoSecure.Domain.Entities.TenantSetting", "TenantSetting")
                        .WithOne("TenantBilling")
                        .HasForeignKey("AdvoSecure.Domain.Entities.TenantBilling", "TenantId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TenantSetting");
                });

            modelBuilder.Entity("AdvoSecure.Domain.Entities.TenantDirectory", b =>
                {
                    b.HasOne("AdvoSecure.Domain.Entities.TenantSetting", "Tenant")
                        .WithMany("TenantDirectories")
                        .HasForeignKey("TenantId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AdvoSecure.Domain.Entities.TenantUser", "User")
                        .WithMany("TenantDirectories")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Tenant");

                    b.Navigation("User");
                });

            modelBuilder.Entity("AdvoSecure.Domain.Entities.TenantSetting", b =>
                {
                    b.Navigation("TenantBilling")
                        .IsRequired();

                    b.Navigation("TenantDirectories");
                });

            modelBuilder.Entity("AdvoSecure.Domain.Entities.TenantUser", b =>
                {
                    b.Navigation("TenantDirectories");
                });
#pragma warning restore 612, 618
        }
    }
}
