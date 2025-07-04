using ClassLibrary1.Core.Commands;
using ClassLibrary1.Domain.Data;
using ClassLibrary1.Domain.Entities;
using ClassLibrary1.Domain.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.Core.Handlers
{
    public class RecoverAuctionCommandHandler : IRequestHandler<RecoverAuctionCommand, bool>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly AuctionDbContext _context;

        public RecoverAuctionCommandHandler(IUnitOfWork unitOfWork, AuctionDbContext context)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<bool> Handle(RecoverAuctionCommand request, CancellationToken cancellationToken)
        {
            //Поиск данных удаленного аукциона
            //var deletedAuction = await _context.DeletedAuctionData
            //    .FirstOrDefaultAsync(d => d.OriginalId == request.Id && !d.IsRecovered);
            //if (deletedAuction == null) return false;

            //// Создание новой записи аукциона
            //var newAuction = new Auction
            //{
            //    Name = deletedAuction.Name,
            //    SourceId = deletedAuction.SourceId,
            //    CreatedDate = DateTime.UtcNow // Установите дату создания
            //};
            //await _unitOfWork.Auctions.AddAsync(newAuction);
            //await _unitOfWork.SaveChangesAsync();

            //// Отметка данных как восстановленных
            //deletedAuction.IsRecovered = true;
            //await _context.SaveChangesAsync();

            return true;
        }
    }

    // Расширение DeletedAuctionData
    //public class DeletedAuctionData
    //{
    //    public int Id { get; set; }
    //    public int OriginalId { get; set; }
    //    public string Name { get; set; }
    //    public int SourceId { get; set; }
    //    public DateTime DeletedAt { get; set; }
    //    public bool IsRecovered { get; set; } // Флаг для отслеживания восстановления
    //}
}
