using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CodefirstByEF6.Migrations
{
    /// <inheritdoc />
    public partial class _1stCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MemberModels",
                columns: table => new
                {
                    memberId = table.Column<string>(type: "TEXT", nullable: false),
                    memberJoinDate = table.Column<DateOnly>(type: "TEXT", nullable: false),
                    memberNickName = table.Column<string>(type: "TEXT", nullable: false),
                    sexual = table.Column<string>(type: "TEXT", nullable: false),
                    memberBirthday = table.Column<DateOnly>(type: "TEXT", nullable: false),
                    comments = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MemberModels", x => x.memberId);
                });

            migrationBuilder.CreateTable(
                name: "MemberTagModels",
                columns: table => new
                {
                    memberTagId = table.Column<string>(type: "TEXT", nullable: false),
                    tagName = table.Column<string>(type: "TEXT", nullable: false),
                    tagComments = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MemberTagModels", x => x.memberTagId);
                });

            migrationBuilder.CreateTable(
                name: "ContactModels",
                columns: table => new
                {
                    commonId = table.Column<string>(type: "TEXT", nullable: false),
                    contactType = table.Column<string>(type: "TEXT", nullable: false),
                    contactValue = table.Column<string>(type: "TEXT", nullable: false),
                    comments = table.Column<string>(type: "TEXT", nullable: false),
                    memberId = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactModels", x => x.commonId);
                    table.ForeignKey(
                        name: "FK_ContactModels_MemberModels_memberId",
                        column: x => x.memberId,
                        principalTable: "MemberModels",
                        principalColumn: "memberId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MemberWechatModels",
                columns: table => new
                {
                    wechatId = table.Column<string>(type: "TEXT", nullable: false),
                    sexual = table.Column<string>(type: "TEXT", nullable: false),
                    nickname = table.Column<string>(type: "TEXT", nullable: false),
                    country = table.Column<string>(type: "TEXT", nullable: false),
                    area = table.Column<string>(type: "TEXT", nullable: false),
                    memberId = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MemberWechatModels", x => x.wechatId);
                    table.ForeignKey(
                        name: "FK_MemberWechatModels_MemberModels_memberId",
                        column: x => x.memberId,
                        principalTable: "MemberModels",
                        principalColumn: "memberId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "memberWithMemberTagModels",
                columns: table => new
                {
                    memberId = table.Column<string>(type: "TEXT", nullable: false),
                    memberTagId = table.Column<string>(type: "TEXT", nullable: false),
                    similarScore = table.Column<decimal>(type: "TEXT", nullable: false),
                    supportScore = table.Column<decimal>(type: "TEXT", nullable: false),
                    tagScore = table.Column<decimal>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_memberWithMemberTagModels", x => new { x.memberId, x.memberTagId });
                    table.ForeignKey(
                        name: "FK_memberWithMemberTagModels_MemberModels_memberId",
                        column: x => x.memberId,
                        principalTable: "MemberModels",
                        principalColumn: "memberId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_memberWithMemberTagModels_MemberTagModels_memberTagId",
                        column: x => x.memberTagId,
                        principalTable: "MemberTagModels",
                        principalColumn: "memberTagId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ContactModels_commonId",
                table: "ContactModels",
                column: "commonId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ContactModels_memberId",
                table: "ContactModels",
                column: "memberId");

            migrationBuilder.CreateIndex(
                name: "IX_MemberModels_memberId",
                table: "MemberModels",
                column: "memberId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MemberTagModels_memberTagId",
                table: "MemberTagModels",
                column: "memberTagId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MemberWechatModels_memberId",
                table: "MemberWechatModels",
                column: "memberId");

            migrationBuilder.CreateIndex(
                name: "IX_MemberWechatModels_wechatId",
                table: "MemberWechatModels",
                column: "wechatId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_memberWithMemberTagModels_memberTagId",
                table: "memberWithMemberTagModels",
                column: "memberTagId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ContactModels");

            migrationBuilder.DropTable(
                name: "MemberWechatModels");

            migrationBuilder.DropTable(
                name: "memberWithMemberTagModels");

            migrationBuilder.DropTable(
                name: "MemberModels");

            migrationBuilder.DropTable(
                name: "MemberTagModels");
        }
    }
}
