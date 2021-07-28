using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace TextAssetService.Migrations
{
    public partial class AddingAssetTypeModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "AssetTypeId",
                table: "TextAssets",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateTable(
                name: "AssetTypes",
                columns: table => new
                {
                    AssetTypeId = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssetType", x => x.AssetTypeId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TextAssets_AssetTypeId",
                table: "TextAssets",
                column: "AssetTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_TextAssets_AssetType_AssetTypeId",
                table: "TextAssets",
                column: "AssetTypeId",
                principalTable: "AssetTypes",
                principalColumn: "AssetTypeId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TextAssets_AssetType_AssetTypeId",
                table: "TextAssets");

            migrationBuilder.DropTable(
                name: "AssetType");

            migrationBuilder.DropIndex(
                name: "IX_TextAssets_AssetTypeId",
                table: "TextAssets");

            migrationBuilder.DropColumn(
                name: "AssetTypeId",
                table: "TextAssets");
        }
    }
}
