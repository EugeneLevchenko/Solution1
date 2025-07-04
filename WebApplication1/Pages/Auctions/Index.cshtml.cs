using ClassLibrary1.Domain.Data;
using ClassLibrary1.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

namespace WebApplication1.Pages.Auctions
{

    public class IndexModel : PageModel
    {
        private readonly AuctionDbContext _context;
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(AuctionDbContext context, ILogger<IndexModel> logger)
        {
            _context = context;
            _logger = logger;
        }

        [BindProperty]
        public List<Auction> Auctions { get; set; }

        public async Task OnGetAsync()
        {
            Auctions = await _context.Auctions.ToListAsync();
        }

        public async Task<IActionResult> OnPostUpdateAsync([FromBody] Auction auction)
        {
            _logger.LogDebug("Update request received for ID: {Id}, Name: {Name}, SourceId: {SourceId}", auction.Id, auction.Name, auction.SourceId);
            if (!ModelState.IsValid)
            {
                _logger.LogWarning("ModelState is invalid: {ModelState}", ModelState);
                return new BadRequestObjectResult(ModelState);
            }

            var existingAuction = await _context.Auctions.FindAsync(auction.Id);
            if (existingAuction == null)
            {
                _logger.LogWarning("Auction with ID {Id} not found", auction.Id);
                return NotFound();
            }

            existingAuction.Name = auction.Name;
            try
            {
                await _context.SaveChangesAsync();
                _logger.LogInformation("Auction with ID {Id} updated successfully", auction.Id);
                var updatedAuction = await _context.Auctions.FindAsync(auction.Id);
                return new OkObjectResult(new { id = updatedAuction.Id, name = updatedAuction.Name, status = updatedAuction.Status });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error saving changes for ID {Id}", auction.Id);
                return new BadRequestObjectResult("Error saving changes");
            }
        }

        public async Task<IActionResult> OnPostDeleteAsync([FromBody] JsonElement body)
        {
            _logger.LogDebug("Delete request received for body: {Body}", body.GetRawText());
            int id;
            try
            {
                id = body.GetProperty("Id").GetInt32();
            }
            catch (KeyNotFoundException)
            {
                _logger.LogWarning("Id property not found in request body");
                return BadRequest("Id is required");
            }
            catch (InvalidOperationException)
            {
                _logger.LogWarning("Id is not a valid integer");
                return BadRequest("Id must be a valid integer");
            }

            _logger.LogDebug("Delete request processed for ID: {Id}", id);
            var auction = await _context.Auctions.FindAsync(id);
            Console.WriteLine($"Id: {id}");
            Console.WriteLine("auction = " + auction);
            if (auction == null)
            {
                _logger.LogWarning("Auction with ID {Id} not found", id);
                return NotFound();
            }

            auction.Status = Status.Deleted;
            try
            {
                await _context.SaveChangesAsync();
                _logger.LogInformation("Auction with ID {Id} status changed to Deleted", id);
                var updatedAuction = await _context.Auctions.FindAsync(id);
                return new OkObjectResult(new { id = updatedAuction.Id, name = updatedAuction.Name, status = updatedAuction.Status });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error saving status change for ID {Id}", id);
                return new BadRequestObjectResult("Error saving status");
            }
        }

        public async Task<IActionResult> OnPostRecoverAsync([FromBody] JsonElement body)
        {
            _logger.LogDebug("Recover request received for body: {Body}", body.GetRawText());
            int id;
            try
            {
                id = body.GetProperty("Id").GetInt32();
            }
            catch (KeyNotFoundException)
            {
                _logger.LogWarning("Id property not found in request body");
                return BadRequest("Id is required");
            }
            catch (InvalidOperationException)
            {
                _logger.LogWarning("Id is not a valid integer");
                return BadRequest("Id must be a valid integer");
            }

            _logger.LogDebug("Recover request processed for ID: {Id}", id);
            var auction = await _context.Auctions.FindAsync(id);
            if (auction == null)
            {
                _logger.LogWarning("Auction with ID {Id} not found", id);
                return NotFound();
            }

            auction.Status = Status.Pending;
            try
            {
                await _context.SaveChangesAsync();
                _logger.LogInformation("Auction with ID {Id} status changed to Pending", id);
                var updatedAuction = await _context.Auctions.FindAsync(id);
                return new OkObjectResult(new { id = updatedAuction.Id, name = updatedAuction.Name, status = updatedAuction.Status });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error saving status change for ID {Id}", id);
                return new BadRequestObjectResult("Error saving status");
            }
        }
    }
}