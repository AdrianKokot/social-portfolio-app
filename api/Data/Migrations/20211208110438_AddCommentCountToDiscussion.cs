using Microsoft.EntityFrameworkCore.Migrations;

namespace Sociussion.Data.Migrations
{
    public partial class AddCommentCountToDiscussion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<ulong>(
                name: "CommentsCount",
                table: "Discussions",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0ul);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CommentsCount",
                table: "Discussions");
        }
    }
}
