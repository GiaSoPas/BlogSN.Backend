using BlogSN.Backend.Models;
using BlogSN.Backend.Services;
using Microsoft.AspNetCore.Mvc;

namespace BlogSN.Backend.Controllers
{
    [Route("api/post")]
    [Produces("application/json")]
    [ApiController]
    public class PostController : ControllerBase
    {

        private readonly IPostService _service;

        public PostController(IPostService service)
        {
            _service = service;
        }

        /// <summary>
        /// Get all posts
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        // [EnableCors("_myAllowSpecificOrigins")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<Post>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<Post>>> GetPosts()
        {
            return Ok(await _service.GetPosts());
        }

        /// <summary>
        /// Create new post
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> CreatePost([FromBody]Post post)
        {
            await _service.CreatePost(post);
            return Ok();

        }
    }
}
