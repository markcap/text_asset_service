using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace TextAssetService.Migrations
{
    public partial class AddingTextAssetGroups : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_FileTypes_MimeType",
                table: "FileTypes");

            migrationBuilder.DropIndex(
                name: "IX_AssetTypes_AssetTypeName",
                table: "AssetTypes");

            migrationBuilder.AddColumn<long>(
                name: "TextAssetGroupId",
                table: "TextAssets",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "TextAssetGroups",
                columns: table => new
                {
                    TextAssetGroupId = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FeatureId = table.Column<long>(nullable: false),
                    PublishDate = table.Column<DateTime>(nullable: false),
                    Active = table.Column<bool>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    LastUpdatedAt = table.Column<DateTime>(nullable: true),
                    LastUpdatedBy = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TextAssetGroups", x => x.TextAssetGroupId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TextAssets_TextAssetGroupId",
                table: "TextAssets",
                column: "TextAssetGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_FileTypes_MimeType",
                table: "FileTypes",
                column: "MimeType",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AssetTypes_AssetTypeName",
                table: "AssetTypes",
                column: "AssetTypeName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TextAssetGroups_Active",
                table: "TextAssetGroups",
                column: "Active");

            migrationBuilder.CreateIndex(
                name: "IX_TextAssetGroups_FeatureId",
                table: "TextAssetGroups",
                column: "FeatureId");

            migrationBuilder.CreateIndex(
                name: "IX_TextAssetGroups_PublishDate",
                table: "TextAssetGroups",
                column: "PublishDate");

            migrationBuilder.AddForeignKey(
                name: "FK_TextAssets_TextAssetGroups_TextAssetGroupId",
                table: "TextAssets",
                column: "TextAssetGroupId",
                principalTable: "TextAssetGroups",
                principalColumn: "TextAssetGroupId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TextAssets_TextAssetGroups_TextAssetGroupId",
                table: "TextAssets");

            migrationBuilder.DropTable(
                name: "TextAssetGroups");

            migrationBuilder.DropIndex(
                name: "IX_TextAssets_TextAssetGroupId",
                table: "TextAssets");

            migrationBuilder.DropIndex(
                name: "IX_FileTypes_MimeType",
                table: "FileTypes");

            migrationBuilder.DropIndex(
                name: "IX_AssetTypes_AssetTypeName",
                table: "AssetTypes");

            migrationBuilder.DropColumn(
                name: "TextAssetGroupId",
                table: "TextAssets");

            migrationBuilder.CreateIndex(
                name: "IX_FileTypes_MimeType",
                table: "FileTypes",
                column: "MimeType");

            migrationBuilder.CreateIndex(
                name: "IX_AssetTypes_AssetTypeName",
                table: "AssetTypes",
                column: "AssetTypeName");
        }
    }
}
