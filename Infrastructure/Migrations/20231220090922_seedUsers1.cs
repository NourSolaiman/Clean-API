using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class seedUsers1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Birds",
                keyColumn: "Id",
                keyValue: new Guid("346c907e-0445-4e7a-a99e-5b6a67db93d0"));

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.InsertData(
                table: "Birds",
                columns: new[] { "Id", "Breed", "CanFly", "Color", "Name", "Weight" },
                values: new object[,]
                {
                    { new Guid("346c907e-0445-4e7a-a99e-5b6a67db93d0"), "", true, "", "Gerdy", 0 },
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
                    { new Guid("290712e6-4723-4001-b172-4d7b49709777"), "", "", false, "PeppeLeDog", 0 },
                    { new Guid("70e0fb8d-305e-4627-8314-8ab479451270"), "", "", false, "Simo", 0 },
                    { new Guid("8560a41e-c2ad-41f3-8f28-90cb9fbd683c"), "", "", false, "Lano", 0 },
                    { new Guid("dc07f79d-ee8c-4040-839f-e52141774894"), "", "", false, "Fofi", 0 }
                });
        }
    }
}
