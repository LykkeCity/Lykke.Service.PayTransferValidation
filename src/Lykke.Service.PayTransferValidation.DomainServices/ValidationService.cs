using System;
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
                var rule = _componentContext.ResolveNamed<IValidationRule>(x.RuleId);

                if (rule == null)
                    throw new ValidationRuleNotFoundException(x.RuleId);

                return rule.ExecuteAsync(ctx, x.RuleInput);
            });

            return new ValidationResult
            {
                Results = await Task.WhenAll(validationTasks)
            };
        }

        public IReadOnlyList<RegisteredValidationRule> GetRegisteredRules()
        {
            IEnumerable<Type> ruleTypes = typeof(ValidationRule).Assembly.GetTypes()
                .Where(x => x.IsSubclassOf(typeof(ValidationRule)));

            return ruleTypes.Select(x => new RegisteredValidationRule
            {
                Id = x.GetAttributeValue((RuleIdentityAttribute attr) => attr.Id),
                DisplayName = x.GetAttributeValue((RuleIdentityAttribute attr) => attr.DisplayName)
            }).ToList();
        }
    }
}
