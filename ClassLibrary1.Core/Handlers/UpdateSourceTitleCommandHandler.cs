using ClassLibrary1.Core.Commands;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using ClassLibrary1.Domain.Interfaces;

namespace ClassLibrary1.Core.Handlers
{
    public class UpdateSourceTitleCommandHandler : IRequestHandler<UpdateSourceTitleCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        public UpdateSourceTitleCommandHandler(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;

        public async Task Handle(UpdateSourceTitleCommand request, CancellationToken cancellationToken)
        {
            var source = await _unitOfWork.Sources.GetByIdAsync(request.Id);
            if (source == null) throw new Exception("Source not found");
            source.Title = request.NewTitle;
            await _unitOfWork.Sources.UpdateAsync(source);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
