using System.Linq;
using AutoMapper;
using Lykke.Service.PayTransferValidation.Domain;
using Lykke.Service.PayTransferValidation.Domain.Repositories;
using Lykke.Service.PayTransferValidation.DomainServices;
using Lykke.Service.PayTransferValidation.Models.MerchantConfiguration;
using Lykke.Service.PayTransferValidation.Models.Validation;
using ValidationContext = Lykke.Service.PayTransferValidation.Domain.ValidationContext;

namespace Lykke.Service.PayTransferValidation
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<IMerchantConfigurationLine, LineModel>(MemberList.Destination)
                .ForMember(dest => dest.Enabled, opt => opt.ResolveUsing(src => src.Enabled ?? false))
                .ForMember(dest => dest.AlgorithmDisplayName,
                    opt => opt.ResolveUsing(src =>
                        typeof(ValidationAlgorithm).Assembly.GetTypes()
                            .SingleOrDefault(x =>
                                x.IsSubclassOf(typeof(ValidationAlgorithm)) &&
                                x.GetAttributeValue((AlgorithmIdentityAttribute attr) => attr.Id) == src.AlgorithmId)
                            ?.GetAttributeValue((AlgorithmIdentityAttribute attr) => attr.DisplayName) ??
                        string.Empty));

            CreateMap<AddLineModel, MerchantConfigurationLine>(MemberList.Destination)
                .ForMember(dest => dest.Enabled, opt => opt.UseValue(true));

            CreateMap<ValidationContextModel, ValidationContext>(MemberList.Destination);

            CreateMap<AlgorithmValidationResult, AlgorithmValidationResultModel>(MemberList.Destination)
                .ForMember(dest => dest.Rule, opt => opt.MapFrom(src => src.DisplayName));

            CreateMap<ValidationResult, ValidationResultModel>(MemberList.Destination);
        }
    }
}
