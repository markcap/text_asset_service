using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using TextAssetService.Models;
using System;

namespace TextAssetService
{
    public static class DbInitializer
    {
        public static async void SeedDb(this IApplicationBuilder app, bool development = false)
        {
            using (var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            using (var context = serviceScope.ServiceProvider.GetService<TextAssetDbContext>())
            {
                var textAssetCount = await context.TextAssets.CountAsync();
                if (development && textAssetCount == 0)
                    context.Seed();
            }
        }

        private static void Seed(this TextAssetDbContext context)
        {
            AssetType webready = new AssetType
            {
                AssetTypeName = "webready",
            };
            context.AssetTypes.Add(webready);

            FileType jpeg = new FileType
            {
                FileTypeName = "jpeg",
                MimeType = "jpeg/image",
            };
            context.FileTypes.Add(jpeg);

            TextAssetGroup group = new TextAssetGroup
            {
                FeatureId = 1,
                PublishDate = DateTime.Now,
            };
            context.TextAssetGroups.Add(group);

            context.TextAssets.Add(new TextAsset
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
            });

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
                FileType = jpeg,
            });

            context.SaveChanges();
        }
    }

}
