// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using TextAssetService.Models;

namespace TextAssetService.Migrations
{
    [DbContext(typeof(TextAssetDbContext))]
    [Migration("20201211204632_NonincrementingPrimaryKey")]
    partial class NonincrementingPrimaryKey
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .HasAnnotation("ProductVersion", "3.1.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("TextAssetService.Models.AssetType", b =>
                {
                    b.Property<long>("AssetTypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<bool>("ActiveFlag")
                        .HasColumnType("boolean");

                    b.Property<string>("AssetTypeName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("text");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("text");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("AssetTypeId");

                    b.HasIndex("ActiveFlag");

                    b.HasIndex("AssetTypeName")
                        .IsUnique();

                    b.ToTable("AssetTypes");
                });

            modelBuilder.Entity("TextAssetService.Models.FileType", b =>
                {
                    b.Property<long>("FileTypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<bool>("ActiveFlag")
                        .HasColumnType("boolean");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("text");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("FileTypeName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("MimeType")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("text");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("FileTypeId");

                    b.HasIndex("ActiveFlag");

                    b.HasIndex("MimeType")
                        .IsUnique();

                    b.ToTable("FileTypes");
                });

            modelBuilder.Entity("TextAssetService.Models.TextAsset", b =>
                {
                    b.Property<long>("TextAssetId")
                        .HasColumnType("bigint");

                    b.Property<bool>("ActiveFlag")
                        .HasColumnType("boolean");

                    b.Property<long>("AssetTypeId")
                        .HasColumnType("bigint");

                    b.Property<string>("CDNBasePath")
                        .HasColumnType("text");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("text");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<long>("FeatureId")
                        .HasColumnType("bigint");

                    b.Property<string>("FileName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<long>("FileTypeId")
                        .HasColumnType("bigint");

                    b.Property<string>("Headline")
                        .HasColumnType("text");

                    b.Property<DateTime>("IssueDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("text");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime?>("OriginalDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("TextAssetUuid")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("TextAssetId");

                    b.HasIndex("ActiveFlag");

                    b.HasIndex("AssetTypeId");

                    b.HasIndex("FeatureId");

                    b.HasIndex("FileName");

                    b.HasIndex("FileTypeId");

                    b.HasIndex("IssueDate");

                    b.HasIndex("OriginalDate");

                    b.HasIndex("TextAssetUuid")
                        .IsUnique();

                    b.ToTable("TextAssets");
                });

            modelBuilder.Entity("TextAssetService.Models.TextAssetGroup", b =>
                {
                    b.Property<long>("TextAssetGroupId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<bool>("ActiveFlag")
                        .HasColumnType("boolean");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("text");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<long>("FeatureId")
                        .HasColumnType("bigint");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("text");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime>("PublishDate")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("TextAssetGroupId");

                    b.HasIndex("ActiveFlag");

                    b.HasIndex("FeatureId");

                    b.HasIndex("PublishDate");

                    b.ToTable("TextAssetGroups");
                });

            modelBuilder.Entity("TextAssetService.Models.TextAssetGroupAsset", b =>
                {
                    b.Property<long>("TextAssetGroupAssetId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<bool>("ActiveFlag")
                        .HasColumnType("boolean");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("text");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("text");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<long>("OrderNumber")
                        .HasColumnType("bigint");

                    b.Property<long>("TextAssetGroupId")
                        .HasColumnType("bigint");

                    b.Property<long>("TextAssetId")
                        .HasColumnType("bigint");

                    b.HasKey("TextAssetGroupAssetId");

                    b.HasIndex("ActiveFlag");

                    b.HasIndex("TextAssetGroupId");

                    b.HasIndex("TextAssetId");

                    b.ToTable("TextAssetGroupAssets");
                });

            modelBuilder.Entity("TextAssetService.Models.TextAsset", b =>
                {
                    b.HasOne("TextAssetService.Models.AssetType", "AssetType")
                        .WithMany()
                        .HasForeignKey("AssetTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TextAssetService.Models.FileType", "FileType")
                        .WithMany()
                        .HasForeignKey("FileTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("TextAssetService.Models.TextAssetGroupAsset", b =>
                {
                    b.HasOne("TextAssetService.Models.TextAssetGroup", "TextAssetGroup")
                        .WithMany()
                        .HasForeignKey("TextAssetGroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TextAssetService.Models.TextAsset", "TextAsset")
                        .WithMany()
                        .HasForeignKey("TextAssetId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
