using Microsoft.AspNetCore.Mvc;
using netCorev2Consist.Models;
using netCorev2Consist.Repositories;


namespace netCorev2Consist.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] User user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _userRepository.AddUserAsync(user);
            return Ok();
        }

        private async Task<User> GetUserByIdAsync(int userId)
        {
            return await _userRepository.GetUserByIdAsync(userId);
        }

        [HttpDelete("{userId}")]
        public async Task<IActionResult> DeleteUser(int userId)
        {
            var user = await _userRepository.GetUserByIdAsync(userId);
            if (user == null)
            {
                return NotFound();
            }

            await _userRepository.DeleteUserAsync(userId);
            return NoContent();
        }

        [HttpGet("{userId}")]
        public async Task<IActionResult> ValidateUser(int userId, string password)
        {
            var user = await _userRepository.GetUserByIdAsync(userId);
            if (user == null || user.UserPassword != password)
            {
                return Unauthorized();
            }

            return Ok(user);
        }
    }
}
