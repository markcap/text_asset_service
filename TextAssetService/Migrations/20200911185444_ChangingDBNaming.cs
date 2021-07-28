using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TextAssetService.Migrations
{
    public partial class ChangingDBNaming : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_TextAssets_Active",
                table: "TextAssets");

            migrationBuilder.DropIndex(
                name: "IX_TextAssetGroups_Active",
                table: "TextAssetGroups");

            migrationBuilder.DropIndex(
                name: "IX_TextAssetGroupAssets_Active",
                table: "TextAssetGroupAssets");

            migrationBuilder.DropIndex(
                name: "IX_FileTypes_Active",
                table: "FileTypes");

            migrationBuilder.DropIndex(
                name: "IX_AssetTypes_Active",
                table: "AssetTypes");

            migrationBuilder.DropColumn(
                name: "Active",
                table: "TextAssets");

            migrationBuilder.DropColumn(
                name: "ArchiveBasePath",
                table: "TextAssets");

            migrationBuilder.DropColumn(
                name: "ArchiveFilePath",
                table: "TextAssets");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "TextAssets");

            migrationBuilder.DropColumn(
                name: "FilePath",
                table: "TextAssets");

            migrationBuilder.DropColumn(
                name: "LastUpdatedAt",
                table: "TextAssets");

            migrationBuilder.DropColumn(
                name: "LastUpdatedBy",
                table: "TextAssets");

            migrationBuilder.DropColumn(
                name: "Active",
                table: "TextAssetGroups");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "TextAssetGroups");

            migrationBuilder.DropColumn(
                name: "LastUpdatedAt",
                table: "TextAssetGroups");

            migrationBuilder.DropColumn(
                name: "LastUpdatedBy",
                table: "TextAssetGroups");

            migrationBuilder.DropColumn(
                name: "Active",
                table: "TextAssetGroupAssets");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "TextAssetGroupAssets");

            migrationBuilder.DropColumn(
                name: "LastUpdatedAt",
                table: "TextAssetGroupAssets");

            migrationBuilder.DropColumn(
                name: "LastUpdatedBy",
                table: "TextAssetGroupAssets");

            migrationBuilder.DropColumn(
                name: "Active",
                table: "FileTypes");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "FileTypes");

            migrationBuilder.DropColumn(
                name: "LastUpdatedAt",
                table: "FileTypes");

            migrationBuilder.DropColumn(
                name: "LastUpdatedBy",
                table: "FileTypes");

            migrationBuilder.DropColumn(
                name: "Active",
                table: "AssetTypes");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "AssetTypes");

            migrationBuilder.DropColumn(
                name: "LastUpdatedAt",
                table: "AssetTypes");

            migrationBuilder.DropColumn(
                name: "LastUpdatedBy",
                table: "AssetTypes");

            migrationBuilder.AddColumn<bool>(
                name: "ActiveFlag",
                table: "TextAssets",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "CDNBasePath",
                table: "TextAssets",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "TextAssets",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "TextAssets",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDate",
                table: "TextAssets",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "ActiveFlag",
                table: "TextAssetGroups",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "TextAssetGroups",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "TextAssetGroups",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDate",
                table: "TextAssetGroups",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "ActiveFlag",
                table: "TextAssetGroupAssets",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "TextAssetGroupAssets",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "TextAssetGroupAssets",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDate",
                table: "TextAssetGroupAssets",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "ActiveFlag",
                table: "FileTypes",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "FileTypes",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "FileTypes",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDate",
                table: "FileTypes",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "ActiveFlag",
                table: "AssetTypes",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "AssetTypes",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "AssetTypes",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDate",
                table: "AssetTypes",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TextAssets_ActiveFlag",
                table: "TextAssets",
                column: "ActiveFlag");

            migrationBuilder.CreateIndex(
                name: "IX_TextAssetGroups_ActiveFlag",
                table: "TextAssetGroups",
                column: "ActiveFlag");

            migrationBuilder.CreateIndex(
                name: "IX_TextAssetGroupAssets_ActiveFlag",
                table: "TextAssetGroupAssets",
                column: "ActiveFlag");

            migrationBuilder.CreateIndex(
                name: "IX_FileTypes_ActiveFlag",
                table: "FileTypes",
                column: "ActiveFlag");

            migrationBuilder.CreateIndex(
                name: "IX_AssetTypes_ActiveFlag",
                table: "AssetTypes",
                column: "ActiveFlag");

            migrationBuilder.AddForeignKey(
                name: "FK_TextAssetGroupAssets_TextAssetGroups_TextAssetGroupId",
                table: "TextAssetGroupAssets",
                column: "TextAssetGroupId",
                principalTable: "TextAssetGroups",
                principalColumn: "TextAssetGroupId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TextAssetGroupAssets_TextAssets_TextAssetId",
                table: "TextAssetGroupAssets",
                column: "TextAssetId",
                principalTable: "TextAssets",
                principalColumn: "TextAssetId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TextAssetGroupAssets_TextAssetGroups_TextAssetGroupId",
                table: "TextAssetGroupAssets");

            migrationBuilder.DropForeignKey(
                name: "FK_TextAssetGroupAssets_TextAssets_TextAssetId",
                table: "TextAssetGroupAssets");

            migrationBuilder.DropIndex(
                name: "IX_TextAssets_ActiveFlag",
                table: "TextAssets");

            migrationBuilder.DropIndex(
                name: "IX_TextAssetGroups_ActiveFlag",
                table: "TextAssetGroups");

            migrationBuilder.DropIndex(
                name: "IX_TextAssetGroupAssets_ActiveFlag",
                table: "TextAssetGroupAssets");

            migrationBuilder.DropIndex(
                name: "IX_FileTypes_ActiveFlag",
                table: "FileTypes");

            migrationBuilder.DropIndex(
                name: "IX_AssetTypes_ActiveFlag",
                table: "AssetTypes");

            migrationBuilder.DropColumn(
                name: "ActiveFlag",
                table: "TextAssets");

            migrationBuilder.DropColumn(
                name: "CDNBasePath",
                table: "TextAssets");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "TextAssets");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "TextAssets");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                table: "TextAssets");

            migrationBuilder.DropColumn(
                name: "ActiveFlag",
                table: "TextAssetGroups");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "TextAssetGroups");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "TextAssetGroups");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                table: "TextAssetGroups");

            migrationBuilder.DropColumn(
                name: "ActiveFlag",
                table: "TextAssetGroupAssets");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "TextAssetGroupAssets");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "TextAssetGroupAssets");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                table: "TextAssetGroupAssets");

            migrationBuilder.DropColumn(
                name: "ActiveFlag",
                table: "FileTypes");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "FileTypes");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "FileTypes");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                table: "FileTypes");

            migrationBuilder.DropColumn(
                name: "ActiveFlag",
                table: "AssetTypes");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "AssetTypes");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "AssetTypes");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                table: "AssetTypes");

            migrationBuilder.AddColumn<bool>(
                name: "Active",
                table: "TextAssets",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "ArchiveBasePath",
                table: "TextAssets",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ArchiveFilePath",
                table: "TextAssets",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "TextAssets",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "FilePath",
                table: "TextAssets",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "LastUpdatedAt",
                table: "TextAssets",
                type: "timestamp without time zone",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastUpdatedBy",
                table: "TextAssets",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Active",
                table: "TextAssetGroups",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "TextAssetGroups",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "LastUpdatedAt",
                table: "TextAssetGroups",
                type: "timestamp without time zone",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastUpdatedBy",
                table: "TextAssetGroups",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Active",
                table: "TextAssetGroupAssets",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "TextAssetGroupAssets",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "LastUpdatedAt",
                table: "TextAssetGroupAssets",
                type: "timestamp without time zone",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastUpdatedBy",
                table: "TextAssetGroupAssets",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Active",
                table: "FileTypes",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "FileTypes",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "LastUpdatedAt",
                table: "FileTypes",
                type: "timestamp without time zone",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastUpdatedBy",
                table: "FileTypes",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Active",
                table: "AssetTypes",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "AssetTypes",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "LastUpdatedAt",
                table: "AssetTypes",
                type: "timestamp without time zone",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastUpdatedBy",
                table: "AssetTypes",
                type: "text",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TextAssets_Active",
                table: "TextAssets",
                column: "Active");

            migrationBuilder.CreateIndex(
                name: "IX_TextAssetGroups_Active",
                table: "TextAssetGroups",
                column: "Active");

            migrationBuilder.CreateIndex(
                name: "IX_TextAssetGroupAssets_Active",
                table: "TextAssetGroupAssets",
                column: "Active");

            migrationBuilder.CreateIndex(
                name: "IX_FileTypes_Active",
                table: "FileTypes",
                column: "Active");

            migrationBuilder.CreateIndex(
                name: "IX_AssetTypes_Active",
                table: "AssetTypes",
                column: "Active");
        }
    }
}
