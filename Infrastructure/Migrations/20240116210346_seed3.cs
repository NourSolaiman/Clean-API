using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class seed3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Animal",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Discriminator = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CanFly = table.Column<bool>(type: "tinyint(1)", nullable: true),
                    BirdColor = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    LikesToPlay = table.Column<bool>(type: "tinyint(1)", nullable: true),
                    CatBreed = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CatWeight = table.Column<int>(type: "int", nullable: true),
                    DogBreed = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DogWeight = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Animal", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Username = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PasswordHash = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "UserAnimals",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    AnimalId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserAnimals", x => new { x.UserId, x.AnimalId });
                    table.ForeignKey(
                        name: "FK_UserAnimals_Animal_AnimalId",
                        column: x => x.AnimalId,
                        principalTable: "Animal",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserAnimals_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "Animal",
                columns: new[] { "Id", "Discriminator", "DogBreed", "DogWeight", "Name" },
                values: new object[] { new Guid("264fd9bf-c307-40a6-bf10-626d398c3bfc"), "Dog", "Golden", 5, "PeppeLeDog" });

            migrationBuilder.InsertData(
                table: "Animal",
                columns: new[] { "Id", "BirdColor", "CanFly", "Discriminator", "Name" },
                values: new object[] { new Guid("305dd3e8-9ffa-46b2-9764-bd21af49cf11"), "Red", true, "Bird", "Sparrow" });

            migrationBuilder.InsertData(
                table: "Animal",
                columns: new[] { "Id", "Discriminator", "DogBreed", "DogWeight", "Name" },
                values: new object[] { new Guid("43f822e2-57df-463b-96da-71cbed823c6e"), "Dog", "Beagle", 7, "Lano" });

            migrationBuilder.InsertData(
                table: "Animal",
                columns: new[] { "Id", "BirdColor", "CanFly", "Discriminator", "Name" },
                values: new object[] { new Guid("5feeefb9-fb7a-472f-8e8c-ac9a13ef5246"), "Green", true, "Bird", "Robin" });

            migrationBuilder.InsertData(
                table: "Animal",
                columns: new[] { "Id", "CatBreed", "CatWeight", "Discriminator", "LikesToPlay", "Name" },
                values: new object[] { new Guid("71d20b76-b626-4a11-959d-b401c4c910cc"), "Fluffy", 2, "Cat", true, "Nugget" });

            migrationBuilder.InsertData(
                table: "Animal",
                columns: new[] { "Id", "BirdColor", "CanFly", "Discriminator", "Name" },
                values: new object[] { new Guid("8ef1e9b3-7e6f-4d80-a301-7f099caf7384"), "Gray", true, "Bird", "Herdy" });

            migrationBuilder.InsertData(
                table: "Animal",
                columns: new[] { "Id", "CatBreed", "CatWeight", "Discriminator", "LikesToPlay", "Name" },
                values: new object[,]
                {
                    { new Guid("a3558d5c-0523-4bfc-b40d-905060da5307"), "Lion", 8, "Cat", true, "Lickers" },
                    { new Guid("c969ec03-a8e3-4ca5-b89d-d3ffc496b9bf"), "Shirazi", 7, "Cat", true, "Sickers" }
                });

            migrationBuilder.InsertData(
                table: "Animal",
                columns: new[] { "Id", "Discriminator", "DogBreed", "DogWeight", "Name" },
                values: new object[] { new Guid("e76d8f1a-2d76-4243-b3f2-5ded7adcd59b"), "Dog", "Poodle", 9, "Fofi" });

            migrationBuilder.InsertData(
                table: "Animal",
                columns: new[] { "Id", "CatBreed", "CatWeight", "Discriminator", "LikesToPlay", "Name" },
                values: new object[] { new Guid("e8286483-6b7a-4821-bcb8-dec13430df44"), "NakedCat", 6, "Cat", true, "Whiskers" });

            migrationBuilder.InsertData(
                table: "Animal",
                columns: new[] { "Id", "BirdColor", "CanFly", "Discriminator", "Name" },
                values: new object[] { new Guid("ef89366c-7f34-4d2f-b059-35d87a5cca39"), "Blue", true, "Bird", "Birdy" });

            migrationBuilder.InsertData(
                table: "Animal",
                columns: new[] { "Id", "Discriminator", "DogBreed", "DogWeight", "Name" },
                values: new object[] { new Guid("f428c8eb-23eb-4538-81df-9c712f587f2e"), "Dog", "Chihuahua", 4, "Simo" });

            migrationBuilder.CreateIndex(
                name: "IX_UserAnimals_AnimalId",
                table: "UserAnimals",
                column: "AnimalId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserAnimals");

            migrationBuilder.DropTable(
                name: "Animal");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
