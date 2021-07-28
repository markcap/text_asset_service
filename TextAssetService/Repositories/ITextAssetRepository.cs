using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TextAssetService.Models;

namespace TextAssetService.Repository
{
    public interface ITextAssetRepository
    {
        Task<TextAsset> GetByIdAsync(long textAssetId);
        Task<IEnumerable<TextAsset>> GetByFeatureIdFilteredAsync(long featureId, DateTime? startDate, DateTime? oldestDate, int? count);
        Task<TextAsset> GetUuhtmlAsync(long featureId, DateTime? date);
        Task<IEnumerable<TextAsset>> GetSectionsAsync(long featureId, DateTime? date);
        Task<IEnumerable<string>> GetArchiveYearsAsync(long featureId);
        Task<IEnumerable<TextAssetGroupAsset>> GetGroupByFeatureIdFilteredAsync(long featureId, DateTime? publishDate);
        Task<TextAssetGroupAsset> GetGroupByIdAsync(long featureId);
        Task<List<TextAsset>> GetHeadlines(List<long> textAssetIds);
        Task<List<TextAsset>> GetHeadlinesByTopic(string slug, long featureId, DateTime? startDate = null, DateTime? endDate = null, int? count = null);
        Task<List<TextAssetTopic>> GetHeadlinesByCategoryFeatures(List<long> featureIds);
    }
}