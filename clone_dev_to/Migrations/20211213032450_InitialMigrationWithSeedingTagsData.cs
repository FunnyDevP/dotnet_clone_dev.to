using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace clone_dev_to.Migrations
{
    public partial class InitialMigrationWithSeedingTagsData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "posts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    title = table.Column<string>(type: "varchar(100)", nullable: false),
                    detail = table.Column<string>(type: "text", nullable: false),
                    publication_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_posts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tags",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "varchar(30)", nullable: false),
                    created_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tags", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "posts_tags",
                columns: table => new
                {
                    PostsId = table.Column<Guid>(type: "uuid", nullable: false),
                    TagsId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_posts_tags", x => new { x.PostsId, x.TagsId });
                    table.ForeignKey(
                        name: "FK_posts_tags_posts_PostsId",
                        column: x => x.PostsId,
                        principalTable: "posts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_posts_tags_tags_TagsId",
                        column: x => x.TagsId,
                        principalTable: "tags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "tags",
                columns: new[] { "Id", "created_date", "name" },
                values: new object[,]
                {
                    { new Guid("b3ce1341-d10c-429f-954b-854f55aef90b"), new DateTime(2021, 12, 13, 3, 24, 50, 816, DateTimeKind.Utc).AddTicks(2770), "webdev" },
                    { new Guid("b3d9e7a8-3c31-4aed-9984-c65c14ef0795"), new DateTime(2021, 12, 13, 3, 24, 50, 816, DateTimeKind.Utc).AddTicks(2770), "javascript" },
                    { new Guid("d6b1de80-e44e-412e-957e-8a7e64d494f9"), new DateTime(2021, 12, 13, 3, 24, 50, 816, DateTimeKind.Utc).AddTicks(2770), "beginners" },
                    { new Guid("daf5829d-25d3-4f36-b7f6-e6c8ba26bcd0"), new DateTime(2021, 12, 13, 3, 24, 50, 816, DateTimeKind.Utc).AddTicks(2780), "programming" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_posts_tags_TagsId",
                table: "posts_tags",
                column: "TagsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "posts_tags");

            migrationBuilder.DropTable(
                name: "posts");

            migrationBuilder.DropTable(
                name: "tags");
        }
    }
}
