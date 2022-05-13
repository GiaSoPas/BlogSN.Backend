using BlogSN.Backend.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.ModelsBlogSN;

namespace BlogSN.Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly ICommentService _service;

        public CommentController(ICommentService service)
        {
            _service = service;
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult<Comment>> CreateComment(Comment comment, CancellationToken cancellationToken)
        {
            await _service.CreateComment(comment, cancellationToken);
            return Ok();
        }

        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> PutComment(int id, [FromBody] Comment comment, CancellationToken cancellationToken)
        {
            await _service.UpdateCommentById(id, comment, cancellationToken);
            return NoContent();
        }

        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> DeleteComment(int id, CancellationToken cancellationToken)
        {
            await _service.DeleteCommentById(id, cancellationToken);

            return NoContent();
        }
        
        // GET: api/Posts
        /// <summary>
        /// Get all comments
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<Comment>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Comment>>> GetComments(CancellationToken cancellationToken)
        {
            return Ok(await _service.GetComments(cancellationToken));
        }
    }
}
