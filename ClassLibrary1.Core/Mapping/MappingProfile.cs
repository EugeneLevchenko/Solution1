using AutoMapper;
using ClassLibrary1.Core.DTO;
using ClassLibrary1.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.Core.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Source, SourceDTO>();
            CreateMap<Auction, AuctionDTO>();
            CreateMap<Lot, LotDTO>()
                .ForMember(dest => dest.SourceId, opt => opt.MapFrom(src => src.Auction.SourceId));
        }
    }
}
