using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class seedsanimal : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Birds",
                keyColumn: "Id",
                keyValue: new Guid("09684bdd-1c89-4d9c-a7ea-8642ac8a9f60"));

            migrationBuilder.DeleteData(
                table: "Birds",
                keyColumn: "Id",
                keyValue: new Guid("a02c66a5-cc42-4560-9bdf-8f78ec35cc07"));

            migrationBuilder.DeleteData(
                table: "Birds",
                keyColumn: "Id",
                keyValue: new Guid("a64ff64e-b605-4dd8-b4d5-11c7a1897cd4"));

            migrationBuilder.DeleteData(
                table: "Birds",
                keyColumn: "Id",
                keyValue: new Guid("b81a6939-8f29-4383-871d-c41d8d63dc4b"));

            migrationBuilder.DeleteData(
                table: "Birds",
                keyColumn: "Id",
                keyValue: new Guid("f5d3c492-e1e6-4706-bd15-39e99281d976"));

            migrationBuilder.DeleteData(
                table: "Cats",
                keyColumn: "Id",
                keyValue: new Guid("54e25121-8d37-47a3-8cba-5b1b2afd4cbb"));

            migrationBuilder.DeleteData(
                table: "Cats",
                keyColumn: "Id",
                keyValue: new Guid("9506de49-4f7b-4428-97f6-762a0c7e8840"));

            migrationBuilder.DeleteData(
                table: "Cats",
                keyColumn: "Id",
                keyValue: new Guid("c76529be-0b0a-4fee-bf28-b7b3ca0505c9"));

            migrationBuilder.DeleteData(
                table: "Cats",
                keyColumn: "Id",
                keyValue: new Guid("eabfc4d6-4680-4bf0-a6d1-65194a105d79"));

            migrationBuilder.DeleteData(
                table: "Cats",
                keyColumn: "Id",
                keyValue: new Guid("eae989ad-3287-414b-b54b-385eb62e176d"));

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
    }
}
