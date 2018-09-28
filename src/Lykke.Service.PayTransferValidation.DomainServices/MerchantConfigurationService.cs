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
            var algorithm = _componentContext.ResolveNamed<IValidationAlgorithm>(src.AlgorithmId);

            if (algorithm == null)
                throw new ValidationAlgorithmNotFoundException(src.AlgorithmId);

            if (!string.IsNullOrEmpty(src.AlgorithmInput))
            {
                IEnumerable<ValidationResult> validationErrors = algorithm.ValidateInput(src.AlgorithmInput).ToList();

                if (validationErrors.Any())
                    throw new InvalidInputException(src.AlgorithmId, validationErrors);
            }

            return await _repository.AddAsync(src);
        }

        public async Task<IMerchantConfigurationLine> GetAsync(string merchantId, string algorithmId)
        {
            return await _repository.GetAsync(merchantId, algorithmId);
        }

        public async Task<IReadOnlyList<IMerchantConfigurationLine>> GetByMerchantAsync(string merchantId)
        {
            return await _repository.GetByMerchantAsync(merchantId);
        }

        public async Task EnableAsync(string merchantId, string algorithmId)
        {
            await _repository.UpdateAsync(new MerchantConfigurationLine
                {MerchantId = merchantId, AlgorithmId = algorithmId, Enabled = true});
        }

        public async Task DisableAsync(string merchantId, string algorithmId)
        {
            await _repository.UpdateAsync(new MerchantConfigurationLine
                { MerchantId = merchantId, AlgorithmId = algorithmId, Enabled = false });
        }

        public async Task UpdateAlgorithmInputAsync(string merchantId, string algorithmId, string algorithmInput)
        {
            var algorithm =_componentContext.ResolveNamed<IValidationAlgorithm>(algorithmId);

            if (algorithm == null)
                throw new ValidationAlgorithmNotFoundException(algorithmId);

            IEnumerable<ValidationResult> validationErrors = algorithm.ValidateInput(algorithmInput).ToList();

            if (validationErrors.Any())
                throw new InvalidInputException(algorithmId, validationErrors);

            await _repository.UpdateAsync(new MerchantConfigurationLine
            {
                MerchantId = merchantId, AlgorithmId = algorithmId,
                AlgorithmInput = JsonConvert.SerializeObject(JObject.Parse(algorithmInput), Formatting.Indented)
            });
        }

        public async Task DeleteAsync(string merchantId, string algorithmId)
        {
            await _repository.DeleteAsync(merchantId, algorithmId);
        }
    }
}
