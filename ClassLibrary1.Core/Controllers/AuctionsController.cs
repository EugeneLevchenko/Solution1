using ClassLibrary1.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ClassLibrary1.Core.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuctionsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public AuctionsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok();
        }
    }
}

