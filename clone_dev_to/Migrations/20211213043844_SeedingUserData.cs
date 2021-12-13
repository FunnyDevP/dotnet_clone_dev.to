using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace clone_dev_to.Migrations
{
    public partial class SeedingUserData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "tags",
                keyColumn: "Id",
                keyValue: new Guid("b3ce1341-d10c-429f-954b-854f55aef90b"),
                column: "created_date",
                value: new DateTime(2021, 12, 13, 4, 38, 44, 244, DateTimeKind.Utc).AddTicks(5500));

            migrationBuilder.UpdateData(
                table: "tags",
                keyColumn: "Id",
                keyValue: new Guid("b3d9e7a8-3c31-4aed-9984-c65c14ef0795"),
                column: "created_date",
                value: new DateTime(2021, 12, 13, 4, 38, 44, 244, DateTimeKind.Utc).AddTicks(5500));

            migrationBuilder.UpdateData(
                table: "tags",
                keyColumn: "Id",
                keyValue: new Guid("d6b1de80-e44e-412e-957e-8a7e64d494f9"),
                column: "created_date",
                value: new DateTime(2021, 12, 13, 4, 38, 44, 244, DateTimeKind.Utc).AddTicks(5510));

            migrationBuilder.UpdateData(
                table: "tags",
                keyColumn: "Id",
                keyValue: new Guid("daf5829d-25d3-4f36-b7f6-e6c8ba26bcd0"),
                column: "created_date",
                value: new DateTime(2021, 12, 13, 4, 38, 44, 244, DateTimeKind.Utc).AddTicks(5510));

            migrationBuilder.InsertData(
                table: "users",
                columns: new[] { "Id", "full_name" },
                values: new object[,]
                {
                    { new Guid("0242f16c-2e5d-4839-ba0d-bb90842bd98a"), "John F. Night" },
                    { new Guid("50249762-0f32-4f3d-9704-ff9e5863bc86"), "Funny Dev" },
                    { new Guid("68a580be-eacd-4551-bfb1-e45efbc44062"), "Hello World" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "Id",
                keyValue: new Guid("0242f16c-2e5d-4839-ba0d-bb90842bd98a"));

            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "Id",
                keyValue: new Guid("50249762-0f32-4f3d-9704-ff9e5863bc86"));

            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "Id",
                keyValue: new Guid("68a580be-eacd-4551-bfb1-e45efbc44062"));

            migrationBuilder.UpdateData(
                table: "tags",
                keyColumn: "Id",
                keyValue: new Guid("b3ce1341-d10c-429f-954b-854f55aef90b"),
                column: "created_date",
                value: new DateTime(2021, 12, 13, 4, 24, 37, 28, DateTimeKind.Utc).AddTicks(9410));

            migrationBuilder.UpdateData(
                table: "tags",
                keyColumn: "Id",
                keyValue: new Guid("b3d9e7a8-3c31-4aed-9984-c65c14ef0795"),
                column: "created_date",
                value: new DateTime(2021, 12, 13, 4, 24, 37, 28, DateTimeKind.Utc).AddTicks(9400));

            migrationBuilder.UpdateData(
                table: "tags",
                keyColumn: "Id",
                keyValue: new Guid("d6b1de80-e44e-412e-957e-8a7e64d494f9"),
                column: "created_date",
                value: new DateTime(2021, 12, 13, 4, 24, 37, 28, DateTimeKind.Utc).AddTicks(9410));

            migrationBuilder.UpdateData(
                table: "tags",
                keyColumn: "Id",
                keyValue: new Guid("daf5829d-25d3-4f36-b7f6-e6c8ba26bcd0"),
                column: "created_date",
                value: new DateTime(2021, 12, 13, 4, 24, 37, 28, DateTimeKind.Utc).AddTicks(9410));
        }
    }
}
