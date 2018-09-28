using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using AutoMapper;
using Common.Log;
using JetBrains.Annotations;
using Lykke.Common.Api.Contract.Responses;
using Lykke.Common.Log;
using Lykke.Service.PayTransferValidation.Domain;
using Lykke.Service.PayTransferValidation.Domain.Exceptions;
using Lykke.Service.PayTransferValidation.Domain.Repositories;
using Lykke.Service.PayTransferValidation.Domain.Services;
using Lykke.Service.PayTransferValidation.Models.MerchantConfiguration;
using LykkePay.Common.Validation;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Lykke.Service.PayTransferValidation.Controllers
{
    [Route("api/configuration")]
    public class ConfigurationController : Controller
    {
        private readonly IMerchantConfigurationService _configurationService;
        private readonly ILog _log;

        public ConfigurationController(
            [NotNull] IMerchantConfigurationService configurationService,
            [NotNull] ILogFactory logFactory)
        {
            _configurationService = configurationService;
            _log = logFactory.CreateLog(this);
        }

        /// <summary>
        /// Get validation algorithms configuration for merchant
        /// </summary>
        /// <param name="merchantId">Merchant id</param>
        /// <response code="200">Merchant validation algorithms configuration</response>
        [HttpGet]
        [Route("{merchantId}")]
        [SwaggerOperation("GetMerchantConfiguration")]
        [ProducesResponseType(typeof(ConfigurationModel), (int) HttpStatusCode.OK)]
        public async Task<IActionResult> Get(string merchantId)
        {
            merchantId = Uri.UnescapeDataString(merchantId);

            IReadOnlyList<IMerchantConfigurationLine> cfg = await _configurationService.GetByMerchantAsync(merchantId);

            return Ok(new ConfigurationModel
            {
                Algorithms = Mapper.Map<IReadOnlyList<LineModel>>(cfg)
            });
        }

        /// <summary>
        /// Add new validation algorithm to merchant configuration
        /// </summary>
        /// <param name="model">Add validation algorithm details</param>
        /// <response code="200">Validation algorithm has been successfully added</response>
        /// <response code="400">Validation algorithm already added or algorithm input is invalid</response>
        /// <response code="404">Validation algorithm not found</response>
        [HttpPost]
        [SwaggerOperation("AddMerchantConfiguration")]
        [ValidateModel]
        [ProducesResponseType(typeof(ErrorResponse), (int) HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(LineModel), (int) HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ErrorResponse), (int) HttpStatusCode.NotFound)]
        public async Task<IActionResult> Add([FromBody] AddLineModel model)
        {
            try
            {
                IMerchantConfigurationLine cfgLine =
                    await _configurationService.AddAsync(Mapper.Map<MerchantConfigurationLine>(model));

                return Ok(Mapper.Map<LineModel>(cfgLine));
            }
            catch (EntityAlreadyExistsException e)
            {
                _log.Error(e, $"PartitionKey = {e.PartitionKey}, RowKey = {e.RowKey}");

                return BadRequest(ErrorResponse.Create(e.Message));
            }
            catch (InvalidInputException e)
            {
                _log.Error(e, model.ToDetails());

                return BadRequest(e.ToErrorResponse());
            }
            catch (ValidationAlgorithmNotFoundException e)
            {
                _log.Error(e, model.ToDetails());

                return NotFound(ErrorResponse.Create($"Algorithm with id {model.AlgorithmId} not found"));
            }
        }

        /// <summary>
        /// Deletes validation algorithm from merchant's configuration
        /// </summary>
        /// <param name="merchantId">Merchant id</param>
        /// <param name="algorithmId">Algorithm id</param>
        /// <response code="404">Validation algorithm not found</response>
        /// <response code="200">Validation algorithm has been successfully deleted</response>
        [HttpDelete]
        [Route("{merchantId}/{algorithmId}")]
        [SwaggerOperation("DeleteMerchantConfiguration")]
        [ProducesResponseType(typeof(void), (int) HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(void), (int) HttpStatusCode.OK)]
        public async Task<IActionResult> Delete(string merchantId, string algorithmId)
        {
            merchantId = Uri.UnescapeDataString(merchantId);
            algorithmId = Uri.UnescapeDataString(algorithmId);

            try
            {
                await _configurationService.DeleteAsync(merchantId, algorithmId);

                return Ok();
            }
            catch (EntityNotFoundException e)
            {
                _log.Error(e, $"PartitionKey = {e.PartitionKey}, RowKey = {e.RowKey}");

                return NotFound();
            }
        }

        /// <summary>
        /// Enables validation algorithm in merchant's configuration
        /// </summary>
        /// <param name="merchantId">Merchant id</param>
        /// <param name="algorithmId">Algorithm id</param>
        /// <response code="404">Validation algorithm not found</response>
        /// <response code="200">Validation algorithm has been successfully enabled</response>
        [HttpPut]
        [Route("{merchantId}/{algorithmId}/enable")]
        [SwaggerOperation("EnableMerchantConfiguration")]
        [ProducesResponseType(typeof(void), (int) HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(void), (int) HttpStatusCode.OK)]
        public async Task<IActionResult> Enable(string merchantId, string algorithmId)
        {
            merchantId = Uri.UnescapeDataString(merchantId);
            algorithmId = Uri.UnescapeDataString(algorithmId);

            try
            {
                await _configurationService.EnableAsync(merchantId, algorithmId);

                return Ok();
            }
            catch (EntityNotFoundException e)
            {
                _log.Error(e, $"PartitionKey = {e.PartitionKey}, RowKey = {e.RowKey}");

                return NotFound();
            }
        }

        /// <summary>
        /// Disables validation algorithm in merchant's configuration
        /// </summary>
        /// <param name="merchantId">Merchant id</param>
        /// <param name="algorithmId">Algorithm id</param>
        /// <response code="404">Validation algorithm not found</response>
        /// <response code="200">Validation algorithm has been successfully disabled</response>
        [HttpPut]
        [Route("{merchantId}/{algorithmId}/disable")]
        [SwaggerOperation("DisableMerchantConfiguration")]
        [ProducesResponseType(typeof(void), (int) HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(void), (int) HttpStatusCode.OK)]
        public async Task<IActionResult> Disable(string merchantId, string algorithmId)
        {
            merchantId = Uri.UnescapeDataString(merchantId);
            algorithmId = Uri.UnescapeDataString(algorithmId);

            try
            {
                await _configurationService.DisableAsync(merchantId, algorithmId);

                return Ok();
            }
            catch (EntityNotFoundException e)
            {
                _log.Error(e, $"PartitionKey = {e.PartitionKey}, RowKey = {e.RowKey}");

                return NotFound();
            }
        }

        /// <summary>
        /// Updates validation algorithm input
        /// </summary>
        /// <param name="model">Validation algorithm input details</param>
        /// <response code="404">Validation algorithm or merchant configuration not found</response>
        /// <response code="200">Validation algorithm input has been successfully updated</response>
        [HttpPut]
        [SwaggerOperation("SetAlgorithmInput")]
        [ProducesResponseType(typeof(ErrorResponse), (int) HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(void), (int) HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ErrorResponse), (int) HttpStatusCode.BadRequest)]
        [ValidateModel]
        public async Task<IActionResult> SetInput([FromBody] UpdateInputModel model)
        {
            try
            {
                await _configurationService.UpdateAlgorithmInputAsync(
                    model.MerchantId,
                    model.AlgorithmId,
                    model.AlgorithmInput.ToString());

                return Ok();
            }
            catch (EntityNotFoundException e)
            {
                _log.Error(e, $"PartitionKey = {e.PartitionKey}, RowKey = {e.RowKey}");

                return NotFound(ErrorResponse.Create($"Configuration not found for algorithm {model.AlgorithmId}"));
            }
            catch (ValidationAlgorithmNotFoundException e)
            {
                _log.Error(e, model.ToDetails());

                return NotFound(ErrorResponse.Create($"Algorithm with id {model.AlgorithmId} not found"));
            }
            catch (InvalidInputException e)
            {
                _log.Error(e, model.ToDetails());

                return BadRequest(e.ToErrorResponse());
            }
        }
    }
}
