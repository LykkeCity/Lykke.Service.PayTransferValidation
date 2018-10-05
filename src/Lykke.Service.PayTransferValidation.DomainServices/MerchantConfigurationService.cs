using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using JetBrains.Annotations;
using Lykke.Service.PayTransferValidation.Domain.Exceptions;
using Lykke.Service.PayTransferValidation.Domain.Repositories;
using Lykke.Service.PayTransferValidation.Domain.Services;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Lykke.Service.PayTransferValidation.DomainServices
{
    public class MerchantConfigurationService : IMerchantConfigurationService
    {
        private readonly IMerchantConfigurationRepository _repository;
        private readonly IComponentContext _componentContext;

        public MerchantConfigurationService(
            [NotNull] IMerchantConfigurationRepository repository, 
            [NotNull] IComponentContext componentContext)
        {
            _repository = repository;
            _componentContext = componentContext;
        }

        public async Task<IMerchantConfigurationLine> AddAsync(IMerchantConfigurationLine src)
        {
            var rule = _componentContext.ResolveNamed<IValidationRule>(src.RuleId);

            if (rule == null)
                throw new ValidationRuleNotFoundException(src.RuleId);

            if (!string.IsNullOrEmpty(src.RuleInput))
            {
                IEnumerable<ValidationResult> validationErrors = rule.ValidateInput(src.RuleInput).ToList();

                if (validationErrors.Any())
                    throw new InvalidInputException(src.RuleId, validationErrors);
            }

            return await _repository.AddAsync(src);
        }

        public async Task<IMerchantConfigurationLine> GetAsync(string merchantId, string ruleId)
        {
            return await _repository.GetAsync(merchantId, ruleId);
        }

        public async Task<IReadOnlyList<IMerchantConfigurationLine>> GetByMerchantAsync(string merchantId)
        {
            return await _repository.GetByMerchantAsync(merchantId);
        }

        public async Task EnableAsync(string merchantId, string ruleId)
        {
            await _repository.UpdateAsync(new MerchantConfigurationLine
                {MerchantId = merchantId, RuleId = ruleId, Enabled = true});
        }

        public async Task DisableAsync(string merchantId, string ruleId)
        {
            await _repository.UpdateAsync(new MerchantConfigurationLine
                { MerchantId = merchantId, RuleId = ruleId, Enabled = false });
        }

        public async Task UpdateRuleInputAsync(string merchantId, string ruleId, string ruleInput)
        {
            var rule =_componentContext.ResolveNamed<IValidationRule>(ruleId);

            if (rule == null)
                throw new ValidationRuleNotFoundException(ruleId);

            IEnumerable<ValidationResult> validationErrors = rule.ValidateInput(ruleInput).ToList();

            if (validationErrors.Any())
                throw new InvalidInputException(ruleId, validationErrors);

            await _repository.UpdateAsync(new MerchantConfigurationLine
            {
                MerchantId = merchantId, RuleId = ruleId,
                RuleInput = JsonConvert.SerializeObject(JObject.Parse(ruleInput), Formatting.Indented)
            });
        }

        public async Task DeleteAsync(string merchantId, string ruleId)
        {
            await _repository.DeleteAsync(merchantId, ruleId);
        }
    }
}
