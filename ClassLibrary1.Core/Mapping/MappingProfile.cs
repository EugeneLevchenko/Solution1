using AutoMapper;

namespace ClassLibrary1.Core.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Domain.Entities.Source, DTO.Source>();
            CreateMap<Domain.Entities.Auction, DTO.Auction>();
            CreateMap<Domain.Entities.Lot, DTO.Lot>()
                .ForMember(dest => dest.SourceId, opt => opt.MapFrom(src => src.Auction.SourceId));
        }
    }
}
