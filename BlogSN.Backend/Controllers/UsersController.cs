using BlogSN.Backend.Services;
using BlogSN.Models;
using Microsoft.AspNetCore.Mvc;
using Models.ModelsIdentity.IdentityAuth;

namespace BlogSN.Backend.Controllers
{
    public class UsersController : ControllerBase
    {
        private readonly IUsersServive _service;

        public UsersController(IUsersServive service)
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
    }
}
