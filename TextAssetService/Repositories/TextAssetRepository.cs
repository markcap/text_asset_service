using TextAssetService.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using SerilogTimings;
using System;
using Microsoft.Extensions.Logging;
using TextAssetService.Exceptions;

namespace TextAssetService.Repository
{
    public class TextAssetRepository : ITextAssetRepository
    {
        private readonly TextAssetDbContext context;
        private readonly ILogger<TextAssetRepository> _logger;

        public TextAssetRepository(TextAssetDbContext context)
        {
            this.context = context;
        }

        public TextAssetRepository(ILogger<TextAssetRepository> logger, TextAssetDbContext _context)
        {
            _logger = logger;
            context = _context;
        }

        public async Task<TextAsset> GetByIdAsync(long textAssetId)
        {
            TextAsset textAsset;

            using (Operation.Time("GetByIdAsync database query"))
            {
                textAsset = await context.TextAssets.Include("AssetType")
                                                    .Include("FileType")
                                                    .FirstOrDefaultAsync<TextAsset>(f => f.TextAssetId == textAssetId);
            }

            if (textAsset == null)
            {
                throw new AmuNotFoundException($"Text Asset Id {textAssetId} not found.");
            }

            return textAsset;
        }

        /// <summary>Gets the assets by feature identifier and date.</summary>
        /// <param name="featureId">The feature identifier.</param>
        /// <param name="startDate">Start date of search.</param>
        /// <param name="endDate">End date of search.</param>
        /// <param name="count">Count of records returned, newest to oldest</param>
        /// <returns>List of asset items matching the given criteria</returns>
        /// <remarks>
        /// Defaults:
        ///     If no dates provided, default is today only.
        ///     If only StartDate provided, get specified date only.
        ///     If only EndDate provided, get from today to EndDate
        /// </remarks>
        public async Task<IEnumerable<TextAsset>> GetByFeatureIdFilteredAsync(long featureId, DateTime? startDate, DateTime? endDate, int? count)
        {
            List<TextAsset> assets;

            IQueryable<TextAsset> query = this.context.TextAssets.Include("AssetType")
                                                                 .Include("FileType")
                                                                 .Where(asset => asset.FeatureId == featureId)
                                                                 .Where(asset => asset.AssetType.AssetTypeName == "webready")
                                                                 .Where(asset => asset.FileType.FileTypeName == "application/xml")
                                                                 .OrderByDescending(asset => asset.IssueDate);
            // If no count, start or end date take 1 from today
            if (count == null && startDate == null && endDate == null)
            {
                count = 1;
            }

            // Always filter by start date. Default is today.
            var todayInCentral = CentralTimeZone(DateTime.Now);
            query = query.Where(asset => asset.IssueDate <= (startDate ?? todayInCentral));

            // Also limit by end date if provided
            if (endDate != null)
            {
                endDate = ((DateTime)endDate).Date;
                query = query.Where(asset => asset.IssueDate >= endDate);
            }

            // Limit total number to 50
            if (count == null || count > 50)
            {
                count = 50;
            }
            query = query.Take((int)count);

            using (Operation.Time("GetByFeatureIdDateFilteredAsync database query"))
            {
                assets = await query.ToListAsync();
            }

            return assets;
        }

        public async Task<TextAsset> GetUuhtmlAsync(long featureId, DateTime? date)
        {
            TextAsset asset;

            IQueryable<TextAsset> query = this.context.TextAssets.Include("AssetType")
                                                                 .Include("FileType")
                                                                 .Where(asset => asset.FeatureId == featureId)
                                                                 .Where(asset => asset.AssetType.AssetTypeName == "webready")
                                                                 .Where(asset => asset.FileType.FileTypeName == "text/uuhtml");

            // Always filter by start date. Default is today.
            query = query.Where(asset => asset.IssueDate == date);

            asset = await query.FirstOrDefaultAsync();

            return asset;
        }

        public async Task<IEnumerable<TextAsset>> GetSectionsAsync(long featureId, DateTime? date)
        {
            List<TextAsset> sections;

            IQueryable<TextAsset> query = this.context.TextAssets.Include("AssetType")
                                                                 .Include("FileType")
                                                                 .Where(asset => asset.FeatureId == featureId)
                                                                 .Where(asset => asset.AssetType.AssetTypeName == "section")
                                                                 .Where(asset => asset.FileType.FileTypeName == "application/xml")
                                                                 .OrderByDescending(asset => asset.IssueDate);


            // Truncate any time value from date
            if (date == null) date = DateTime.MinValue;
            date = ((DateTime)date).Date;

            query = query.Where(asset => asset.IssueDate == date);

            using (Operation.Time("GetByFeatureIdDateFilteredAsync database query"))
            {
                sections = await query.ToListAsync();
            }

            return sections;
        }

        public async Task<IEnumerable<string>> GetArchiveYearsAsync(long featureId)
        {
            var yearsList = new List<string>();
            var tomorrow = DateTime.Today.Date.AddDays(1);

            using (Operation.Time("GetArchiveYearsAsync database query"))
            {
                yearsList = await context.TextAssets.Include("AssetType")
                                                    .Include("FileType")
                                                    .Where(a => a.FeatureId == featureId)
                                                    .Where(a => a.AssetType.AssetTypeName == "webready")
                                                    .Where(a => a.FileType.FileTypeName == "application/xml")
                                                    .Where(a => a.IssueDate < tomorrow)
                                                    .GroupBy(a => new { a.IssueDate.Year })
                                                    .Select(g => new { Year = g.Key.Year.ToString() })
                                                    .OrderByDescending(a => a.Year)
                                                    .Select(y => y.Year)
                                                    .ToListAsync();
            }

            return yearsList;
        }

