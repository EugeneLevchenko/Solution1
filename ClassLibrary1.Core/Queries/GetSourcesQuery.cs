using ClassLibrary1.Core.DTO;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.Core.Queries
{
    public class GetSourcesQuery : IRequest<List<SourceDTO>> { }
}
