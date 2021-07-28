using AutoMapper;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextAssetService.Exceptions;
using TextAssetService.Models;
using TextAssetService.Repository;
using TextAssetService.Service;
using Xunit;
using Xunit.Abstractions;

namespace TextAssetService.UnitTests
{
    public class TextAssetUnitTests
    {
        private readonly ITestOutputHelper _output;
        private readonly TextAssetRepository _textAssetRepository;
        private readonly TextAssetServiceLayer _textAssetServiceLayer;
        readonly TextAssetDbContext _dbContext;

        public TextAssetUnitTests(ITestOutputHelper output)
        {
            _output = output;
            _dbContext = DbContextMocker.GetTextAssetDbContext(nameof(TextAssetUnitTests));
            var mockTextAssetLogger = new Mock<ILogger<TextAssetRepository>>();
            var mockTextAssetServiceLogger = new Mock<ILogger<TextAssetServiceLayer>>();
            _textAssetRepository = new TextAssetRepository(mockTextAssetLogger.Object, _dbContext);
            _textAssetServiceLayer = new TextAssetServiceLayer(mockTextAssetServiceLogger.Object, _textAssetRepository);
        }

        #region Repository
        [Fact]
        public async Task GetByIdAsync_ReturnsAsset()
        {
            // Arrange
            var assetId = 1;

            // Act
            var assetList = await _textAssetRepository.GetByIdAsync(assetId);

            // Assert
            Assert.IsType<TextAsset>(assetList);
            Assert.Equal("xd.jpg", assetList.FileName);

            _dbContext.Dispose();
        }

        [Theory]
        [InlineData(99)]
        //[InlineData(null)]
        public async Task GetByIdAsync_NotFound(long assetId)
        {
            // Arrange

            // Act and Assert
            await Assert.ThrowsAsync<AmuNotFoundException>(() => _textAssetRepository.GetByIdAsync(assetId));

            _dbContext.Dispose();
        }

        public static readonly object[][] GetFeatureIdFilteredData =
        {
            new object[]{2,null,null,null},
            new object[]{2,null, null,1}
        };

        [Theory, MemberData(nameof(GetFeatureIdFilteredData))]
        public async Task GetFeatureIdFiltered_ReturnAssetList(long featureId, DateTime? startDate, DateTime? endDate, int? count)
        {
            // Arrange

            // Act
            var assetList = await _textAssetRepository.GetByFeatureIdFilteredAsync(featureId, startDate, endDate, count);

            // Assert
            Assert.IsType<List<TextAsset>>(assetList);

            TextAsset asset = ((IEnumerable<TextAsset>)assetList).ToList<TextAsset>()[0];
            Assert.Equal("wow.jpg", asset.FileName);

            _dbContext.Dispose();
        }

        /*****   Not testing for nullable long values
        public static readonly object[][] GetFeatureIdData =
        {
            new object[]{ null, null, null, null },
            new object[]{ null, new DateTime(0001, 01, 01), null, null },
            new object[]{ null, null, DateTime.Now.AddDays(-5), null },
        };

        [Theory, MemberData(nameof(GetFeatureIdData))]
        public async Task GetFeatureIdFiltered_NotFound(long? featureId, DateTime? startDate, DateTime? endDate, int? count)
        {
            // Arrange

            // Act and Assert
            await Assert.ThrowsAsync<UexpressNotFoundException>(() => _textAssetRepository.GetByFeatureIdFilteredAsync(featureId, startDate, endDate, count));

            _dbContext.Dispose();
        }
        *************************/

        public static readonly object[][] ReturnEmptyData =
        {
            new object[]{ 99, null, null, null },
            new object[]{ 3, new DateTime(2010,04,30), null, 1}
        };
        [Theory, MemberData(nameof(ReturnEmptyData))]
        public async Task GetFeatureIdFiltered_ReturnEmpty(long featureId, DateTime? startDate, DateTime? endDate, int? count)
        {
            // Arrange

            // Act
            var assetList = await _textAssetRepository.GetByFeatureIdFilteredAsync(featureId, startDate, endDate, count);

            // Assert
            Assert.IsType<List<TextAsset>>(assetList);
            Assert.Empty(assetList);

            _dbContext.Dispose();
        }

        // [Fact]
        // public async Task GetLetterHeadline_HeadlineFound()
        // {
        //     // Arrange
        //     var featureId = 4;
        //     var date = new DateTime(2008, 5, 1);

        //     // Act
        //     var headlineList = await _textAssetRepository.GetLetterHeadlineAsync(featureId, date);

        //     // Assert
        //     Assert.IsType<List<string>>(headlineList);
        //     string headline = ((IEnumerable<string>)headlineList).ToList<string>()[0];

        //     Assert.Equal("another headline", headline);

