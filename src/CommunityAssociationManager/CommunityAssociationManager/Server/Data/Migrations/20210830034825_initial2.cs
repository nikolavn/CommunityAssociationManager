using Microsoft.EntityFrameworkCore.Migrations;

namespace CommunityAssociationManager.Server.Data.Migrations
{
    public partial class initial2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CommunityCommunityMember");

            migrationBuilder.AddColumn<long>(
                name: "CommunityId",
                table: "CommunityMembers",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_CommunityMembers_CommunityId",
                table: "CommunityMembers",
                column: "CommunityId");

            migrationBuilder.AddForeignKey(
                name: "FK_CommunityMembers_Communities_CommunityId",
                table: "CommunityMembers",
                column: "CommunityId",
                principalTable: "Communities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CommunityMembers_Communities_CommunityId",
                table: "CommunityMembers");

            migrationBuilder.DropIndex(
                name: "IX_CommunityMembers_CommunityId",
                table: "CommunityMembers");

            migrationBuilder.DropColumn(
                name: "CommunityId",
                table: "CommunityMembers");

            migrationBuilder.CreateTable(
                name: "CommunityCommunityMember",
                columns: table => new
                {
                    CommunitiesId = table.Column<long>(type: "bigint", nullable: false),
                    CommunityMembersId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommunityCommunityMember", x => new { x.CommunitiesId, x.CommunityMembersId });
                    table.ForeignKey(
                        name: "FK_CommunityCommunityMember_Communities_CommunitiesId",
                        column: x => x.CommunitiesId,
                        principalTable: "Communities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CommunityCommunityMember_CommunityMembers_CommunityMembersId",
                        column: x => x.CommunityMembersId,
                        principalTable: "CommunityMembers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CommunityCommunityMember_CommunityMembersId",
                table: "CommunityCommunityMember",
                column: "CommunityMembersId");
        }
    }
}
