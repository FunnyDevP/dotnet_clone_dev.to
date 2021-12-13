using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace clone_dev_to.Migrations
{
    public partial class SetFkUserID : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_posts_users_UserId",
                table: "posts");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "posts",
                newName: "user_id");

            migrationBuilder.RenameIndex(
                name: "IX_posts_UserId",
                table: "posts",
                newName: "IX_posts_user_id");

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

            migrationBuilder.AddForeignKey(
                name: "FK_posts_users_user_id",
                table: "posts",
                column: "user_id",
                principalTable: "users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_posts_users_user_id",
                table: "posts");

            migrationBuilder.RenameColumn(
                name: "user_id",
                table: "posts",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_posts_user_id",
                table: "posts",
                newName: "IX_posts_UserId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_posts_users_UserId",
                table: "posts",
                column: "UserId",
                principalTable: "users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
