using ClassLibrary1.Core.Commands;
using ClassLibrary1.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.Core.Handlers
{
    public class UpdateAuctionCommandHandler : IRequestHandler<UpdateAuctionCommand, bool>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateAuctionCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        public async Task<bool> Handle(UpdateAuctionCommand request, CancellationToken cancellationToken)
        {
            var auction = await _unitOfWork.Auctions.GetByIdAsync(request.Id);
            if (auction == null) return false;

            auction.Name = request.Name;
            await _unitOfWork.SaveChangesAsync();
            return true;
        }
    }
}
