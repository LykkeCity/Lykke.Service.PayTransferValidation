using System.Linq;
using AutoMapper;
using Lykke.Service.PayTransferValidation.Domain;
using Lykke.Service.PayTransferValidation.Domain.Repositories;
using Lykke.Service.PayTransferValidation.DomainServices;
using Lykke.Service.PayTransferValidation.Models.MerchantConfiguration;
using Lykke.Service.PayTransferValidation.Models.Rule;
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
                .ForMember(dest => dest.RuleDisplayName,
                    opt => opt.ResolveUsing(src =>
                        typeof(ValidationRule).Assembly.GetTypes()
                            .SingleOrDefault(x =>
                                x.IsSubclassOf(typeof(ValidationRule)) &&
                                x.GetAttributeValue((RuleIdentityAttribute attr) => attr.Id) == src.RuleId)
                            ?.GetAttributeValue((RuleIdentityAttribute attr) => attr.DisplayName) ??
                        string.Empty));

            CreateMap<AddLineModel, MerchantConfigurationLine>(MemberList.Destination)
                .ForMember(dest => dest.Enabled, opt => opt.UseValue(true))
                .ForMember(dest => dest.RuleInput, opt => opt.MapFrom(src => src.RuleInput.ToString()));

            CreateMap<ValidationContextModel, ValidationContext>(MemberList.Destination);

            CreateMap<RuleValidationResult, RuleValidationResultModel>(MemberList.Destination)
                .ForMember(dest => dest.Rule, opt => opt.MapFrom(src => src.DisplayName));

            CreateMap<ValidationResult, ValidationResultModel>(MemberList.Destination);

            CreateMap<RegisteredValidationRule, RegisteredRuleModel>(MemberList.Destination);
        }
    }
}
