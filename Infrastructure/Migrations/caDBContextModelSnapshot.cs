﻿// <auto-generated />
using System;
using Infrastructure.Database.MySQLDatabase;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Infrastructure.Migrations
{
    [DbContext(typeof(caDBContext))]
    partial class caDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Domain.Models.Animal", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Animal");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Animal");

                    b.UseTphMappingStrategy();
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

            modelBuilder.Entity("Domain.Models.UserAnimal", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("char(36)");

                    b.Property<Guid>("AnimalId")
                        .HasColumnType("char(36)");

                    b.HasKey("UserId", "AnimalId");

                    b.HasIndex("AnimalId");

                    b.ToTable("UserAnimals");
                });

            modelBuilder.Entity("Domain.Models.Bird", b =>
                {
                    b.HasBaseType("Domain.Models.Animal");

                    b.Property<string>("BirdColor")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<bool>("CanFly")
                        .HasColumnType("tinyint(1)");

                    b.HasDiscriminator().HasValue("Bird");

                    b.HasData(
                        new
                        {
                            Id = new Guid("5feeefb9-fb7a-472f-8e8c-ac9a13ef5246"),
                            Name = "Robin",
                            BirdColor = "Green",
                            CanFly = true
                        },
                        new
                        {
                            Id = new Guid("305dd3e8-9ffa-46b2-9764-bd21af49cf11"),
                            Name = "Sparrow",
                            BirdColor = "Red",
                            CanFly = true
                        },
                        new
                        {
                            Id = new Guid("ef89366c-7f34-4d2f-b059-35d87a5cca39"),
                            Name = "Birdy",
                            BirdColor = "Blue",
                            CanFly = true
                        },
                        new
                        {
                            Id = new Guid("8ef1e9b3-7e6f-4d80-a301-7f099caf7384"),
                            Name = "Herdy",
                            BirdColor = "Gray",
                            CanFly = true
                        });
                });

            modelBuilder.Entity("Domain.Models.Cat", b =>
                {
                    b.HasBaseType("Domain.Models.Animal");

                    b.Property<string>("CatBreed")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("CatWeight")
                        .HasColumnType("int");

                    b.Property<bool>("LikesToPlay")
                        .HasColumnType("tinyint(1)");

                    b.HasDiscriminator().HasValue("Cat");

                    b.HasData(
                        new
                        {
                            Id = new Guid("71d20b76-b626-4a11-959d-b401c4c910cc"),
                            Name = "Nugget",
                            CatBreed = "Fluffy",
                            CatWeight = 2,
                            LikesToPlay = true
                        },
                        new
                        {
                            Id = new Guid("e8286483-6b7a-4821-bcb8-dec13430df44"),
                            Name = "Whiskers",
                            CatBreed = "NakedCat",
                            CatWeight = 6,
                            LikesToPlay = true
                        },
                        new
                        {
                            Id = new Guid("a3558d5c-0523-4bfc-b40d-905060da5307"),
                            Name = "Lickers",
                            CatBreed = "Lion",
                            CatWeight = 8,
                            LikesToPlay = true
                        },
                        new
                        {
                            Id = new Guid("c969ec03-a8e3-4ca5-b89d-d3ffc496b9bf"),
                            Name = "Sickers",
                            CatBreed = "Shirazi",
                            CatWeight = 7,
                            LikesToPlay = true
                        });
                });

            modelBuilder.Entity("Domain.Models.Dog", b =>
                {
                    b.HasBaseType("Domain.Models.Animal");

                    b.Property<string>("DogBreed")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("DogWeight")
                        .HasColumnType("int");

                    b.HasDiscriminator().HasValue("Dog");

                    b.HasData(
                        new
                        {
                            Id = new Guid("264fd9bf-c307-40a6-bf10-626d398c3bfc"),
                            Name = "PeppeLeDog",
                            DogBreed = "Golden",
                            DogWeight = 5
                        },
                        new
                        {
                            Id = new Guid("e76d8f1a-2d76-4243-b3f2-5ded7adcd59b"),
                            Name = "Fofi",
                            DogBreed = "Poodle",
                            DogWeight = 9
                        },
                        new
                        {
                            Id = new Guid("f428c8eb-23eb-4538-81df-9c712f587f2e"),
                            Name = "Simo",
                            DogBreed = "Chihuahua",
                            DogWeight = 4
                        },
                        new
                        {
                            Id = new Guid("43f822e2-57df-463b-96da-71cbed823c6e"),
                            Name = "Lano",
                            DogBreed = "Beagle",
                            DogWeight = 7
                        });
                });

            modelBuilder.Entity("Domain.Models.UserAnimal", b =>
                {
                    b.HasOne("Domain.Models.Animal", "Animal")
                        .WithMany("UserAnimals")
                        .HasForeignKey("AnimalId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Models.User", "user")
                        .WithMany("UserAnimals")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Animal");

                    b.Navigation("user");
                });

            modelBuilder.Entity("Domain.Models.Animal", b =>
                {
                    b.Navigation("UserAnimals");
                });

            modelBuilder.Entity("Domain.Models.User", b =>
                {
                    b.Navigation("UserAnimals");
                });
#pragma warning restore 612, 618
        }
    }
}
