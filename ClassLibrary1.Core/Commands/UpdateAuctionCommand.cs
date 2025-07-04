using MediatR;

namespace ClassLibrary1.Core.Commands
{
    public class UpdateAuctionCommand : IRequest<bool>
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
