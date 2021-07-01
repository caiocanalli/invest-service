using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Invest.Domain.Investments;

namespace Invest.Infra.Cache
{
    public class InvestmentCacheMapper : Profile
    {
        public InvestmentCacheMapper()
        {
            CreateMap<Investment, InvestmentCacheDto>().ReverseMap();
            CreateMap<IList<Investment>, RecoverInvestmentCacheDto>()
                .ForMember(dest => dest.Investments,
                    opt => opt.MapFrom(src => src))
                .ForMember(dest => dest.TotalValue,
                    opt => opt.MapFrom(src => src.Sum(investment => investment.TotalValue)));
        }
    }
}