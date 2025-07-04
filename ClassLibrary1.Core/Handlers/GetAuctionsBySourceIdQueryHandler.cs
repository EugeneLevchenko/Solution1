using AutoMapper;
using ClassLibrary1.Core.DTO;
using ClassLibrary1.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication1.Pages.Sources;

namespace ClassLibrary1.Core.Handlers
{
    public class GetAuctionsBySourceIdQueryHandler : IRequestHandler<GetAuctionsBySourceIdQuery, List<AuctionDTO>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetAuctionsBySourceIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<List<AuctionDTO>> Handle(GetAuctionsBySourceIdQuery request, CancellationToken cancellationToken)
        {
            var auctions = await _unitOfWork.Auctions.GetAllBySourceIdAsync(request.SourceId);
            return _mapper.Map<List<AuctionDTO>>(auctions);
        }
    }
}
