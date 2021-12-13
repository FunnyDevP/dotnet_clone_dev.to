using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace clone_dev_to.Migrations
{
    public partial class InitialTableUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "posts",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    full_name = table.Column<string>(type: "varchar(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "tags",
                keyColumn: "Id",
                keyValue: new Guid("b3ce1341-d10c-429f-954b-854f55aef90b"),
                column: "created_date",
                value: new DateTime(2021, 12, 13, 4, 17, 18, 865, DateTimeKind.Utc).AddTicks(9390));

            migrationBuilder.UpdateData(
                table: "tags",
                keyColumn: "Id",
                keyValue: new Guid("b3d9e7a8-3c31-4aed-9984-c65c14ef0795"),
                column: "created_date",
                value: new DateTime(2021, 12, 13, 4, 17, 18, 865, DateTimeKind.Utc).AddTicks(9380));

            migrationBuilder.UpdateData(
                table: "tags",
                keyColumn: "Id",
                keyValue: new Guid("d6b1de80-e44e-412e-957e-8a7e64d494f9"),
                column: "created_date",
                value: new DateTime(2021, 12, 13, 4, 17, 18, 865, DateTimeKind.Utc).AddTicks(9390));

            migrationBuilder.UpdateData(
                table: "tags",
                keyColumn: "Id",
                keyValue: new Guid("daf5829d-25d3-4f36-b7f6-e6c8ba26bcd0"),
                column: "created_date",
                value: new DateTime(2021, 12, 13, 4, 17, 18, 865, DateTimeKind.Utc).AddTicks(9390));

            migrationBuilder.CreateIndex(
                name: "IX_posts_UserId",
                table: "posts",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_posts_users_UserId",
                table: "posts",
                column: "UserId",
                principalTable: "users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_posts_users_UserId",
                table: "posts");

            migrationBuilder.DropTable(
                name: "users");

            migrationBuilder.DropIndex(
                name: "IX_posts_UserId",
                table: "posts");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "posts");

            migrationBuilder.UpdateData(
                table: "tags",
                keyColumn: "Id",
                keyValue: new Guid("b3ce1341-d10c-429f-954b-854f55aef90b"),
                column: "created_date",
                value: new DateTime(2021, 12, 13, 3, 24, 50, 816, DateTimeKind.Utc).AddTicks(2770));

            migrationBuilder.UpdateData(
                table: "tags",
                keyColumn: "Id",
                keyValue: new Guid("b3d9e7a8-3c31-4aed-9984-c65c14ef0795"),
                column: "created_date",
                value: new DateTime(2021, 12, 13, 3, 24, 50, 816, DateTimeKind.Utc).AddTicks(2770));

            migrationBuilder.UpdateData(
                table: "tags",
                keyColumn: "Id",
                keyValue: new Guid("d6b1de80-e44e-412e-957e-8a7e64d494f9"),
                column: "created_date",
                value: new DateTime(2021, 12, 13, 3, 24, 50, 816, DateTimeKind.Utc).AddTicks(2770));

            migrationBuilder.UpdateData(
                table: "tags",
                keyColumn: "Id",
                keyValue: new Guid("daf5829d-25d3-4f36-b7f6-e6c8ba26bcd0"),
                column: "created_date",
                value: new DateTime(2021, 12, 13, 3, 24, 50, 816, DateTimeKind.Utc).AddTicks(2780));
        }
    }
}
