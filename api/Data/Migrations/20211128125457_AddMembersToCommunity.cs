using Microsoft.EntityFrameworkCore.Migrations;

namespace Sociussion.Data.Migrations
{
    public partial class AddMembersToCommunity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<ulong>(
                name: "MembersCount",
                table: "Communities",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0ul);

            migrationBuilder.CreateTable(
                name: "ApplicationUserCommunity",
                columns: table => new
                {
                    MemberOfCommunitiesId = table.Column<ulong>(type: "INTEGER", nullable: false),
                    MembersId = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationUserCommunity", x => new { x.MemberOfCommunitiesId, x.MembersId });
                    table.ForeignKey(
                        name: "FK_ApplicationUserCommunity_AspNetUsers_MembersId",
                        column: x => x.MembersId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ApplicationUserCommunity_Communities_MemberOfCommunitiesId",
                        column: x => x.MemberOfCommunitiesId,
                        principalTable: "Communities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationUserCommunity_MembersId",
                table: "ApplicationUserCommunity",
                column: "MembersId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ApplicationUserCommunity");

            migrationBuilder.DropColumn(
                name: "MembersCount",
                table: "Communities");
        }
    }
}
