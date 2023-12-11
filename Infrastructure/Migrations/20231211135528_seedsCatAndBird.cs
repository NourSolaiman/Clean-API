using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class seedsCatAndBird : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "animalId",
                table: "Dogs");

            migrationBuilder.AddColumn<bool>(
                name: "LikesToPlay",
                table: "Dogs",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "Birds",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CanFly = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Birds", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Cats",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    LikesToPlay = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cats", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "Birds",
                columns: new[] { "Id", "CanFly", "Name" },
                values: new object[,]
                {
                    { new Guid("09684bdd-1c89-4d9c-a7ea-8642ac8a9f60"), true, "Robin" },
                    { new Guid("a02c66a5-cc42-4560-9bdf-8f78ec35cc07"), false, "Herdy" },
                    { new Guid("a64ff64e-b605-4dd8-b4d5-11c7a1897cd4"), true, "Gerdy" },
                    { new Guid("b81a6939-8f29-4383-871d-c41d8d63dc4b"), true, "Sparrow" },
                    { new Guid("f5d3c492-e1e6-4706-bd15-39e99281d976"), true, "Birdy" }
                });

            migrationBuilder.InsertData(
                table: "Cats",
                columns: new[] { "Id", "LikesToPlay", "Name" },
                values: new object[,]
                {
                    { new Guid("54e25121-8d37-47a3-8cba-5b1b2afd4cbb"), true, "Fluffy" },
                    { new Guid("9506de49-4f7b-4428-97f6-762a0c7e8840"), false, "Fluffers" },
                    { new Guid("c76529be-0b0a-4fee-bf28-b7b3ca0505c9"), true, "Sickers" },
                    { new Guid("eabfc4d6-4680-4bf0-a6d1-65194a105d79"), false, "Whiskers" },
                    { new Guid("eae989ad-3287-414b-b54b-385eb62e176d"), false, "Lickers" }
                });

            migrationBuilder.InsertData(
                table: "Dogs",
                columns: new[] { "Id", "LikesToPlay", "Name" },
                values: new object[,]
                {
                    { new Guid("516bca9c-7e96-42c3-b7d3-18c7622b6425"), false, "PeppeLeDog" },
                    { new Guid("a3a865b8-34c8-49aa-85a8-efdf1666bc05"), false, "Fofi" },
                    { new Guid("c2ec2497-d697-495b-985d-c4f26ab984a9"), false, "Simo" },
                    { new Guid("ecdcad81-c0d5-4def-b828-9325c9bafc66"), false, "Lano" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Birds");

            migrationBuilder.DropTable(
                name: "Cats");

            migrationBuilder.DeleteData(
                table: "Dogs",
                keyColumn: "Id",
                keyValue: new Guid("516bca9c-7e96-42c3-b7d3-18c7622b6425"));

            migrationBuilder.DeleteData(
                table: "Dogs",
                keyColumn: "Id",
                keyValue: new Guid("a3a865b8-34c8-49aa-85a8-efdf1666bc05"));

            migrationBuilder.DeleteData(
                table: "Dogs",
                keyColumn: "Id",
                keyValue: new Guid("c2ec2497-d697-495b-985d-c4f26ab984a9"));

            migrationBuilder.DeleteData(
                table: "Dogs",
                keyColumn: "Id",
                keyValue: new Guid("ecdcad81-c0d5-4def-b828-9325c9bafc66"));

            migrationBuilder.DropColumn(
                name: "LikesToPlay",
                table: "Dogs");

            migrationBuilder.AddColumn<Guid>(
                name: "animalId",
                table: "Dogs",
                type: "char(36)",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                collation: "ascii_general_ci");
        }
    }
}
