using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace TextAssetService.Migrations
{
    public partial class AddingItrackable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_TextAssets",
                table: "TextAssets");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "TextAssets");

            migrationBuilder.DropColumn(
                name: "Uuid",
                table: "TextAssets");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "FileTypes");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "AssetTypes");

            migrationBuilder.AlterColumn<DateTime>(
                name: "OriginalDate",
                table: "TextAssets",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone");

            migrationBuilder.AddColumn<long>(
                name: "TextAssetId",
                table: "TextAssets",
                nullable: false,
                defaultValue: 0L)
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "TextAssets",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "TextAssets",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastUpdatedAt",
                table: "TextAssets",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastUpdatedBy",
                table: "TextAssets",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TextAssetUuid",
                table: "TextAssets",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "Active",
                table: "FileTypes",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "FileTypes",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "FileTypes",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FileTypeName",
                table: "FileTypes",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "LastUpdatedAt",
                table: "FileTypes",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastUpdatedBy",
                table: "FileTypes",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Active",
                table: "AssetTypes",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "AssetTypeName",
                table: "AssetTypes",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "AssetTypes",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "AssetTypes",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastUpdatedAt",
                table: "AssetTypes",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastUpdatedBy",
                table: "AssetTypes",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_TextAssets",
                table: "TextAssets",
                column: "TextAssetId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_TextAssets",
                table: "TextAssets");

            migrationBuilder.DropColumn(
                name: "TextAssetId",
                table: "TextAssets");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "TextAssets");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "TextAssets");

            migrationBuilder.DropColumn(
                name: "LastUpdatedAt",
                table: "TextAssets");

            migrationBuilder.DropColumn(
                name: "LastUpdatedBy",
                table: "TextAssets");

            migrationBuilder.DropColumn(
                name: "TextAssetUuid",
                table: "TextAssets");

            migrationBuilder.DropColumn(
                name: "Active",
                table: "FileTypes");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "FileTypes");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "FileTypes");

            migrationBuilder.DropColumn(
                name: "FileTypeName",
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
                name: "AssetTypeName",
                table: "AssetTypes");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "AssetTypes");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "AssetTypes");

            migrationBuilder.DropColumn(
                name: "LastUpdatedAt",
                table: "AssetTypes");

            migrationBuilder.DropColumn(
                name: "LastUpdatedBy",
                table: "AssetTypes");

            migrationBuilder.AlterColumn<DateTime>(
                name: "OriginalDate",
                table: "TextAssets",
                type: "timestamp without time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AddColumn<long>(
                name: "Id",
                table: "TextAssets",
                type: "bigint",
                nullable: false,
                defaultValue: 0L)
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddColumn<string>(
                name: "Uuid",
                table: "TextAssets",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "FileTypes",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "AssetTypes",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TextAssets",
                table: "TextAssets",
                column: "Id");
        }
    }
}
