using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class mig3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_CommentVotes",
                table: "CommentVotes");

            migrationBuilder.DropIndex(
                name: "Comment_Vote_Group",
                table: "CommentVotes");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "CommentVotes");

            migrationBuilder.DropColumn(
                name: "Vote",
                table: "CommentVotes");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "CommentVotes",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_CommentVotes",
                table: "CommentVotes",
                columns: new[] { "CommentId", "UserId" });

            migrationBuilder.CreateTable(
                name: "Hashtags",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Key = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hashtags", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProductHashtags",
                columns: table => new
                {
                    HashtagId = table.Column<long>(nullable: false),
                    ProductId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductHashtags", x => new { x.HashtagId, x.ProductId });
                    table.ForeignKey(
                        name: "FK_ProductHashtags_Hashtags_HashtagId",
                        column: x => x.HashtagId,
                        principalTable: "Hashtags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProductHashtags_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductHashtags_ProductId",
                table: "ProductHashtags",
                column: "ProductId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductHashtags");

            migrationBuilder.DropTable(
                name: "Hashtags");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CommentVotes",
                table: "CommentVotes");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "CommentVotes",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AddColumn<long>(
                name: "Id",
                table: "CommentVotes",
                nullable: false,
                defaultValue: 0L)
                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddColumn<int>(
                name: "Vote",
                table: "CommentVotes",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_CommentVotes",
                table: "CommentVotes",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "Comment_Vote_Group",
                table: "CommentVotes",
                columns: new[] { "CommentId", "UserId" },
                unique: true,
                filter: "[UserId] IS NOT NULL");
        }
    }
}
