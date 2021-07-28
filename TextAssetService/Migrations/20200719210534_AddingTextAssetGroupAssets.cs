using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace TextAssetService.Migrations
{
    public partial class AddingTextAssetGroupAssets : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TextAssets_TextAssetGroups_TextAssetGroupId",
                table: "TextAssets");

            migrationBuilder.DropIndex(
                name: "IX_TextAssets_TextAssetGroupId",
                table: "TextAssets");

            migrationBuilder.DropColumn(
                name: "TextAssetGroupId",
                table: "TextAssets");

            migrationBuilder.CreateTable(
                name: "TextAssetGroupAssets",
                columns: table => new
                {
                    TextAssetGroupAssetId = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TextAssetId = table.Column<long>(nullable: false),
                    TextAssetGroupId = table.Column<long>(nullable: false),
                    OrderNumber = table.Column<long>(nullable: false),
                    Active = table.Column<bool>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    LastUpdatedAt = table.Column<DateTime>(nullable: true),
                    LastUpdatedBy = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TextAssetGroupAssets", x => x.TextAssetGroupAssetId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TextAssetGroupAssets_Active",
                table: "TextAssetGroupAssets",
                column: "Active");

            migrationBuilder.CreateIndex(
                name: "IX_TextAssetGroupAssets_TextAssetGroupId",
                table: "TextAssetGroupAssets",
                column: "TextAssetGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_TextAssetGroupAssets_TextAssetId",
                table: "TextAssetGroupAssets",
                column: "TextAssetId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TextAssetGroupAssets");

            migrationBuilder.AddColumn<long>(
                name: "TextAssetGroupId",
                table: "TextAssets",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TextAssets_TextAssetGroupId",
                table: "TextAssets",
                column: "TextAssetGroupId");

            migrationBuilder.AddForeignKey(
                name: "FK_TextAssets_TextAssetGroups_TextAssetGroupId",
                table: "TextAssets",
                column: "TextAssetGroupId",
                principalTable: "TextAssetGroups",
                principalColumn: "TextAssetGroupId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
