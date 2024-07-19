using Blog_API.Models;
using Blog_API.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Blog_API.Controllers
{
    [Route("api/[controller]/v1")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        // GET: api/<UserController>
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Get()
        {
            var user = await _userService.GetAllUsersAsync();
            return Ok(user);
        }

        // GET api/User/id/{id}
        [HttpGet("id/{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var user = await _userService.GetUserByIdAsync(id);

            if (user == null)
                return NotFound("User not found");

            return Ok(user);
        }

        // GET api/User/username/{username}
        [HttpGet("username/{username}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetByUsername(string username)
        {
            var user = await _userService.GetUserByUsernameAsync(username);

            if (user == null)
                return NotFound("User not found");
            return Ok(user);
        }

        // POST api/User
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] User user)
        {
            var createdUser = await _userService.CreatedUserAsync(user);

            if (createdUser == null)
                return BadRequest("User not created");

            return CreatedAtAction(nameof(GetById), new { id = createdUser!.Id }, createdUser);
        }

        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, [FromBody] User user)
        {
            var userToUpdate = await _userService.GetUserByIdAsync(id);

            if (userToUpdate == null)
                return NotFound("User not found");

            var updatedUser = await _userService.UpdateUserAsync(user);

            if (updatedUser == null)
                return BadRequest("User not found");

            return Ok(updatedUser);
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var userToDelete = await _userService.GetUserByIdAsync(id);

            if (userToDelete == null)
                return NotFound("User not found");

            var deletedUser = await _userService.RemoveUserAsync(id);

            if (deletedUser == null)
                return NotFound("User not found");

            return Ok(deletedUser);
        }
    }
}