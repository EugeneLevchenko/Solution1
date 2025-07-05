using AutoMapper;
using ClassLibrary1.Core.DTO;
using ClassLibrary1.Domain.Entities;

namespace ClassLibrary1.Core.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Source, Source>();
            CreateMap<Auction, Auction>();
            CreateMap<Lot, Lot>()
                .ForMember(dest => dest.SourceId, opt => opt.MapFrom(src => src.Auction.SourceId));
        }
    }
}
