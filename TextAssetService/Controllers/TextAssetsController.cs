using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.Logging;
using TextAssetService.Models;
using System.Threading.Tasks;
using System.Collections.Generic;
using System;
using TextAssetService.Services;
using Microsoft.AspNetCore.Http;
using TextAssetService.Middleware;

namespace TextAssetService.Controllers
{
    [Route("v{version:apiVersion}/text-assets")]
    [ApiController]
    [ApiVersion("1.0")]
    public class TextAssetsController : ControllerBase
    {

        private readonly ILogger<TextAssetsController> _logger;
         private readonly ITextAssetService _textAssetService;

        public TextAssetsController(ILogger<TextAssetsController> logger, ITextAssetService service)
        {
            _logger = logger;
            _textAssetService = service;
        }

        /// <summary>Gets a single text asset by ID.</summary>
        /// <param name="textAssetId">The text asset identifier (i.e., database key).</param>
        /// <remarks>
        /// 
        /// Sample request:
        ///
        ///     GET /v1/text-assets/textAssetId/314849
        ///     
        /// </remarks>
        /// <returns>
        ///   Requested text asset including details.
        /// </returns>        
        [HttpGet("textAssetId/{textAssetId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponseData), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ErrorResponseData), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorResponseData), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<TextAsset>> GetById(long textAssetId)
        {
            TextAsset textAsset = await _textAssetService.GetByIdAsync(textAssetId);
            if (textAsset == null)
            {
                return NotFound();
            }

            return textAsset;
        }

        /// <summary>Gets the assets by feature identifier and date.</summary>
        /// <param name="featureId">The feature identifier.</param>
        /// <param name="startDate">Retrieve assets no newer than this.</param>
        /// <param name="endDate">Retrieve assets no older than this.</param>
        /// <param name="count">Count of assets to retrieve.</param>
        /// <returns>List of asset items matching the given criteria</returns>
        [HttpGet("featureId/{featureId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponseData), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorResponseData), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<TextAsset>>> GetByFeatureIdDateFiltered(long featureId,
                                                                                     [FromQuery] DateTime? startDate = null,
                                                                                     [FromQuery] DateTime? endDate = null,
                                                                                     [FromQuery] int? count = null)
        {
            #region validation
            if (featureId < 1)
            {
                return UnprocessableEntity("Feature ID must be a positive number");
            }

            // If either null, null comparisons are always false.
            if (endDate > startDate)
            {
                return UnprocessableEntity("End Date must preceed Start Date");
            }

            if (count < 1)
            {
                return UnprocessableEntity("Count must be positive");
            }
            #endregion

            IEnumerable<TextAsset> asset = await _textAssetService.GetByFeatureIdFilteredAsync(featureId, startDate, endDate, count);

            return Ok(asset);
        }

        [HttpGet("uuhtml/{featureId}")]
        public async Task<ActionResult<TextAsset>> GetUuhtmlAsync(long featureId, [FromQuery] DateTime? date)
        {
             #region validation
            if (featureId < 1)
            {
                return UnprocessableEntity("Feature ID must be a positive number");
            }
            #endregion

            TextAsset asset = await _textAssetService.GetUuhtmlAsync(featureId, date);

            return Ok(asset);
        }

        /// <summary>Gets the section headlines by feature identifier and date.</summary>
        /// <param name="featureId">The feature identifier.</param>
        /// <param name="date">date of article to search.</param>
        /// <returns>List of headline strings matching the given criteria</returns>
        [HttpGet("headlines/featureId/{featureId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponseData), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorResponseData), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<TextAsset>>> GetSectionsAsync(long featureId, [FromQuery, BindRequired] DateTime? date)
        {
            #region validation
            if (featureId < 1)
            {
                return UnprocessableEntity("Feature ID must be a positive number");
            }
            #endregion

            IEnumerable<TextAsset> asset = await _textAssetService.GetSectionsAsync(featureId, date);

            return Ok(asset);
        }

        [HttpGet("archives/featureId/{featureId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponseData), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorResponseData), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<string>>> GetArchiveYears(long featureId)
        {
            var years = await _textAssetService.GetArchiveYearsAsync(featureId);

            return Ok(years);
        }

        [HttpGet("headlines/textAssetIds/")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponseData), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorResponseData), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<List<TextAsset>>> GetHeadlines([FromQuery, BindRequired] List<long> textAssetIds)
        {
            var headlines = await _textAssetService.GetHeadlines(textAssetIds);

            return Ok(headlines);
        }

        [HttpGet("headlines/topic/{slug}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponseData), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorResponseData), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<List<TextAsset>>> GetHeadlinesByTopic(string slug, 
                                                                      [FromQuery] long featureId, 
                                                                      [FromQuery] DateTime? startDate = null,
                                                                      [FromQuery] DateTime? endDate = null,
                                                                      [FromQuery] int? count = null)
        {
            var headlines = await _textAssetService.GetHeadlinesByTopic(slug, featureId, startDate, endDate, count);

            return Ok(headlines);
        }

        [HttpGet("headlines/categoryTopic/")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponseData), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorResponseData), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<List<TextAssetTopic>>> GetHeadlinesByCategoryFeatures([FromQuery, BindRequired] List<long> featureIds)
        {
            var headlines = await _textAssetService.GetHeadlinesByCategoryFeatures(featureIds);

            return Ok(headlines);
        }
    }
}
