using Microsoft.AspNetCore.Mvc;
using NBC_CMS.Requests;
using NBC_CMS.Services.Interfaces;

namespace NBC_CMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        // GET: api/Users
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var users = await _userService.GetAllAsync();

            return Ok(users);
        }

        // GET: api/Users/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var user = await _userService.GetByIdAsync(id);

            if (user == null)
            {
                return NotFound("User not found.");
            }

            return Ok(user);
        }

        // POST: api/Users
        [HttpPost]
        public async Task<IActionResult> Create(UserRequest request)
        {
            try
            {
                var user = await _userService.CreateAsync(request);

                return CreatedAtAction(
                    nameof(GetById),
                    new { id = user.userID },
                    user
                );
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT: api/Users/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(
            int id,
            UserRequest request)
        {
            try
            {
                var updated = await _userService.UpdateAsync(id, request);

                if (!updated)
                {
                    return NotFound("User not found.");
                }

                return Ok("User updated successfully.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE: api/Users/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _userService.DeleteAsync(id);

            if (!deleted)
            {
                return NotFound("User not found.");
            }

            return Ok("User deleted successfully.");
        }
    }
}