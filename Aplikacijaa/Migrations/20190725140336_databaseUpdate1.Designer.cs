﻿// <auto-generated />
using System;
using Aplikacijaa.ContextFolder;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Aplikacijaa.Migrations
{
    [DbContext(typeof(MyContext))]
    [Migration("20190725140336_databaseUpdate1")]
    partial class databaseUpdate1
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.11-servicing-32099")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Aplikacijaa.Models.City", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("City");
                });

            modelBuilder.Entity("Aplikacijaa.Models.ContactInfo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address");

                    b.Property<string>("Email");

                    b.Property<string>("Phone");

                    b.HasKey("Id");

                    b.ToTable("Contact");
                });

            modelBuilder.Entity("Aplikacijaa.Models.Gender", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("UserGender");

                    b.HasKey("Id");

                    b.ToTable("Gender");
                });

            modelBuilder.Entity("Aplikacijaa.Models.ProfileInfo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PasswordSalt");

                    b.Property<string>("Username");

                    b.HasKey("Id");

                    b.ToTable("ProfileInfo");
                });

            modelBuilder.Entity("Aplikacijaa.Models.Student", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CityId");

                    b.Property<int>("ContactId");

                    b.Property<int?>("ContactInfoId");

                    b.Property<DateTime>("DateAdded");

                    b.Property<DateTime>("DateOfBirth");

                    b.Property<string>("FName");

                    b.Property<int>("GenderId");

                    b.Property<string>("LName");

                    b.Property<int>("ProfieInforId");

                    b.Property<int?>("ProfileInfoId");

                    b.Property<byte[]>("ProfilePicture");

                    b.Property<int>("StatusId");

                    b.Property<int>("StudentTypeId");

                    b.Property<int?>("UserStatusId");

                    b.HasKey("Id");

                    b.HasIndex("CityId");

                    b.HasIndex("ContactInfoId");

                    b.HasIndex("GenderId");

                    b.HasIndex("ProfileInfoId");

                    b.HasIndex("StudentTypeId");

                    b.HasIndex("UserStatusId");

                    b.ToTable("Student");
                });

            modelBuilder.Entity("Aplikacijaa.Models.StudentType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Type");

                    b.HasKey("Id");

                    b.ToTable("StudentType");
                });

            modelBuilder.Entity("Aplikacijaa.Models.UserStatus", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Status");

                    b.HasKey("Id");

                    b.ToTable("UserStatus");
                });

            modelBuilder.Entity("Aplikacijaa.Models.Student", b =>
                {
                    b.HasOne("Aplikacijaa.Models.City", "City")
                        .WithMany()
                        .HasForeignKey("CityId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Aplikacijaa.Models.ContactInfo", "ContactInfo")
                        .WithMany()
                        .HasForeignKey("ContactInfoId");

                    b.HasOne("Aplikacijaa.Models.Gender", "Gender")
                        .WithMany()
                        .HasForeignKey("GenderId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Aplikacijaa.Models.ProfileInfo", "ProfileInfo")
                        .WithMany()
                        .HasForeignKey("ProfileInfoId");

                    b.HasOne("Aplikacijaa.Models.StudentType", "StudentType")
                        .WithMany()
                        .HasForeignKey("StudentTypeId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Aplikacijaa.Models.UserStatus", "UserStatus")
                        .WithMany()
                        .HasForeignKey("UserStatusId");
                });
#pragma warning restore 612, 618
        }
    }
}
