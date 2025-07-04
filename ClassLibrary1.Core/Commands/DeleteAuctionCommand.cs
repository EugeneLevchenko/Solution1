using MediatR;

namespace ClassLibrary1.Core.Commands
{
    public class DeleteAuctionCommand : IRequest<bool>
    {
        public int Id { get; set; }
    }
}
