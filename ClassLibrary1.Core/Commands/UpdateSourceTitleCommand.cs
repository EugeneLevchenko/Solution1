using MediatR;

namespace ClassLibrary1.Core.Commands
{
    public class UpdateSourceTitleCommand : IRequest<bool>
    {
        public int Id { get; set; }
        public string NewTitle { get; set; }
    }
}
