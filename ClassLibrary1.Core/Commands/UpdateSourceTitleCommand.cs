using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace ClassLibrary1.Core.Commands
{
    public class UpdateSourceTitleCommand : IRequest
    {
        public int Id { get; set; }
        public string NewTitle { get; set; }
    }
}
