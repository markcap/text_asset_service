using Microsoft.EntityFrameworkCore.Migrations;

namespace TextAssetService.Migrations
{
    public partial class AddingIndexesa : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<long>(
                name: "FeatureId",
                table: "TextAssets",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.CreateIndex(
                name: "IX_TextAssets_Active",
                table: "TextAssets",
                column: "Active");

            migrationBuilder.CreateIndex(
                name: "IX_TextAssets_FeatureId",
                table: "TextAssets",
                column: "FeatureId");

            migrationBuilder.CreateIndex(
                name: "IX_TextAssets_FileName",
                table: "TextAssets",
                column: "FileName");

            migrationBuilder.CreateIndex(
                name: "IX_TextAssets_IssueDate",
                table: "TextAssets",
                column: "IssueDate");

            migrationBuilder.CreateIndex(
                name: "IX_TextAssets_OriginalDate",
                table: "TextAssets",
                column: "OriginalDate");

            migrationBuilder.CreateIndex(
                name: "IX_TextAssets_TextAssetUuid",
                table: "TextAssets",
                column: "TextAssetUuid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_FileTypes_Active",
                table: "FileTypes",
                column: "Active");

            migrationBuilder.CreateIndex(
                name: "IX_FileTypes_MimeType",
                table: "FileTypes",
                column: "MimeType");

            migrationBuilder.CreateIndex(
                name: "IX_AssetTypes_Active",
                table: "AssetTypes",
                column: "Active");

            migrationBuilder.CreateIndex(
                name: "IX_AssetTypes_AssetTypeName",
                table: "AssetTypes",
                column: "AssetTypeName");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_TextAssets_Active",
                table: "TextAssets");

            migrationBuilder.DropIndex(
                name: "IX_TextAssets_FeatureId",
                table: "TextAssets");

            migrationBuilder.DropIndex(
                name: "IX_TextAssets_FileName",
                table: "TextAssets");

            migrationBuilder.DropIndex(
                name: "IX_TextAssets_IssueDate",
                table: "TextAssets");

            migrationBuilder.DropIndex(
                name: "IX_TextAssets_OriginalDate",
                table: "TextAssets");

            migrationBuilder.DropIndex(
                name: "IX_TextAssets_TextAssetUuid",
                table: "TextAssets");

            migrationBuilder.DropIndex(
                name: "IX_FileTypes_Active",
                table: "FileTypes");

            migrationBuilder.DropIndex(
                name: "IX_FileTypes_MimeType",
                table: "FileTypes");

            migrationBuilder.DropIndex(
                name: "IX_AssetTypes_Active",
                table: "AssetTypes");

            migrationBuilder.DropIndex(
                name: "IX_AssetTypes_AssetTypeName",
                table: "AssetTypes");

            migrationBuilder.AlterColumn<int>(
                name: "FeatureId",
                table: "TextAssets",
                type: "integer",
                nullable: false,
                oldClrType: typeof(long));
        }
    }
}
