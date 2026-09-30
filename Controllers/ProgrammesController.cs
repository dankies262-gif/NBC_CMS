using Microsoft.AspNetCore.Mvc;
using NBC_CMS.Requests;
using NBC_CMS.Services;

namespace NBC_CMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProgrammesController : ControllerBase
    {
        private readonly ProgrammeService _programmeService;

        public ProgrammesController(ProgrammeService programmeService)
        {
            _programmeService = programmeService;
        }

        // GET: api/Programmes
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var programmes = await _programmeService.GetAllAsync();

            return Ok(programmes);
        }

        // GET: api/Programmes/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var programme = await _programmeService.GetByIdAsync(id);

            if (programme == null)
            {
                return NotFound("Programme not found.");
            }

            return Ok(programme);
        }

        // POST: api/Programmes
        [HttpPost]
        public async Task<IActionResult> Create(ProgrammeRequest request)
        {
            var programme = await _programmeService.CreateAsync(request);

            return CreatedAtAction(
                nameof(GetById),
                new { id = programme.programmeID },
                programme
            );
        }

        // PUT: api/Programmes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, ProgrammeRequest request)
        {
            var updated = await _programmeService.UpdateAsync(id, request);

            if (!updated)
            {
                return NotFound("Programme not found.");
            }

            return NoContent();
        }

        // DELETE: api/Programmes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _programmeService.DeleteAsync(id);

            if (!deleted)
            {
                return NotFound("Programme not found.");
            }

            return NoContent();
        }
    }
}