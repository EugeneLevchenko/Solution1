using ClassLibrary1.Core.Commands;
using ClassLibrary1.Core.DTO;
using ClassLibrary1.Core.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ClassLibrary1.Core.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SourcesController : ControllerBase
    {
        private readonly IMediator _mediator;
        public SourcesController(IMediator mediator) => _mediator = mediator;

        [HttpGet]
        public async Task<ActionResult<List<Source>>> GetSources()
        {
            var sources = await _mediator.Send(new GetSourcesQuery());
            return Ok(sources);
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> UpdateTitle(int id, [FromBody] UpdateSourceTitleCommand command)
        {
            if (id != command.Id) return BadRequest();
            await _mediator.Send(command);
            return NoContent();
        }
    }
}