        //     _dbContext.Dispose();
        // }

        /************* Not testing for nullable long values
        public static readonly object[][] GetLetterHeadlineData =
        {
            new object[]{ null, null },
            new object[]{ null, new DateTime(2008,4,30) }, // Incorrect issue date
        //     new object[]{ 1, null }, // AssetType not correct
        //     new object[]{ 5, null }, // FileType not correct
        //     new object[]{ 99, null }, // Out of range
        //     new object[]{ 4, new DateTime(2008,4,30) }, // Incorrect issue date
        // };

        // [Theory, MemberData(nameof(GetLetterHeadlineData))]
        // public async Task GetLetterHeadline_NotFound(long? featureId, DateTime? date)
        // {
        //     // Arrange

        //     // Act and Assert
        //     await Assert.ThrowsAsync<UexpressNotFoundException>(() => _textAssetRepository.GetLetterHeadlineAsync(featureId, date));

            _dbContext.Dispose();
        }
        *****************************************/

        public static readonly object[][] ReturnEmptyLetterHeadlineData =
        {
            new object[]{ 1, null }, // AssetType not correct
            new object[]{ 5, null }, // FileType not correct
            new object[]{ 99, null }, // Out of range
            new object[]{ 4, new DateTime(2008,4,30) }, // Incorrect issue date
        };

        [Theory, MemberData(nameof(ReturnEmptyLetterHeadlineData))]
        public async Task GetLetterHeadline_ReturnEmpty(long featureId, DateTime? date)
        {
            // Arrange

            // Act
            var headlineList = await _textAssetRepository.GetSectionsAsync(featureId, date);

            // Assert
            Assert.IsType<List<TextAsset>>(headlineList);
            Assert.Empty(headlineList);

            _dbContext.Dispose();
        }

        [Fact]
        public async Task GetArchiveYear_ReturnList()
        {
            // Arrange
            var featureId = 2;

            // Act
            var years = await _textAssetRepository.GetArchiveYearsAsync(featureId);

            // Assert
            Assert.IsType<List<string>>(years);

            string year = ((IEnumerable<string>)years).ToList<string>()[0];
            Assert.Equal("2001", year);

            _dbContext.Dispose();
        }

        /***************** Not testing for nullible long values
        [Fact]
        public async Task GetArchiveYear_NotFound()
        {
            // Arrange
            long? featureId = null;

            // Act and Assert
            await Assert.ThrowsAsync<UexpressNotFoundException>(() => _textAssetRepository.GetArchiveYearsAsync(featureId));

            _dbContext.Dispose();
        }
        *******************************/

        [Theory]
        [InlineData(1)]
        [InlineData(99)]
        public async Task GetArchiveYear_ReturnEmpty(long featureId)
        {
            // Arrange

            // Act
            var years = await _textAssetRepository.GetArchiveYearsAsync(featureId);

            // Assert
            Assert.IsType<List<string>>(years);
            Assert.Empty(years);

            _dbContext.Dispose();
        }
        #endregion

        #region Services
        [Fact]
        public async Task GetByIdService_ReturnsAsset()
        {
            // Arrange
            var assetId = 1;

            // Act
            var assetList = await _textAssetServiceLayer.GetByIdAsync(assetId);

            // Assert
            Assert.IsType<TextAsset>(assetList);
            Assert.Equal("xd.jpg", assetList.FileName);

            _dbContext.Dispose();
        }

        [Theory]
        //[InlineData(null)]
        [InlineData(99)]
        public async Task GetByIdService_NotFound(long assetId)
        {
            // Arrange

            // Act and Assert
            await Assert.ThrowsAsync<AmuNotFoundException>(() => _textAssetServiceLayer.GetByIdAsync(assetId));

            _dbContext.Dispose();
        }

        [Theory, MemberData(nameof(GetFeatureIdFilteredData))]
        public async Task GetFeatureIdFilteredService_ReturnAssetList(long featureId, DateTime? startDate, DateTime? endDate, int? count)
        {
            // Arrange

            // Act
            var assetList = await _textAssetServiceLayer.GetByFeatureIdFilteredAsync(featureId, startDate, endDate, count);

            // Assert
            Assert.IsType<List<TextAsset>>(assetList);

            TextAsset asset = ((IEnumerable<TextAsset>)assetList).ToList<TextAsset>()[0];
            Assert.Equal("wow.jpg", asset.FileName);

            _dbContext.Dispose();
        }

        /***************** Not testing for nullible long values
        [Theory, MemberData(nameof(GetFeatureIdData))]
        public async Task GetFeatureIdFilteredService_NotFound(long featureId, DateTime? startDate, DateTime? endDate, int? count)
        {
            // Arrange

            // Act and Assert
            await Assert.ThrowsAsync<UexpressNotFoundException>(() => _textAssetServiceLayer.GetByFeatureIdFilteredAsync(featureId, startDate, endDate, count));

            _dbContext.Dispose();
        }
        ******************************************/

