using Microsoft.AspNetCore.Mvc;
using NBC_CMS.Requests;
using NBC_CMS.Services;

namespace NBC_CMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClaimCorrectionsController : ControllerBase
    {
        private readonly ClaimCorrectionService _claimCorrectionService;

        public ClaimCorrectionsController(
            ClaimCorrectionService claimCorrectionService)
        {
            _claimCorrectionService = claimCorrectionService;
        }

        // GET: api/ClaimCorrections
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var corrections =
                await _claimCorrectionService.GetAllAsync();

            return Ok(corrections);
        }

        // GET: api/ClaimCorrections/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var correction =
                await _claimCorrectionService.GetByIdAsync(id);

            if (correction == null)
            {
                return NotFound("Claim correction not found.");
            }

            return Ok(correction);
        }

        // GET: api/ClaimCorrections/claim/5
        [HttpGet("claim/{claimId}")]
        public async Task<IActionResult> GetByClaimId(int claimId)
        {
            var corrections =
                await _claimCorrectionService.GetByClaimIdAsync(claimId);

            return Ok(corrections);
        }

        // POST: api/ClaimCorrections
        [HttpPost]
        public async Task<IActionResult> Create(
            ClaimCorrectionRequest request)
        {
            var correction =
                await _claimCorrectionService.CreateAsync(request);

            return CreatedAtAction(
                nameof(GetById),
                new { id = correction.correctionID },
                correction
            );
        }

        // PUT: api/ClaimCorrections/5/corrected
        [HttpPut("{id}/corrected")]
        public async Task<IActionResult> MarkCorrected(int id)
        {
            var corrected =
                await _claimCorrectionService.MarkCorrectedAsync(id);

            if (!corrected)
            {
                return NotFound("Claim correction not found.");
            }

            return NoContent();
        }
    }
}