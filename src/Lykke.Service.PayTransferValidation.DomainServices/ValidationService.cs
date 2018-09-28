using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using JetBrains.Annotations;
using Lykke.Service.PayTransferValidation.Domain;
using Lykke.Service.PayTransferValidation.Domain.Exceptions;
using Lykke.Service.PayTransferValidation.Domain.Repositories;
using Lykke.Service.PayTransferValidation.Domain.Services;

namespace Lykke.Service.PayTransferValidation.DomainServices
{
    public class ValidationService : IValidationService
    {
        private readonly IMerchantConfigurationService _configurationService;
        private readonly IComponentContext _componentContext;

        public ValidationService(
            [NotNull] IMerchantConfigurationService configurationService, 
            [NotNull] IComponentContext componentContext)
        {
            _configurationService = configurationService;
            _componentContext = componentContext;
        }

        public async Task<ValidationResult> ValidateAsync(ValidationContext ctx)
        {
            IReadOnlyList<IMerchantConfigurationLine> configuration =
                await _configurationService.GetByMerchantAsync(ctx.MerchantId);

            var validationTasks = configuration.Where(x => x.Enabled ?? false).Select(x =>
            {
                var algorithm = _componentContext.ResolveNamed<IValidationAlgorithm>(x.AlgorithmId);

                if (algorithm == null)
                    throw new ValidationAlgorithmNotFoundException(x.AlgorithmId);

                return algorithm.ExecuteAsync(ctx, x.AlgorithmInput);
            });

            return new ValidationResult
            {
                Results = await Task.WhenAll(validationTasks)
            };
        }
    }
}
