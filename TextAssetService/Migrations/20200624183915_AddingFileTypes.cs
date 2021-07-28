using Microsoft.EntityFrameworkCore.Migrations;

namespace TextAssetService.Migrations
{
    public partial class AddingFileTypes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.AddColumn<long>(
                name: "FileTypeId",
                table: "TextAssets",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_TextAssets_FileTypeId",
                table: "TextAssets",
                column: "FileTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_TextAssets_FileTypes_FileTypeId",
                table: "TextAssets",
                column: "FileTypeId",
                principalTable: "FileTypes",
                principalColumn: "FileTypeId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TextAssets_FileTypes_FileTypeId",
                table: "TextAssets");

            migrationBuilder.DropIndex(
                name: "IX_TextAssets_FileTypeId",
                table: "TextAssets");

            migrationBuilder.DropColumn(
                name: "FileTypeId",
                table: "TextAssets");

            migrationBuilder.AddColumn<long>(
                name: "FileTypeAssetTypeId",
                table: "TextAssets",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_TextAssets_FileTypeAssetTypeId",
                table: "TextAssets",
                column: "FileTypeAssetTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_TextAssets_AssetTypes_FileTypeAssetTypeId",
                table: "TextAssets",
                column: "FileTypeAssetTypeId",
                principalTable: "AssetTypes",
                principalColumn: "AssetTypeId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
