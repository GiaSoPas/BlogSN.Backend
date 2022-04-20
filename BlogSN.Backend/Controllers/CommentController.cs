using BlogSN.Backend.Services;
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
        public async Task<ActionResult<Comment>> CreateComment(Comment comment, CancellationToken cancellationToken)
        {
            await _service.CreateComment(comment, cancellationToken);
            return Ok();
        }
    }
}
