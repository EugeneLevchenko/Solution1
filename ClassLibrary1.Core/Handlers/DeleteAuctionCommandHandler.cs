using ClassLibrary1.Core.Commands;
using ClassLibrary1.Domain.Interfaces;
using MediatR;

namespace ClassLibrary1.Core.Handlers
{

    public class DeleteAuctionCommandHandler : IRequest<DeleteAuctionCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        public DeleteAuctionCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(DeleteAuctionCommand request, CancellationToken cancellationToken)
        {
            await _unitOfWork.Auctions.DeleteBySourceIdAsync(request.SourceId, request.Id, cancellationToken);
        }
    }
}
