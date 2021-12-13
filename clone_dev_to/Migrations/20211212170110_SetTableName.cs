using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace clone_dev_to.Migrations
{
    public partial class SetTableName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PostModelTagModel_posts_PostsId",
                table: "PostModelTagModel");

            migrationBuilder.DropForeignKey(
                name: "FK_PostModelTagModel_tags_TagsId",
                table: "PostModelTagModel");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PostModelTagModel",
                table: "PostModelTagModel");

            migrationBuilder.RenameTable(
                name: "PostModelTagModel",
                newName: "posts_tags");

            migrationBuilder.RenameIndex(
                name: "IX_PostModelTagModel_TagsId",
                table: "posts_tags",
                newName: "IX_posts_tags_TagsId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_posts_tags",
                table: "posts_tags",
                columns: new[] { "PostsId", "TagsId" });

            migrationBuilder.AddForeignKey(
                name: "FK_posts_tags_posts_PostsId",
                table: "posts_tags",
                column: "PostsId",
                principalTable: "posts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_posts_tags_tags_TagsId",
                table: "posts_tags",
                column: "TagsId",
                principalTable: "tags",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_posts_tags_posts_PostsId",
                table: "posts_tags");

            migrationBuilder.DropForeignKey(
                name: "FK_posts_tags_tags_TagsId",
                table: "posts_tags");

            migrationBuilder.DropPrimaryKey(
                name: "PK_posts_tags",
                table: "posts_tags");

            migrationBuilder.RenameTable(
                name: "posts_tags",
                newName: "PostModelTagModel");

            migrationBuilder.RenameIndex(
                name: "IX_posts_tags_TagsId",
                table: "PostModelTagModel",
                newName: "IX_PostModelTagModel_TagsId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PostModelTagModel",
                table: "PostModelTagModel",
                columns: new[] { "PostsId", "TagsId" });

            migrationBuilder.AddForeignKey(
                name: "FK_PostModelTagModel_posts_PostsId",
                table: "PostModelTagModel",
                column: "PostsId",
                principalTable: "posts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PostModelTagModel_tags_TagsId",
                table: "PostModelTagModel",
                column: "TagsId",
                principalTable: "tags",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
