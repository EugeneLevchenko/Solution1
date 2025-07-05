using AutoMapper;
using ClassLibrary1.Core.DTO;
using ClassLibrary1.Domain.Interfaces;
using MediatR;
using WebApplication1.Pages.Sources;

namespace ClassLibrary1.Core.Queries
{
    public class GetAuctionsBySourceIdQueryHandler : IRequestHandler<GetAuctionsBySourceIdQuery, List<Auction>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetAuctionsBySourceIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<List<Auction>> Handle(GetAuctionsBySourceIdQuery request, CancellationToken cancellationToken)
        {
            var auctions = await _unitOfWork.Auctions.GetAllBySourceIdAsync(request.SourceId);
            return _mapper.Map<List<Auction>>(auctions);
        }
    }
}
