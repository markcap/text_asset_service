using Microsoft.EntityFrameworkCore.Migrations;

namespace TextAssetService.Migrations
{
    public partial class AddingFilepaths : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ArchiveBasePath",
                table: "TextAssets",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ArchiveFilePath",
                table: "TextAssets",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FilePath",
                table: "TextAssets",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ArchiveBasePath",
                table: "TextAssets");

            migrationBuilder.DropColumn(
                name: "ArchiveFilePath",
                table: "TextAssets");

            migrationBuilder.DropColumn(
                name: "FilePath",
                table: "TextAssets");
        }
    }
}
