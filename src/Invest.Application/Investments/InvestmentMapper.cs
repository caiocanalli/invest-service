using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Invest.Domain.Investments;
using Invest.Infra.Cache;

namespace Invest.Application.Investments
{
    public class InvestmentMapper : Profile
    {
        public InvestmentMapper()
        {
            CreateMap<Investment, InvestmentDto>().ReverseMap();
            CreateMap<IList<Investment>, RecoverInvestmentDto>()
                .ForMember(dest => dest.Investments,
                    opt => opt.MapFrom(src => src))
                .ForMember(dest => dest.TotalValue, opt => opt.MapFrom(src => src.Sum(investment => investment.TotalValue)));

            CreateMap<InvestmentCacheDto, InvestmentDto>();
            CreateMap<RecoverInvestmentCacheDto, RecoverInvestmentDto>();
        }
    }
}