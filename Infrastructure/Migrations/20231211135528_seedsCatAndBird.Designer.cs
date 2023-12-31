﻿// <auto-generated />
using System;
using Infrastructure.Database.MySQLDatabase;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Infrastructure.Migrations
{
    [DbContext(typeof(caDBContext))]
    [Migration("20231211135528_seedsCatAndBird")]
    partial class seedsCatAndBird
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Domain.Models.Bird", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<bool>("CanFly")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Birds");

                    b.HasData(
                        new
                        {
                            Id = new Guid("09684bdd-1c89-4d9c-a7ea-8642ac8a9f60"),
                            CanFly = true,
                            Name = "Robin"
                        },
                        new
                        {
                            Id = new Guid("b81a6939-8f29-4383-871d-c41d8d63dc4b"),
                            CanFly = true,
                            Name = "Sparrow"
                        },
                        new
                        {
                            Id = new Guid("f5d3c492-e1e6-4706-bd15-39e99281d976"),
                            CanFly = true,
                            Name = "Birdy"
                        },
                        new
                        {
                            Id = new Guid("a02c66a5-cc42-4560-9bdf-8f78ec35cc07"),
                            CanFly = false,
                            Name = "Herdy"
                        },
                        new
                        {
                            Id = new Guid("a64ff64e-b605-4dd8-b4d5-11c7a1897cd4"),
                            CanFly = true,
                            Name = "Gerdy"
                        });
                });

            modelBuilder.Entity("Domain.Models.Cat", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<bool>("LikesToPlay")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Cats");

                    b.HasData(
                        new
                        {
                            Id = new Guid("54e25121-8d37-47a3-8cba-5b1b2afd4cbb"),
                            LikesToPlay = true,
                            Name = "Fluffy"
                        },
                        new
                        {
                            Id = new Guid("eabfc4d6-4680-4bf0-a6d1-65194a105d79"),
                            LikesToPlay = false,
                            Name = "Whiskers"
                        },
                        new
                        {
                            Id = new Guid("eae989ad-3287-414b-b54b-385eb62e176d"),
                            LikesToPlay = false,
                            Name = "Lickers"
                        },
                        new
                        {
                            Id = new Guid("c76529be-0b0a-4fee-bf28-b7b3ca0505c9"),
                            LikesToPlay = true,
                            Name = "Sickers"
                        },
                        new
                        {
                            Id = new Guid("9506de49-4f7b-4428-97f6-762a0c7e8840"),
                            LikesToPlay = false,
                            Name = "Fluffers"
                        });
                });

            modelBuilder.Entity("Domain.Models.Dog", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<bool>("LikesToPlay")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Dogs");

                    b.HasData(
                        new
                        {
                            Id = new Guid("516bca9c-7e96-42c3-b7d3-18c7622b6425"),
                            LikesToPlay = false,
                            Name = "PeppeLeDog"
                        },
                        new
                        {
                            Id = new Guid("a3a865b8-34c8-49aa-85a8-efdf1666bc05"),
                            LikesToPlay = false,
                            Name = "Fofi"
                        },
                        new
                        {
                            Id = new Guid("c2ec2497-d697-495b-985d-c4f26ab984a9"),
                            LikesToPlay = false,
                            Name = "Simo"
                        },
                        new
                        {
                            Id = new Guid("ecdcad81-c0d5-4def-b828-9325c9bafc66"),
                            LikesToPlay = false,
                            Name = "Lano"
                        });
                });

            modelBuilder.Entity("Domain.Models.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });
#pragma warning restore 612, 618
        }
    }
}
