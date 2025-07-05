using ClassLibrary1.Core.DTO;
using ClassLibrary1.Core.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApplication1.Pages.Sources
{
    public class IndexModel : PageModel
    {
        private readonly IMediator _mediator;
        public List<Source> Sources { get; set; }
        public List<Auction> Auctions { get; set; }
        public IndexModel(IMediator mediator) => _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        public async Task OnGetAsync()
        {
            try
            {
                Sources = await _mediator.Send(new GetSourcesQuery()) ?? new List<Source>();
                var allAuctions = new List<Auction>();
                foreach (var source in Sources)
                {
                    var query = new GetAuctionsBySourceIdQuery { SourceId = source.Id };
                    var auctions = await _mediator.Send(query) ?? new List<Auction>();
                    allAuctions.AddRange(auctions);
                }
                Auctions = allAuctions;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading data: {ex.Message}");
                Sources = new List<Source>();
                Auctions = new List<Auction>();
            }
        }
    }
}
