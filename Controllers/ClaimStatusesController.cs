using Microsoft.AspNetCore.Mvc;
using NBC_CMS.Requests;
using NBC_CMS.Services;

namespace NBC_CMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClaimStatusesController : ControllerBase
    {
        private readonly ClaimStatusService _claimStatusService;

        public ClaimStatusesController(ClaimStatusService claimStatusService)
        {
            _claimStatusService = claimStatusService;
        }

        // GET: api/ClaimStatuses
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var statuses = await _claimStatusService.GetAllAsync();

            return Ok(statuses);
        }

        // GET: api/ClaimStatuses/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var status = await _claimStatusService.GetByIdAsync(id);

            if (status == null)
            {
                return NotFound("Claim status not found.");
            }

            return Ok(status);
        }

        // POST: api/ClaimStatuses
        [HttpPost]
        public async Task<IActionResult> Create(ClaimStatusRequest request)
        {
            var status = await _claimStatusService.CreateAsync(request);

            return CreatedAtAction(
                nameof(GetById),
                new { id = status.statusID },
                status
            );
        }

        // PUT: api/ClaimStatuses/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(
            int id,
            ClaimStatusRequest request)
        {
            var updated = await _claimStatusService.UpdateAsync(id, request);

            if (!updated)
            {
                return NotFound("Claim status not found.");
            }

            return NoContent();
        }

        // DELETE: api/ClaimStatuses/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _claimStatusService.DeleteAsync(id);

            if (!deleted)
            {
                return NotFound("Claim status not found.");
            }

            return NoContent();
        }
    }
}