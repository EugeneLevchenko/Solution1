using AutoMapper;
using ClassLibrary1.Core.DTO;
using ClassLibrary1.Domain.Interfaces;
using MediatR;

namespace ClassLibrary1.Core.Queries
{
    public class GetSourcesQueryHandler : IRequestHandler<GetSourcesQuery, List<Source>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetSourcesQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<List<Source>> Handle(GetSourcesQuery request, CancellationToken cancellationToken)
        {
            var sources = await _unitOfWork.Sources.GetAllAsync();
            return _mapper.Map<List<Source>>(sources);
        }
    }
}
