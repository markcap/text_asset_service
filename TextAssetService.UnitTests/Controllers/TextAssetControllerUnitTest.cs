using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TextAssetService.Controllers;
using TextAssetService.Service;
using TextAssetService.Repository;
using TextAssetService.Models;
using Xunit;
using System.Collections.Generic;

namespace TextAssetService.UnitTests.Controllers
{
    public class TextAssetControllerUnitTest
    {
        //[Fact]
        //public async Task TestDateRangeGetMethod()
        //{
        //    // Arrange
        //    TextAssetDbContext dbContext = DbContextMocker.GetTextAssetDbContext(nameof(TextAssetControllerUnitTest));
        //    var textAssetRepo = new TextAssetRepository(dbContext);
        //    var textAssetService = new TextAssetServiceLayer(textAssetRepo); 
        //    TextAssetsController controller = new TextAssetsController(null, textAssetService);
        //    var response = await controller.GetByFeatureIdDateFiltered(1, null, null, 1);
        //    // Assert
        //    var result = Assert.IsType<ActionResult<IEnumerable<TextAsset>>>(response);
        //    dbContext.Dispose();
        //}
    }
}