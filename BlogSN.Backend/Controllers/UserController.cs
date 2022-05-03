using BlogSN.Backend.Services;
using Microsoft.AspNetCore.Mvc;
using Models.ModelsIdentity.IdentityAuth;

namespace BlogSN.Backend.Controllers
{
    public class UserController : ControllerBase
    {
        private readonly IUsersServive _service;

        public UserController(IUsersServive service)
        {
            _service = service;
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ApplicationUser))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ApplicationUser>> GetPost(string id, CancellationToken cancellationToken)
        {
            var user = await _service.GetUserById(id, cancellationToken);

            return user;
        }
    }
}
