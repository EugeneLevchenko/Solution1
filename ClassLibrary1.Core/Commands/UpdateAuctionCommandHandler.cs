using ClassLibrary1.Domain.Interfaces;
using MediatR;

namespace ClassLibrary1.Core.Commands
{
    public class UpdateAuctionCommandHandler : IRequestHandler<UpdateAuctionCommand, bool>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateAuctionCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(UpdateAuctionCommand request, CancellationToken cancellationToken)
        {
            var updatedRows = await _unitOfWork.Auctions.UpdateNameBySourceIdAsync(request.SourceId, request.Name, cancellationToken);
            return updatedRows > 0;
        }
    }
}
