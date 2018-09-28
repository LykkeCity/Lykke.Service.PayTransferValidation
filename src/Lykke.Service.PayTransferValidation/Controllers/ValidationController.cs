using System.Net;
using System.Threading.Tasks;
using AutoMapper;
using Common.Log;
using JetBrains.Annotations;
using Lykke.Common.Api.Contract.Responses;
using Lykke.Common.Log;
using Lykke.Service.PayTransferValidation.Domain;
using Lykke.Service.PayTransferValidation.Domain.Exceptions;
using Lykke.Service.PayTransferValidation.Domain.Services;
using Lykke.Service.PayTransferValidation.Models.Validation;
using LykkePay.Common.Validation;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.SwaggerGen;
using ValidationContext = Lykke.Service.PayTransferValidation.Domain.ValidationContext;

namespace Lykke.Service.PayTransferValidation.Controllers
{
    [Route("api/validation")]
    public class ValidationController : Controller
    {
        private readonly IValidationService _validationService;
        private readonly ILog _log;

        public ValidationController(
            [NotNull] IValidationService validationService,
            [NotNull] ILogFactory logFactory)
        {
            _validationService = validationService;
            _log = logFactory.CreateLog(this);
        }

        /// <summary>
        /// Validates transfer against merchant configuration algorithms
        /// </summary>
        /// <param name="model">Validation context</param>
        /// <response code="200">Validation executed</response>
        /// <response code="404">Validation algorithm not found</response>
        [HttpGet]
        [SwaggerOperation("Validate")]
        [ProducesResponseType(typeof(ValidationResultModel), (int) HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ErrorResponse), (int) HttpStatusCode.NotFound)]
        [ValidateModel]
        public async Task<IActionResult> Validate([FromQuery] ValidationContextModel model)
        {
            try
            {
                ValidationResult result = await _validationService.ValidateAsync(Mapper.Map<ValidationContext>(model));

                return Ok(Mapper.Map<ValidationResultModel>(result));
            }
            catch (ValidationAlgorithmNotFoundException e)
            {
                _log.Error(e, e.Message, e.AlgorithmId);

                return NotFound(ErrorResponse.Create(e.Message));
            }
        }
    }
}
