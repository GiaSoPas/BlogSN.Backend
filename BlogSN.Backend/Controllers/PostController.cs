using BlogSN.Backend.Models;
using BlogSN.Backend.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Query;

namespace BlogSN.Backend.Controllers
{
    [Route("api")]
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
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpGet("posts")]
        // [EnableCors("_myAllowSpecificOrigins")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<Post>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<Post>>> GetPosts(CancellationToken cancellationToken)
        {
            return Ok(await _service.GetPosts(cancellationToken));
        }

        /// <summary>
        /// Create post
        /// </summary>
        /// <param name="post"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpPost("post")]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(Post))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> CreatePost([FromBody]Post post, CancellationToken cancellationToken)
        {
            await _service.CreatePost(post, cancellationToken);
            return CreatedAtAction(nameof(GetPostById),new {id = post.Id}, post);

        }
        /// <summary>
        /// Get task by id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpGet("post/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Post))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Post>> GetPostById(int id, CancellationToken cancellationToken)
        {
            return Ok(await _service.GetPostById(id, cancellationToken));
        }
        /// <summary>
        /// Delete post by id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpDelete("post/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeletePostById(int id, CancellationToken cancellationToken)
        {
            await _service.DeletePostById(id, cancellationToken);
            return Ok();
        }
        /// <summary>
        /// Update post by id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="post"></param>
        /// <param name="cancellationToken"></param>
        [HttpPut("post/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateTaskById(int id, [FromBody] Post post, CancellationToken cancellationToken)
        {
            await _service.UpdatePostById(id, post, cancellationToken);
            return Ok();
        }
    }
}
