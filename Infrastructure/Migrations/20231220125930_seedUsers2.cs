using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class seedUsers2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Birds",
                keyColumn: "Id",
                keyValue: new Guid("2a6b452d-2f97-41e2-95af-0d10d17ae9a8"));

            migrationBuilder.DeleteData(
                table: "Birds",
                keyColumn: "Id",
                keyValue: new Guid("7382ed16-7035-4e10-a37b-fbec530e2dfd"));

            migrationBuilder.DeleteData(
                table: "Birds",
                keyColumn: "Id",
                keyValue: new Guid("a0f4e1d4-280f-436f-9f3a-70bd46bb190a"));

            migrationBuilder.DeleteData(
                table: "Birds",
                keyColumn: "Id",
                keyValue: new Guid("db1e0c98-be46-49a2-8a15-068e9b6299b8"));

            migrationBuilder.DeleteData(
                table: "Birds",
                keyColumn: "Id",
                keyValue: new Guid("ff7f673f-7bcd-4109-aec6-66b9848bfa24"));

            migrationBuilder.DeleteData(
                table: "Cats",
                keyColumn: "Id",
                keyValue: new Guid("02b396db-9751-45f9-8543-67e759a26412"));

            migrationBuilder.DeleteData(
                table: "Cats",
                keyColumn: "Id",
                keyValue: new Guid("573aa112-9ed0-4139-845b-5b0183bf811d"));

            migrationBuilder.DeleteData(
                table: "Cats",
                keyColumn: "Id",
                keyValue: new Guid("88a38257-aeef-4ffb-859d-6e992f1a2397"));

            migrationBuilder.DeleteData(
                table: "Cats",
                keyColumn: "Id",
                keyValue: new Guid("dae1efe6-d2a9-4e24-8b25-2a508b3dd268"));

            migrationBuilder.DeleteData(
                table: "Cats",
                keyColumn: "Id",
                keyValue: new Guid("f61a056b-d0d5-483c-8d43-38431b9f529c"));

            migrationBuilder.DeleteData(
                table: "Dogs",
                keyColumn: "Id",
                keyValue: new Guid("5e0cef03-f5e9-4038-a3a3-ad369996acc2"));

            migrationBuilder.DeleteData(
                table: "Dogs",
                keyColumn: "Id",
                keyValue: new Guid("64c25c48-49bb-43df-8731-f78a8a5c4ef5"));

            migrationBuilder.DeleteData(
                table: "Dogs",
                keyColumn: "Id",
                keyValue: new Guid("acdf4a4f-25a2-444b-a30e-36265609d7f3"));

            migrationBuilder.DeleteData(
                table: "Dogs",
                keyColumn: "Id",
                keyValue: new Guid("e3dff0a4-1f8b-4382-b3d7-acdbc9644992"));

            migrationBuilder.DropColumn(
                name: "Breed",
                table: "Birds");

            migrationBuilder.DropColumn(
                name: "Weight",
                table: "Birds");

            migrationBuilder.InsertData(
                table: "Birds",
                columns: new[] { "Id", "CanFly", "Color", "Name" },
                values: new object[,]
                {
                    { new Guid("59d035bb-53b5-4bb4-a69e-3ab00b446bdf"), true, "", "Sparrow" },
                    { new Guid("92eb2daa-8a56-4580-af4f-d1c0177c08f8"), true, "", "Robin" },
                    { new Guid("c632f334-9c08-4961-b523-e4dd5fc48150"), true, "", "Birdy" },
                    { new Guid("dcf4f387-6d9f-4999-a61e-b4d879f59edf"), false, "", "Herdy" },
                    { new Guid("fc48da49-c140-42fc-bb5b-f52a1839d415"), true, "", "Gerdy" }
                });

            migrationBuilder.InsertData(
                table: "Cats",
                columns: new[] { "Id", "Breed", "Color", "LikesToPlay", "Name", "Weight" },
                values: new object[,]
                {
                    { new Guid("04cf4d4a-57f7-4530-bab2-8663e06d9168"), "", "", false, "Whiskers", 0 },
                    { new Guid("405bb583-0f6e-4927-9274-75636da50e11"), "", "", true, "Sickers", 0 },
                    { new Guid("5318f313-7ebc-43e4-b32a-f9e1dfe9365d"), "", "", false, "Fluffers", 0 },
                    { new Guid("9f567f68-fb83-4e94-8fd0-aaf24a1130ad"), "", "", true, "Fluffy", 0 },
                    { new Guid("fa89151f-1a7d-47d1-86a2-4ad5dbbc0a22"), "", "", false, "Lickers", 0 }
                });

            migrationBuilder.InsertData(
                table: "Dogs",
                columns: new[] { "Id", "Breed", "Color", "LikesToPlay", "Name", "Weight" },
                values: new object[,]
                {
                    { new Guid("583d2d49-3e37-44bd-85e5-8ede3f511a6c"), "", "", false, "Simo", 0 },
                    { new Guid("78f464db-9946-43d8-93a1-bfb95b0e1338"), "", "", false, "Fofi", 0 },
                    { new Guid("9f3c2364-8955-4f73-9dfc-ab21a82797e7"), "", "", false, "PeppeLeDog", 0 },
                    { new Guid("ec9ffb12-9f87-450d-b7de-4fbaf91d43dc"), "", "", false, "Lano", 0 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Birds",
                keyColumn: "Id",
                keyValue: new Guid("59d035bb-53b5-4bb4-a69e-3ab00b446bdf"));

            migrationBuilder.DeleteData(
                table: "Birds",
                keyColumn: "Id",
                keyValue: new Guid("92eb2daa-8a56-4580-af4f-d1c0177c08f8"));

            migrationBuilder.DeleteData(
                table: "Birds",
                keyColumn: "Id",
                keyValue: new Guid("c632f334-9c08-4961-b523-e4dd5fc48150"));

            migrationBuilder.DeleteData(
                table: "Birds",
                keyColumn: "Id",
                keyValue: new Guid("dcf4f387-6d9f-4999-a61e-b4d879f59edf"));

            migrationBuilder.DeleteData(
                table: "Birds",
                keyColumn: "Id",
                keyValue: new Guid("fc48da49-c140-42fc-bb5b-f52a1839d415"));

            migrationBuilder.DeleteData(
                table: "Cats",
                keyColumn: "Id",
                keyValue: new Guid("04cf4d4a-57f7-4530-bab2-8663e06d9168"));

            migrationBuilder.DeleteData(
                table: "Cats",
                keyColumn: "Id",
                keyValue: new Guid("405bb583-0f6e-4927-9274-75636da50e11"));

            migrationBuilder.DeleteData(
                table: "Cats",
                keyColumn: "Id",
                keyValue: new Guid("5318f313-7ebc-43e4-b32a-f9e1dfe9365d"));

            migrationBuilder.DeleteData(
                table: "Cats",
                keyColumn: "Id",
                keyValue: new Guid("9f567f68-fb83-4e94-8fd0-aaf24a1130ad"));

            migrationBuilder.DeleteData(
                table: "Cats",
                keyColumn: "Id",
                keyValue: new Guid("fa89151f-1a7d-47d1-86a2-4ad5dbbc0a22"));

            migrationBuilder.DeleteData(
                table: "Dogs",
                keyColumn: "Id",
                keyValue: new Guid("583d2d49-3e37-44bd-85e5-8ede3f511a6c"));

            migrationBuilder.DeleteData(
                table: "Dogs",
                keyColumn: "Id",
                keyValue: new Guid("78f464db-9946-43d8-93a1-bfb95b0e1338"));

            migrationBuilder.DeleteData(
                table: "Dogs",
                keyColumn: "Id",
                keyValue: new Guid("9f3c2364-8955-4f73-9dfc-ab21a82797e7"));

            migrationBuilder.DeleteData(
                table: "Dogs",
                keyColumn: "Id",
                keyValue: new Guid("ec9ffb12-9f87-450d-b7de-4fbaf91d43dc"));

            migrationBuilder.AddColumn<string>(
                name: "Breed",
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

            migrationBuilder.UpdateData(
                table: "Birds",
                keyColumn: "Id",
                keyValue: new Guid("59d8fc74-3c94-4ed8-9a38-36b0b6b1074a"),
                columns: new[] { "Breed", "Weight" },
                values: new object[] { "", 0 });

            migrationBuilder.InsertData(
                table: "Birds",
                columns: new[] { "Id", "Breed", "CanFly", "Color", "Name", "Weight" },
                values: new object[,]
                {
                    { new Guid("2a6b452d-2f97-41e2-95af-0d10d17ae9a8"), "", true, "", "Birdy", 0 },
                    { new Guid("7382ed16-7035-4e10-a37b-fbec530e2dfd"), "", true, "", "Robin", 0 },
                    { new Guid("a0f4e1d4-280f-436f-9f3a-70bd46bb190a"), "", false, "", "Herdy", 0 },
                    { new Guid("db1e0c98-be46-49a2-8a15-068e9b6299b8"), "", true, "", "Sparrow", 0 },
                    { new Guid("ff7f673f-7bcd-4109-aec6-66b9848bfa24"), "", true, "", "Gerdy", 0 }
                });

            migrationBuilder.InsertData(
                table: "Cats",
                columns: new[] { "Id", "Breed", "Color", "LikesToPlay", "Name", "Weight" },
                values: new object[,]
                {
                    { new Guid("02b396db-9751-45f9-8543-67e759a26412"), "", "", false, "Whiskers", 0 },
                    { new Guid("573aa112-9ed0-4139-845b-5b0183bf811d"), "", "", true, "Fluffy", 0 },
                    { new Guid("88a38257-aeef-4ffb-859d-6e992f1a2397"), "", "", false, "Lickers", 0 },
                    { new Guid("dae1efe6-d2a9-4e24-8b25-2a508b3dd268"), "", "", true, "Sickers", 0 },
                    { new Guid("f61a056b-d0d5-483c-8d43-38431b9f529c"), "", "", false, "Fluffers", 0 }
                });

            migrationBuilder.InsertData(
                table: "Dogs",
                columns: new[] { "Id", "Breed", "Color", "LikesToPlay", "Name", "Weight" },
                values: new object[,]
                {
                    { new Guid("5e0cef03-f5e9-4038-a3a3-ad369996acc2"), "", "", false, "Simo", 0 },
                    { new Guid("64c25c48-49bb-43df-8731-f78a8a5c4ef5"), "", "", false, "Lano", 0 },
                    { new Guid("acdf4a4f-25a2-444b-a30e-36265609d7f3"), "", "", false, "Fofi", 0 },
                    { new Guid("e3dff0a4-1f8b-4382-b3d7-acdbc9644992"), "", "", false, "PeppeLeDog", 0 }
                });
        }
    }
}
