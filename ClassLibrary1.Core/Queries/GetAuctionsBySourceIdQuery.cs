using ClassLibrary1.Core.DTO;
using MediatR;

namespace WebApplication1.Pages.Sources
{
    public class GetAuctionsBySourceIdQuery : IRequest<List<AuctionDTO>>
    {
        public int SourceId { get; set; }
    }
}