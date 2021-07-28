using TextAssetService.Models;
using TextAssetService.Repository;
using TextAssetService.Services;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using Microsoft.Extensions.Logging;

namespace TextAssetService.Service
{

    public class TextAssetServiceLayer : ITextAssetService
    {
        private readonly ITextAssetRepository _textAssetRepo;
        private readonly ILogger<TextAssetServiceLayer> _logger;

        public TextAssetServiceLayer(ITextAssetRepository textAssetRepo)
        {
            _textAssetRepo = textAssetRepo;
        }

        public TextAssetServiceLayer(ILogger<TextAssetServiceLayer> logger, ITextAssetRepository textAssetRepo)
        {
            _logger = logger;
            _textAssetRepo = textAssetRepo;
        }

        public async Task<TextAsset> GetByIdAsync(long textAssetId)
        {
            return await _textAssetRepo.GetByIdAsync(textAssetId);
        }
        
        public async Task<IEnumerable<TextAsset>> GetByFeatureIdFilteredAsync(long featureId, DateTime? startDate, DateTime? oldestDate, int? count)
        {
            return await _textAssetRepo.GetByFeatureIdFilteredAsync(featureId, startDate, oldestDate, count);
        }

        public async Task<TextAsset> GetUuhtmlAsync(long featureId, DateTime? date)
        {
            return await _textAssetRepo.GetUuhtmlAsync(featureId, date);
        }

        public async Task<IEnumerable<TextAsset>> GetSectionsAsync(long featureId, DateTime? date)
        {
            return await _textAssetRepo.GetSectionsAsync(featureId, date);
        }

        public async Task<IEnumerable<string>> GetArchiveYearsAsync(long featureId)
        {
            return await _textAssetRepo.GetArchiveYearsAsync(featureId);
        }

        public async Task<IEnumerable<TextAssetGroupAsset>> GetGroupByFeatureIdFilteredAsync(long featureId, DateTime? publishDate)
        {
            return await _textAssetRepo.GetGroupByFeatureIdFilteredAsync(featureId, publishDate);
        }

        public async Task<TextAssetGroupAsset> GetGroupByIdAsync(long featureId)
        {
            return await _textAssetRepo.GetGroupByIdAsync(featureId);
        }

        public async Task<List<TextAsset>> GetHeadlines(List<long> textAssetIds)
        {
             return await _textAssetRepo.GetHeadlines(textAssetIds);
        }

         public async Task<List<TextAsset>> GetHeadlinesByTopic(string slug, long featureId, DateTime? startDate = null, DateTime? endDate = null, int? count = null)
         {
             return await _textAssetRepo.GetHeadlinesByTopic(slug, featureId, startDate, endDate, count);
         }

         public async Task<List<TextAssetTopic>> GetHeadlinesByCategoryFeatures(List<long> featureIds)
         {
             return await _textAssetRepo.GetHeadlinesByCategoryFeatures(featureIds);
         }
    }
}