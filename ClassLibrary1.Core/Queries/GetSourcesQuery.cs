using ClassLibrary1.Core.DTO;
using MediatR;

namespace ClassLibrary1.Core.Queries
{
    public class GetSourcesQuery : IRequest<List<SourceDTO>> { }
}