        public async Task<IEnumerable<TextAssetGroupAsset>> GetGroupByFeatureIdFilteredAsync(long featureId, DateTime? publishDate)
        {
            List<TextAssetGroupAsset> groupAssets;

            IQueryable<TextAssetGroupAsset> query = publishDate == null ? null :
               context.TextAssetGroupAssets.Include("TextAssetGroup")
                                                                .Include("TextAsset")
                                                                .Where(a => a.TextAsset.FeatureId == featureId)
                                                                .Where(a => a.TextAssetGroup.PublishDate.Date == publishDate);

            groupAssets = query == null ? new List<TextAssetGroupAsset>() : await query.ToListAsync();
            return groupAssets;
        }

        public async Task<TextAssetGroupAsset> GetGroupByIdAsync(long featureId)
        {
            TextAssetGroupAsset textAssetGroupAsset = await context.TextAssetGroupAssets
                                                             .Include("TextAssetGroup")
                                                             .Include("TextAsset")
                                                             .FirstOrDefaultAsync<TextAssetGroupAsset>(f => f.TextAssetGroupAssetId == featureId);
          
            return textAssetGroupAsset;
        }

        public async Task<List<TextAsset>> GetHeadlines(List<long> textAssetIds)
        {
            List<TextAsset> textAssets = new List<TextAsset>();

            foreach(long textAssetId in textAssetIds)
            {
                TextAsset asset;
                IQueryable<TextAsset> query = this.context.TextAssets.Include("AssetType")
                                                                 .Include("FileType")
                                                                 .Where(asset => asset.TextAssetId == textAssetId)
                                                                 .Where(asset => asset.AssetType.AssetTypeName == "webready")
                                                                 .Where(asset => asset.FileType.FileTypeName == "text/uuhtml");

                asset = await query.FirstOrDefaultAsync();
                textAssets.Add(asset);
            }
            return textAssets;
        }

        public async Task<List<TextAsset>> GetHeadlinesByTopic(string slug, long featureId, DateTime? startDate = null, DateTime? endDate = null, int? count = null)
        {
            List<long> assetIds;
            List<TextAsset> assets;

            IQueryable<long> query1 = this.context.Tagging.Include("Tag")
                                                          .Where(asset => asset.FeatureId == featureId)
                                                          .Where(asset => asset.Tag.Slug == slug)
                                                          .Select(asset => asset.TaggableId);

            assetIds = query1.ToList();

            IQueryable<TextAsset> query = this.context.TextAssets.Include("AssetType")
                                                                 .Include("FileType")
                                                                 .Where(asset => asset.FeatureId == featureId)
                                                                 .Where(asset => asset.FileType.FileTypeName == "text/uuhtml")
                                                                 .Where(asset => assetIds.Contains(asset.TextAssetId))
                                                                 .Where(asset => asset.IssueDate <= DateTime.Today)
                                                                 .OrderByDescending(asset => asset.IssueDate);
            // If no count, start or end date take 1 from today
            if (count == null && startDate == null && endDate == null)
            {
                count = 1;
            }

            // Always filter by start date. Default is today.
            var todayInCentral = CentralTimeZone(DateTime.Now);
            query = query.Where(asset => asset.IssueDate <= (startDate ?? todayInCentral));

            // Also limit by end date if provided
            if (endDate != null)
            {
                endDate = ((DateTime)endDate).Date;
                query = query.Where(asset => asset.IssueDate >= endDate);
            }

            // Limit total number to 50
            if (count == null || count > 50)
            {
                count = 50;
            }
            query = query.Take((int)count);

            using (Operation.Time("GetByFeatureIdDateFilteredAsync database query"))
            {
                assets = await query.ToListAsync();
            }

            return assets;
        }

        public async Task<List<TextAssetTopic>> GetHeadlinesByCategoryFeatures(List<long> featureIds)
        {
            List<TextAssetTopic> topicAssets = new List<TextAssetTopic>();
            List<string> topics;

            IQueryable<string> topicNameQuery = this.context.Tagging.Include("Tag")
                                                          .Where(asset => featureIds.Contains(asset.FeatureId.Value))
                                                          .Where(asset => asset.Context == "topics")
                                                          .Where(asset => asset.TaggableType == "Feature")
                                                          .Select(asset => asset.Tag.TagName)
                                                          .Distinct();

            topics = topicNameQuery.ToList();

            foreach(string topic in topics)
            {
                var join =  from s in this.context.TextAssets join r in this.context.Tagging on s.TextAssetId equals r.TaggableId
                where(r.Tag.TagName == topic && r.Context == "topics" && s.FileType.FileTypeName == "text/uuhtml" && featureIds.Contains(s.FeatureId) && s.IssueDate <= DateTime.Today)
                select s;

                List<TextAsset> list = await join.OrderByDescending(asset => asset.IssueDate)
                    .Take(2)
                    .ToListAsync();

                TextAssetTopic topicArticles = new TextAssetTopic();
                topicArticles.TextAssets = list;
                topicArticles.TopicName = topic;

                topicAssets.Add(topicArticles);

                
            }

            return topicAssets;

        }

        private static DateTime? CentralTimeZone(DateTime originalDate)
        {
           return TimeZoneInfo.ConvertTime(originalDate, TimeZoneInfo.FindSystemTimeZoneById("US/Central"));
        }
    }
}