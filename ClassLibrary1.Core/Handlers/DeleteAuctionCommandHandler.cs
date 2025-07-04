using ClassLibrary1.Core.Commands;
using ClassLibrary1.Domain.Data;
using ClassLibrary1.Domain.Entities;
using ClassLibrary1.Domain.Interfaces;
using MediatR;

namespace ClassLibrary1.Core.Handlers
{
    public class DeleteAuctionCommandHandler : IRequestHandler<DeleteAuctionCommand, bool>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly AuctionDbContext _context;

        public DeleteAuctionCommandHandler(IUnitOfWork unitOfWork, AuctionDbContext context)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<bool> Handle(DeleteAuctionCommand request, CancellationToken cancellationToken)
        {
            var auction = await _unitOfWork.Auctions.GetByIdAsync(request.Id);
            if (auction == null) return false;

            var deletedAuctionData = new DeletedAuctionData
            {
                OriginalId = auction.Id,
                Name = auction.Name,
                SourceId = auction.SourceId,
                DeletedAt = DateTime.UtcNow
            };
            _unitOfWork.Auctions.Remove(auction);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }
    }
}
