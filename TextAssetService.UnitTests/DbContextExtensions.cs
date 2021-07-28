using System;
using TextAssetService.Models;

namespace TextAssetService.UnitTests
{
    public static class DbContextExtensions
    {
        public static void Seed(this TextAssetDbContext context)
        {
            // Add entities for DbContext instance


            AssetType webready = new AssetType
            {
                AssetTypeName = "webready",
            };
            context.AssetTypes.Add(webready);

            AssetType headline = new AssetType
            {
                AssetTypeName = "section",
            };
            context.AssetTypes.Add(headline);

            FileType jpeg = new FileType
            {
                FileTypeName = "jpeg",
                MimeType = "jpeg/image",
            };
            context.FileTypes.Add(jpeg);

            FileType xml = new FileType
            {
                FileTypeName = "application/xml",
                MimeType = "jpeg/image",
            };
            context.FileTypes.Add(xml);

            TextAsset textAsset = new TextAsset
            {
                TextAssetId = 1,
                FeatureId = 1,
                ActiveFlag = true,
                FileName = "xd.jpg",
                Headline = "headline",
                CDNBasePath = "/home/thing.jpg",
                TextAssetUuid = "efhui",
                AssetType = webready,
                FileType = jpeg,
                IssueDate = new DateTime(2008, 5, 1),
            };
            context.TextAssets.Add(textAsset);

            context.TextAssets.Add(new TextAsset
            {
                TextAssetId = 2,
                FeatureId = 2,
                ActiveFlag = true,
                FileName = "wow.jpg",
                Headline = "",
                CDNBasePath = "/home/wow.jpg",
                TextAssetUuid = "523525234efefwfe",
                AssetType = webready,
                FileType = xml,
                IssueDate = new DateTime(2001, 5, 1),
            });

            context.TextAssets.Add(new TextAsset
            {
                TextAssetId = 3,
                FeatureId = 3,
                ActiveFlag = true,
                FileName = "doublewow.jpg",
                Headline = "",
                CDNBasePath = "/home/doublewow.jpg",
                TextAssetUuid = "523525634efefwfe",
                AssetType = webready,
                FileType = xml,
                IssueDate = new DateTime(2010, 5, 1),
            });

            context.TextAssets.Add(new TextAsset
            {
                TextAssetId = 4,
                FeatureId = 4,
                ActiveFlag = true,
                FileName = "triplewow.jpg",
                Headline = "another headline",
                CDNBasePath = "/home/triplelewow.jpg",
                TextAssetUuid = "523525834efefwfe",
                AssetType = headline,
                FileType = xml,
                IssueDate = new DateTime(2008, 5, 1),
            });

            context.TextAssets.Add(new TextAsset
            {
                TextAssetId = 5,
                FeatureId = 5,
                ActiveFlag = true,
                FileName = "unwow.jpg",
                Headline = "yet another headline",
                CDNBasePath = "/home/unwow.jpg",
                TextAssetUuid = "523525834efefwfe",
                AssetType = headline,
                FileType = jpeg,
                IssueDate = new DateTime(2008, 5, 1),
            });
            TextAssetGroup group = new TextAssetGroup
            {
                FeatureId = 1,
                ActiveFlag = true,
                PublishDate = new DateTime(2008, 5, 1),
            };
            context.TextAssetGroups.Add(group);

            context.TextAssetGroupAssets.Add(new TextAssetGroupAsset
            {
                TextAsset = textAsset,
                TextAssetGroup = group
            });

            context.SaveChanges();
        }
    }
}
