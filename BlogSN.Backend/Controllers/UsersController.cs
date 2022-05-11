using BlogSN.Backend.Services;
using BlogSN.Models;
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

        [HttpDelete("{userId}")]
        public async Task<IActionResult> DeletePost(string userId, CancellationToken cancellationToken)
        {
            await _service.DeleteUserById(userId, cancellationToken);

            return NoContent();
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ApplicationUser>>> GetUsers(CancellationToken cancellationToken)
        {
            return Ok(await _service.GetUsers(cancellationToken));
        }

        [HttpPut("{userId}")]
        public async Task<IActionResult> PutPost(string userId, [FromBody] ApplicationUser applicationUser, CancellationToken cancellationToken)
        {
            await _service.UpdateUserById(userId, applicationUser, cancellationToken);

            return NoContent();
        }
    }
}
