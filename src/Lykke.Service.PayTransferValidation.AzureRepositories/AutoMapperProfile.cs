using AutoMapper;
using Lykke.Service.PayTransferValidation.Domain.Repositories;

namespace Lykke.Service.PayTransferValidation.AzureRepositories
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<IMerchantConfigurationLine, MerchantConfigurationLineEntity>(MemberList.Source);
            CreateMap<MerchantConfigurationLineEntity, MerchantConfigurationLine>(MemberList.Destination);
        }
    }
}
