﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using OrphanedEntities.Entity;

#nullable disable

namespace OrphanedEntities.Migrations
{
    [DbContext(typeof(TestDbContext))]
    [Migration("20240424124121_First")]
    partial class First
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("OrphanedEntities.Dal.CompanyEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Company", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "CompanyEntity 1"
                        });
                });

            modelBuilder.Entity("OrphanedEntities.Dal.CompanyPropertyEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CompanyId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.ToTable("CompanyProperty", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CompanyId = 1,
                            Name = "Prop 1"
                        },
                        new
                        {
                            Id = 2,
                            CompanyId = 1,
                            Name = "Prop 2"
                        });
                });

            modelBuilder.Entity("OrphanedEntities.Dal.CompanyPropertyEntity", b =>
                {
                    b.HasOne("OrphanedEntities.Dal.CompanyEntity", "CompanyEntity")
                        .WithMany("CompanyProperties")
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.Navigation("CompanyEntity");
                });

            modelBuilder.Entity("OrphanedEntities.Dal.CompanyEntity", b =>
                {
                    b.Navigation("CompanyProperties");
                });
#pragma warning restore 612, 618
        }
    }
}
