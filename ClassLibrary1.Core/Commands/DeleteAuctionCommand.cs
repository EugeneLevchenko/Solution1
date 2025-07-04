using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.Core.Commands
{
    public class DeleteAuctionCommand : IRequest<bool>
    {
        public int Id { get; set; }
    }
}
