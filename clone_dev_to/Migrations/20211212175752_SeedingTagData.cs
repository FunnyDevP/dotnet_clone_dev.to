using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace clone_dev_to.Migrations
{
    public partial class SeedingTagData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "tags",
                columns: new[] { "Id", "created_date", "name" },
                values: new object[,]
                {
                    { new Guid("b3ce1341-d10c-429f-954b-854f55aef90b"), new DateTime(2021, 12, 13, 0, 57, 51, 762, DateTimeKind.Local).AddTicks(6150), "webdev" },
                    { new Guid("b3d9e7a8-3c31-4aed-9984-c65c14ef0795"), new DateTime(2021, 12, 13, 0, 57, 51, 762, DateTimeKind.Local).AddTicks(6130), "javascript" },
                    { new Guid("d6b1de80-e44e-412e-957e-8a7e64d494f9"), new DateTime(2021, 12, 13, 0, 57, 51, 762, DateTimeKind.Local).AddTicks(6160), "beginners" },
                    { new Guid("daf5829d-25d3-4f36-b7f6-e6c8ba26bcd0"), new DateTime(2021, 12, 13, 0, 57, 51, 762, DateTimeKind.Local).AddTicks(6160), "programming" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "tags",
                keyColumn: "Id",
                keyValue: new Guid("b3ce1341-d10c-429f-954b-854f55aef90b"));

            migrationBuilder.DeleteData(
                table: "tags",
                keyColumn: "Id",
                keyValue: new Guid("b3d9e7a8-3c31-4aed-9984-c65c14ef0795"));

            migrationBuilder.DeleteData(
                table: "tags",
                keyColumn: "Id",
                keyValue: new Guid("d6b1de80-e44e-412e-957e-8a7e64d494f9"));

            migrationBuilder.DeleteData(
                table: "tags",
                keyColumn: "Id",
                keyValue: new Guid("daf5829d-25d3-4f36-b7f6-e6c8ba26bcd0"));
        }
    }
}
