using MediatR;

namespace ClassLibrary1.Core.Commands
{
    public class RecoverAuctionCommand : IRequest<bool>
    {
        public int Id { get; set; }
    }
}
