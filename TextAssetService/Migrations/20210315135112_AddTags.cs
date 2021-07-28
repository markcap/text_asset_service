using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TextAssetService.Migrations
{
    public partial class AddTags : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tag",
                columns: table => new
                {
                    TagId = table.Column<long>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: true),
                    ModifiedBy = table.Column<string>(nullable: true),
                    ActiveFlag = table.Column<bool>(nullable: false, defaultValue: true),
                    TagName = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tag", x => x.TagId);
                });

            migrationBuilder.CreateTable(
                name: "Tagging",
                columns: table => new
                {
                    TaggingId = table.Column<long>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: true),
                    ModifiedBy = table.Column<string>(nullable: true),
                    ActiveFlag = table.Column<bool>(nullable: false, defaultValue: true),
                    TaggableType = table.Column<string>(nullable: false),
                    TaggableId = table.Column<long>(nullable: false),
                    TaggerId = table.Column<long>(nullable: true),
                    FeatureId = table.Column<long>(nullable: true),
                    TaggerType = table.Column<string>(nullable: true),
                    Context = table.Column<string>(nullable: false),
                    TagId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tagging", x => x.TaggingId);
                    table.ForeignKey(
                        name: "FK_Tagging_Tag_TagId",
                        column: x => x.TagId,
                        principalTable: "Tag",
                        principalColumn: "TagId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tag_ActiveFlag",
                table: "Tag",
                column: "ActiveFlag");

            migrationBuilder.CreateIndex(
                name: "IX_Tag_TagName",
                table: "Tag",
                column: "TagName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tagging_ActiveFlag",
                table: "Tagging",
                column: "ActiveFlag");

            migrationBuilder.CreateIndex(
                name: "IX_Tagging_TagId",
                table: "Tagging",
                column: "TagId");

            migrationBuilder.CreateIndex(
                name: "IX_Tagging_TaggableId_TaggableType_Context",
                table: "Tagging",
                columns: new[] { "TaggableId", "TaggableType", "Context" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tagging");

            migrationBuilder.DropTable(
                name: "Tag");
        }
    }
}