        [Theory, MemberData(nameof(ReturnEmptyData))]
        public async Task GetFeatureIdFilteredService_ReturnEmpty(long featureId, DateTime? startDate, DateTime? endDate, int? count)
        {
            // Arrange

            // Act
            var assetList = await _textAssetServiceLayer.GetByFeatureIdFilteredAsync(featureId, startDate, endDate, count);

            // Assert
            Assert.IsType<List<TextAsset>>(assetList);
            Assert.Empty(assetList);

            _dbContext.Dispose();
        }

        // [Fact]
        // public async Task GetLetterHeadlineService_HeadlineFound()
        // {
        //     // Arrange
        //     var featureId = 4;
        //     var date = new DateTime(2008, 5, 1);

        //     // Act
        //     var headlineList = await _textAssetServiceLayer.GetLetterHeadlineAsync(featureId, date);

        //     // Assert
        //     Assert.IsType<List<string>>(headlineList);
        //     string headline = ((IEnumerable<string>)headlineList).ToList<string>()[0];

        //     Assert.Equal("another headline", headline);

        //     _dbContext.Dispose();
        // }

        /*************** Not testing for nullible long values
        [Theory, MemberData(nameof(GetLetterHeadlineData))]
        public async Task GetLetterHeadlineService_NotFound(long featureId, DateTime? date)
        {
            // Arrange

        //     // Act and Assert
        //     await Assert.ThrowsAsync<UexpressNotFoundException>(() => _textAssetServiceLayer.GetLetterHeadlineAsync(featureId, date));

            _dbContext.Dispose();
        }
        *******************************************/

        [Theory,MemberData(nameof(ReturnEmptyLetterHeadlineData))]
        public async Task GetLetterHeadlineService_ReturnEmpty(long featureId, DateTime? date)
        {
            // Arrange
            // Act
            var headlineList = await _textAssetServiceLayer.GetSectionsAsync(featureId, date);

            // Assert
            Assert.IsType<List<TextAsset>>(headlineList);
            Assert.Empty(headlineList);

            _dbContext.Dispose();
        }

        [Fact]
        public async Task GetArchiveYearService_ReturnList()
        {
            // Arrange
            var featureId = 2;

            // Act
            var years = await _textAssetServiceLayer.GetArchiveYearsAsync(featureId);

            // Assert
            Assert.IsType<List<string>>(years);

            string year = ((IEnumerable<string>)years).ToList<string>()[0];
            Assert.Equal("2001", year);

            _dbContext.Dispose();
        }

        /**************** Not testing for nullible long values
        [Theory]
        [InlineData(null)]
        [InlineData(1)]
        [InlineData(99)]
        public async Task GetArchiveYearService_NotFound(long featureId)
        {
            // Arrange

            // Act and Assert
            await Assert.ThrowsAsync<UexpressNotFoundException>(() => _textAssetServiceLayer.GetArchiveYearsAsync(featureId));

            _dbContext.Dispose();
        }
        **********************************/

        [Theory]
        [InlineData(1)]
        [InlineData(99)]
        public async Task GetArchiveYearService_ReturnEmpty(long featureId)
        {
            // Arrange

            // Act
            var years = await _textAssetServiceLayer.GetArchiveYearsAsync(featureId);

            // Assert
            Assert.IsType<List<string>>(years);
            Assert.Empty(years);

            _dbContext.Dispose();
        }

        #endregion

        #region GroupAssets
        [Fact]
        public async Task GetGroupByFeatureIdFiltered_ReturnAssetList()
        {
            // Arrange
            var featureId = 1;
            var publishDate = new DateTime(2008, 05, 01);

            // Act
            var assetList = await _textAssetRepository.GetGroupByFeatureIdFilteredAsync(featureId, publishDate);

            // Assert
            Assert.IsType<List<TextAssetGroupAsset>>(assetList);

            _dbContext.Dispose();
        }

        public static readonly object[][] ReturnEmptyGroup =
        {
            new object[]{ 1, null },
            new object[]{ 1, new DateTime(2010,04,30)}
        };

        [Theory, MemberData(nameof(ReturnEmptyGroup))]
        public async Task GetGroupByFeatureIdFiltered_ReturnEmpty(long featureId, DateTime? publishDate)
        {
            // Arrange

            // Act
            var assetList = await _textAssetRepository.GetGroupByFeatureIdFilteredAsync(featureId, publishDate);

            // Assert
            Assert.IsType<List<TextAssetGroupAsset>>(assetList);
            Assert.Empty(assetList);

            _dbContext.Dispose();
        }

        //If group assets return, need additional tests
        #endregion
    }
}
