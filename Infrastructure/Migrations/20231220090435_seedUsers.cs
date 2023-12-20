using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class seedUsers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Birds",
                keyColumn: "Id",
                keyValue: new Guid("1ef3c1f4-a313-4448-b3e5-aadf55b3d7f5"));

            migrationBuilder.DeleteData(
                table: "Birds",
                keyColumn: "Id",
                keyValue: new Guid("2ce18000-396d-41cb-955f-770b7940fe78"));

            migrationBuilder.DeleteData(
                table: "Birds",
                keyColumn: "Id",
                keyValue: new Guid("84bedb48-16cd-4829-99bd-dc888b476c97"));

            migrationBuilder.DeleteData(
                table: "Birds",
                keyColumn: "Id",
                keyValue: new Guid("c529eead-435c-4a3f-a8f5-a3639fc9be65"));

            migrationBuilder.DeleteData(
                table: "Birds",
                keyColumn: "Id",
                keyValue: new Guid("ec351eb4-fdb8-42fb-ba13-ea797b4cce17"));

            migrationBuilder.DeleteData(
                table: "Cats",
                keyColumn: "Id",
                keyValue: new Guid("282136bf-ed11-4eaa-95ac-5fe8e2ecd7f8"));

            migrationBuilder.DeleteData(
                table: "Cats",
                keyColumn: "Id",
                keyValue: new Guid("5886fa40-a54e-4c8d-8612-48cf983b2bde"));

            migrationBuilder.DeleteData(
                table: "Cats",
                keyColumn: "Id",
                keyValue: new Guid("9dd335d5-a8d4-44b9-96e9-cd35d35d0f69"));

            migrationBuilder.DeleteData(
                table: "Cats",
                keyColumn: "Id",
                keyValue: new Guid("d30ae68e-5bed-4b73-9527-30f6378989da"));

            migrationBuilder.DeleteData(
                table: "Cats",
                keyColumn: "Id",
                keyValue: new Guid("f840a52f-207c-4741-9f3f-f3bfac0c4cf4"));

            migrationBuilder.DeleteData(
                table: "Dogs",
                keyColumn: "Id",
                keyValue: new Guid("3344e313-83f8-49c5-8c3f-0176cd5bfdb9"));

            migrationBuilder.DeleteData(
                table: "Dogs",
                keyColumn: "Id",
                keyValue: new Guid("804577a8-7271-4fa3-96db-62d287dd42ac"));

            migrationBuilder.DeleteData(
                table: "Dogs",
                keyColumn: "Id",
                keyValue: new Guid("c555e635-f270-4ea9-a1a7-86486bf48176"));

            migrationBuilder.DeleteData(
                table: "Dogs",
                keyColumn: "Id",
                keyValue: new Guid("dae7919a-9e55-4484-a567-31edd78379e7"));

            migrationBuilder.AddColumn<string>(
                name: "Breed",
                table: "Dogs",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Color",
                table: "Dogs",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<int>(
                name: "Weight",
                table: "Dogs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Breed",
                table: "Cats",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Color",
                table: "Cats",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<int>(
                name: "Weight",
                table: "Cats",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Breed",
                table: "Birds",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Color",
                table: "Birds",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<int>(
                name: "Weight",
                table: "Birds",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "UserBird",
                columns: table => new
                {
                    BirdId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    UserId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserBird", x => new { x.BirdId, x.UserId });
                    table.ForeignKey(
                        name: "FK_UserBird_Birds_BirdId",
                        column: x => x.BirdId,
                        principalTable: "Birds",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserBird_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "UserCat",
                columns: table => new
                {
                    CatId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    UserId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserCat", x => new { x.CatId, x.UserId });
                    table.ForeignKey(
                        name: "FK_UserCat_Cats_CatId",
                        column: x => x.CatId,
                        principalTable: "Cats",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserCat_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "UserDog",
                columns: table => new
                {
                    DogId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    UserId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserDog", x => new { x.DogId, x.UserId });
                    table.ForeignKey(
                        name: "FK_UserDog_Dogs_DogId",
                        column: x => x.DogId,
                        principalTable: "Dogs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserDog_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "Birds",
                columns: new[] { "Id", "Breed", "CanFly", "Color", "Name", "Weight" },
                values: new object[,]
                {
                    { new Guid("346c907e-0445-4e7a-a99e-5b6a67db93d0"), "", true, "", "Gerdy", 0 },
                    { new Guid("59d8fc74-3c94-4ed8-9a38-36b0b6b1074a"), "", false, "", "TestBirdForUnitTests", 0 },
                    { new Guid("5ff05880-c1ba-40af-a8de-d7705ba6375a"), "", true, "", "Robin", 0 },
                    { new Guid("731fd909-6968-431a-ac7e-418aee076b7b"), "", true, "", "Birdy", 0 },
                    { new Guid("842726c1-df7f-44be-859c-fe577f8e2a71"), "", true, "", "Sparrow", 0 },
                    { new Guid("85872dca-d934-4823-8c5f-59ccfb0f419f"), "", false, "", "Herdy", 0 }
                });

            migrationBuilder.InsertData(
                table: "Cats",
                columns: new[] { "Id", "Breed", "Color", "LikesToPlay", "Name", "Weight" },
                values: new object[,]
                {
                    { new Guid("77c90efe-3c6a-4f70-b9ae-cebd87a30a0b"), "", "", false, "Lickers", 0 },
                    { new Guid("7e910a6d-8621-4f4b-8a0c-5e199f42eaa5"), "", "", false, "TestCatForUnitTests", 0 },
                    { new Guid("80f80048-698e-41fd-9e60-0576c997ee38"), "", "", false, "Fluffers", 0 },
                    { new Guid("849e9fff-07bb-4045-94fd-9ef1d61084e4"), "", "", false, "Whiskers", 0 },
                    { new Guid("cf18365b-f6dc-443d-bd41-79e985cb714a"), "", "", true, "Sickers", 0 },
                    { new Guid("fd22425d-6efd-4d5d-894d-75607a5cd26b"), "", "", true, "Fluffy", 0 }
                });

            migrationBuilder.InsertData(
                table: "Dogs",
                columns: new[] { "Id", "Breed", "Color", "LikesToPlay", "Name", "Weight" },
                values: new object[,]
                {
                    { new Guid("12345678-1234-5678-1234-567812345678"), "", "", false, "TestDogForUnitTests", 0 },
                    { new Guid("290712e6-4723-4001-b172-4d7b49709777"), "", "", false, "PeppeLeDog", 0 },
                    { new Guid("70e0fb8d-305e-4627-8314-8ab479451270"), "", "", false, "Simo", 0 },
                    { new Guid("8560a41e-c2ad-41f3-8f28-90cb9fbd683c"), "", "", false, "Lano", 0 },
                    { new Guid("dc07f79d-ee8c-4040-839f-e52141774894"), "", "", false, "Fofi", 0 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserBird_UserId",
                table: "UserBird",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserCat_UserId",
                table: "UserCat",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserDog_UserId",
                table: "UserDog",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserBird");

            migrationBuilder.DropTable(
                name: "UserCat");

            migrationBuilder.DropTable(
                name: "UserDog");

            migrationBuilder.DeleteData(
                table: "Birds",
                keyColumn: "Id",
                keyValue: new Guid("346c907e-0445-4e7a-a99e-5b6a67db93d0"));

            migrationBuilder.DeleteData(
                table: "Birds",
                keyColumn: "Id",
                keyValue: new Guid("59d8fc74-3c94-4ed8-9a38-36b0b6b1074a"));

            migrationBuilder.DeleteData(
                table: "Birds",
                keyColumn: "Id",
                keyValue: new Guid("5ff05880-c1ba-40af-a8de-d7705ba6375a"));

            migrationBuilder.DeleteData(
                table: "Birds",
                keyColumn: "Id",
                keyValue: new Guid("731fd909-6968-431a-ac7e-418aee076b7b"));

            migrationBuilder.DeleteData(
                table: "Birds",
                keyColumn: "Id",
                keyValue: new Guid("842726c1-df7f-44be-859c-fe577f8e2a71"));

            migrationBuilder.DeleteData(
                table: "Birds",
                keyColumn: "Id",
                keyValue: new Guid("85872dca-d934-4823-8c5f-59ccfb0f419f"));

            migrationBuilder.DeleteData(
                table: "Cats",
                keyColumn: "Id",
                keyValue: new Guid("77c90efe-3c6a-4f70-b9ae-cebd87a30a0b"));

            migrationBuilder.DeleteData(
                table: "Cats",
                keyColumn: "Id",
                keyValue: new Guid("7e910a6d-8621-4f4b-8a0c-5e199f42eaa5"));

            migrationBuilder.DeleteData(
                table: "Cats",
                keyColumn: "Id",
                keyValue: new Guid("80f80048-698e-41fd-9e60-0576c997ee38"));

            migrationBuilder.DeleteData(
                table: "Cats",
                keyColumn: "Id",
                keyValue: new Guid("849e9fff-07bb-4045-94fd-9ef1d61084e4"));

            migrationBuilder.DeleteData(
                table: "Cats",
                keyColumn: "Id",
                keyValue: new Guid("cf18365b-f6dc-443d-bd41-79e985cb714a"));

            migrationBuilder.DeleteData(
                table: "Cats",
                keyColumn: "Id",
                keyValue: new Guid("fd22425d-6efd-4d5d-894d-75607a5cd26b"));

            migrationBuilder.DeleteData(
                table: "Dogs",
                keyColumn: "Id",
                keyValue: new Guid("12345678-1234-5678-1234-567812345678"));

            migrationBuilder.DeleteData(
                table: "Dogs",
                keyColumn: "Id",
                keyValue: new Guid("290712e6-4723-4001-b172-4d7b49709777"));

            migrationBuilder.DeleteData(
                table: "Dogs",
                keyColumn: "Id",
                keyValue: new Guid("70e0fb8d-305e-4627-8314-8ab479451270"));

            migrationBuilder.DeleteData(
                table: "Dogs",
                keyColumn: "Id",
                keyValue: new Guid("8560a41e-c2ad-41f3-8f28-90cb9fbd683c"));

            migrationBuilder.DeleteData(
                table: "Dogs",
                keyColumn: "Id",
                keyValue: new Guid("dc07f79d-ee8c-4040-839f-e52141774894"));

            migrationBuilder.DropColumn(
                name: "Breed",
                table: "Dogs");

            migrationBuilder.DropColumn(
                name: "Color",
                table: "Dogs");

            migrationBuilder.DropColumn(
                name: "Weight",
                table: "Dogs");

            migrationBuilder.DropColumn(
                name: "Breed",
                table: "Cats");

            migrationBuilder.DropColumn(
                name: "Color",
                table: "Cats");

            migrationBuilder.DropColumn(
                name: "Weight",
                table: "Cats");

            migrationBuilder.DropColumn(
                name: "Breed",
                table: "Birds");

            migrationBuilder.DropColumn(
                name: "Color",
                table: "Birds");

            migrationBuilder.DropColumn(
                name: "Weight",
                table: "Birds");

            migrationBuilder.InsertData(
                table: "Birds",
                columns: new[] { "Id", "CanFly", "Name" },
                values: new object[,]
                {
                    { new Guid("1ef3c1f4-a313-4448-b3e5-aadf55b3d7f5"), false, "Herdy" },
                    { new Guid("2ce18000-396d-41cb-955f-770b7940fe78"), true, "Sparrow" },
                    { new Guid("84bedb48-16cd-4829-99bd-dc888b476c97"), true, "Birdy" },
                    { new Guid("c529eead-435c-4a3f-a8f5-a3639fc9be65"), true, "Gerdy" },
                    { new Guid("ec351eb4-fdb8-42fb-ba13-ea797b4cce17"), true, "Robin" }
                });

            migrationBuilder.InsertData(
                table: "Cats",
                columns: new[] { "Id", "LikesToPlay", "Name" },
                values: new object[,]
                {
                    { new Guid("282136bf-ed11-4eaa-95ac-5fe8e2ecd7f8"), false, "Fluffers" },
                    { new Guid("5886fa40-a54e-4c8d-8612-48cf983b2bde"), false, "Whiskers" },
                    { new Guid("9dd335d5-a8d4-44b9-96e9-cd35d35d0f69"), false, "Lickers" },
                    { new Guid("d30ae68e-5bed-4b73-9527-30f6378989da"), true, "Fluffy" },
                    { new Guid("f840a52f-207c-4741-9f3f-f3bfac0c4cf4"), true, "Sickers" }
                });

            migrationBuilder.InsertData(
                table: "Dogs",
                columns: new[] { "Id", "LikesToPlay", "Name" },
                values: new object[,]
                {
                    { new Guid("3344e313-83f8-49c5-8c3f-0176cd5bfdb9"), false, "Lano" },
                    { new Guid("804577a8-7271-4fa3-96db-62d287dd42ac"), false, "Simo" },
                    { new Guid("c555e635-f270-4ea9-a1a7-86486bf48176"), false, "PeppeLeDog" },
                    { new Guid("dae7919a-9e55-4484-a567-31edd78379e7"), false, "Fofi" }
                });
        }
    }
}
