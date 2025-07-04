using AutoMapper;
using ClassLibrary1.Core.DTO;
using ClassLibrary1.Core.Queries;
using ClassLibrary1.Domain.Interfaces;
using MediatR;

namespace ClassLibrary1.Core.Handlers
{
    public class GetSourcesQueryHandler : IRequestHandler<GetSourcesQuery, List<SourceDTO>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetSourcesQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<List<SourceDTO>> Handle(GetSourcesQuery request, CancellationToken cancellationToken)
        {
            var sources = await _unitOfWork.Sources.GetAllAsync();
            return _mapper.Map<List<SourceDTO>>(sources);
        }
    }
}
