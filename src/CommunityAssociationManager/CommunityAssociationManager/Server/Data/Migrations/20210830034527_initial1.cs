using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CommunityAssociationManager.Server.Data.Migrations
{
    public partial class initial1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CommunityMembers",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommunityMembers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Communities",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    ManagerId = table.Column<long>(type: "bigint", nullable: true),
                    CashierId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Communities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Communities_CommunityMembers_CashierId",
                        column: x => x.CashierId,
                        principalTable: "CommunityMembers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Communities_CommunityMembers_ManagerId",
                        column: x => x.ManagerId,
                        principalTable: "CommunityMembers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

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

            migrationBuilder.CreateTable(
                name: "CommunityProperties",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OwnerId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommunityProperties", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CommunityProperties_Communities_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "Communities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Properties",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OwnerId = table.Column<long>(type: "bigint", nullable: false),
                    CommunityId = table.Column<long>(type: "bigint", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Properties", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Properties_Communities_CommunityId",
                        column: x => x.CommunityId,
                        principalTable: "Communities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Properties_CommunityMembers_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "CommunityMembers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RecurringTaxes",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CommunityId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecurringTaxes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RecurringTaxes_Communities_CommunityId",
                        column: x => x.CommunityId,
                        principalTable: "Communities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TaxRecurrances",
                columns: table => new
                {
                    Id = table.Column<decimal>(type: "decimal(20,0)", nullable: false),
                    DueDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Amount = table.Column<double>(type: "float", nullable: false),
                    IsPaid = table.Column<bool>(type: "bit", nullable: false),
                    PropertyId = table.Column<long>(type: "bigint", nullable: true),
                    PropertyId1 = table.Column<long>(type: "bigint", nullable: true),
                    CommunityPropertyId = table.Column<long>(type: "bigint", nullable: true),
                    CommunityPropertyId1 = table.Column<long>(type: "bigint", nullable: true),
                    RecurringTaxId = table.Column<long>(type: "bigint", nullable: false),
                    RecurringTaxId1 = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaxRecurrances", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TaxRecurrances_CommunityProperties_CommunityPropertyId1",
                        column: x => x.CommunityPropertyId1,
                        principalTable: "CommunityProperties",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TaxRecurrances_Properties_PropertyId1",
                        column: x => x.PropertyId1,
                        principalTable: "Properties",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TaxRecurrances_RecurringTaxes_RecurringTaxId1",
                        column: x => x.RecurringTaxId1,
                        principalTable: "RecurringTaxes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Communities_CashierId",
                table: "Communities",
                column: "CashierId");

            migrationBuilder.CreateIndex(
                name: "IX_Communities_ManagerId",
                table: "Communities",
                column: "ManagerId");

            migrationBuilder.CreateIndex(
                name: "IX_CommunityCommunityMember_CommunityMembersId",
                table: "CommunityCommunityMember",
                column: "CommunityMembersId");

            migrationBuilder.CreateIndex(
                name: "IX_CommunityProperties_OwnerId",
                table: "CommunityProperties",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_Properties_CommunityId",
                table: "Properties",
                column: "CommunityId");

            migrationBuilder.CreateIndex(
                name: "IX_Properties_OwnerId",
                table: "Properties",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_RecurringTaxes_CommunityId",
                table: "RecurringTaxes",
                column: "CommunityId");

            migrationBuilder.CreateIndex(
                name: "IX_TaxRecurrances_CommunityPropertyId1",
                table: "TaxRecurrances",
                column: "CommunityPropertyId1");

            migrationBuilder.CreateIndex(
                name: "IX_TaxRecurrances_PropertyId1",
                table: "TaxRecurrances",
                column: "PropertyId1");

            migrationBuilder.CreateIndex(
                name: "IX_TaxRecurrances_RecurringTaxId1",
                table: "TaxRecurrances",
                column: "RecurringTaxId1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CommunityCommunityMember");

            migrationBuilder.DropTable(
                name: "TaxRecurrances");

            migrationBuilder.DropTable(
                name: "CommunityProperties");

            migrationBuilder.DropTable(
                name: "Properties");

            migrationBuilder.DropTable(
                name: "RecurringTaxes");

            migrationBuilder.DropTable(
                name: "Communities");

            migrationBuilder.DropTable(
                name: "CommunityMembers");
        }
    }
}
