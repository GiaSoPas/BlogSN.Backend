using BlogSN.Backend.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.ModelsBlogSN;

namespace BlogSN.Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RatingsController : ControllerBase
    {
        private readonly IRatingService _service;

        public RatingsController(IRatingService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<ActionResult<Rating>> CreateComment(Rating rating, CancellationToken cancellationToken)
        {
            await _service.CreateRatingStatus(rating, cancellationToken);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> PutPost(int id, [FromBody] Rating rating, CancellationToken cancellationToken)
        {
            await _service.UpdateRatingStatusById(id, rating, cancellationToken);
            return NoContent();
        }
    }
}
