using ClassLibrary1.Domain.Interfaces;
using MediatR;

namespace ClassLibrary1.Core.Commands
{
    public class UpdateSourceTitleCommandHandler : IRequestHandler<UpdateSourceTitleCommand, bool>
    {
        private readonly IUnitOfWork _unitOfWork;
        public UpdateSourceTitleCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(UpdateSourceTitleCommand request, CancellationToken cancellationToken)
        {
            var updatedRows = await _unitOfWork.Sources.UpdateTitleByIdAsync(request.Id, request.NewTitle, cancellationToken);
            return updatedRows > 0;
        }
    }
}
