using BlogSN.Backend.Services;
using BlogSN.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Models.ModelsIdentity.IdentityAuth;

namespace BlogSN.Backend.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserServive _service;

        public UsersController(IUserServive service)
        {
            _service = service;
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ApplicationUser))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ApplicationUser>> GetUser(string id, CancellationToken cancellationToken)
        {
            var user = await _service.GetUserById(id, cancellationToken);

            return user;
        }

        [HttpGet("{userId}/posts")]
        public async Task<ActionResult<IEnumerable<Post>>> GetPostsByUserId(string userId, CancellationToken cancellationToken)
        {
            return Ok(await _service.GetPostsByUserId(userId, cancellationToken));
        }

        [HttpGet("{userId}/comments")]
        public async Task<ActionResult<IEnumerable<Post>>> GetCommentsByUserId(string userId, CancellationToken cancellationToken)
        {
            return Ok(await _service.GetCommentsByUserId(userId, cancellationToken));
        }

        [HttpGet("{userId}/ratings")]
        public async Task<ActionResult<IEnumerable<Post>>> GetRattingByUserId(string userId, CancellationToken cancellationToken)
        {
            return Ok(await _service.GetRatingsByUserId(userId, cancellationToken));
        }

        [HttpDelete("{userId}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteUserByUserId(string userId, CancellationToken cancellationToken)
        {
            await _service.DeleteUserById(userId, cancellationToken);

            return NoContent();
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<IEnumerable<ApplicationUser>>> GetUsers(CancellationToken cancellationToken)
        {
            return Ok(await _service.GetUsers(cancellationToken));
        }

        [HttpPut("{userId}/changeName")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> PutUsernameByUserId(string userId, string newName, CancellationToken cancellationToken)
        {
            await _service.UpdateUsernameById(userId, newName, cancellationToken);

            return NoContent();
        }

        [HttpPut("{userId}/changeEmail")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> PutUserEmailByUserId(string userId, string newEmail, CancellationToken cancellationToken)
        {
            await _service.UpdateUserEmailById(userId, newEmail, cancellationToken);

            return NoContent();
        }

        [HttpPut("{userId}/changeRoleToAdmin")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateUserRoleToAdminById(string userId, CancellationToken cancellationToken)
        {
            await _service.UpdateUserRoleToAdminById(userId, cancellationToken);

            return NoContent();
        }

        [HttpPut("{userId}/changeRoleToUser")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateUserRoleToUserById(string userId, CancellationToken cancellationToken)
        {
            await _service.UpdateUserRoleToUserById(userId, cancellationToken);

            return NoContent();
        }
    }
}
