using Alpaca.Markets;
using AutoMapper;
using OziTrading.Integrations.Models;

namespace OziTrading.Integrations.Infrastructure
{
    public class IntegrationMapperProfile : Profile
    {
        public IntegrationMapperProfile()
        {
            CreateMap<IAccount, AlpacaAccountModel>()
                .ForMember(a => a.Status, opt => opt.MapFrom(src => src.Status.ToString()));

            CreateMap<IAsset, AlpacaAssestModel>()
                .ForMember(a => a.Class, opt => opt.MapFrom(src => src.Class.ToString()))
                .ForMember(a => a.Status, opt => opt.MapFrom(src => src.Status.ToString()))
                .ForMember(a => a.Exchange, opt => opt.MapFrom(src => src.Exchange.ToString()));
        }
    }
}
