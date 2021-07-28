using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TextAssetService.Controllers;
using TextAssetService.Models;
using Xunit;
using System.Collections.Generic;
using System.Linq;

namespace TextAssetService.UnitTests.Controllers
{
    public class TextAssetGroupAssetControllerUnitTest
    {
        // TODO Replace abandoned test
        //[Fact]
        public async Task TestDateRangeGetMethod()
        {
            await Task.FromResult(0);
            // Arrange
            //   TextAssetDbContext dbContext = DbContextMocker.GetTextAssetDbContext(nameof(TextAssetGroupAssetControllerUnitTest));
            //   TextAssetGroupAssetsController controller = new TextAssetGroupAssetsController(null, dbContext);
            //   // Act
            //   var response = await controller.Get(1, new DateTime(2008, 5, 1));

            //   // Assert
            //   var result = Assert.IsType<ActionResult<IEnumerable<TextAssetGroupAsset>>>(response);
            //   List<TextAssetGroupAsset> textAssetList = Assert.IsType<List<TextAssetGroupAsset>>(
            //       response.Value);
            //   IQueryable<TextAsset> query = dbContext.TextAssets.Where(asset => asset.TextAssetId > 0);

            //   TextAssetGroupAsset textAsset = textAssetList[0];
            //   Assert.Equal(query.First(), textAsset.TextAsset);
            //   Assert.Equal(1, textAssetList.Count);
            //   dbContext.Dispose();
        }
    }
}