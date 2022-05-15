using BlogSN.Backend.Services;
using Microsoft.AspNetCore.Authorization;
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
        [Authorize]
        public async Task<ActionResult<Rating>> CreateRatting(Rating rating, CancellationToken cancellationToken)
        {
            rating.Id = rating.PostId + rating.ApplicationUserId;
            await _service.CreateRatingStatus(rating, cancellationToken);
            return Ok();
        }

        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> DeleteRatting(string id, CancellationToken cancellationToken)
        {
            await _service.DeleteRatingStatusById(id, cancellationToken);
            return NoContent();
        }

        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> PutRatting(string id, [FromBody] Rating rating, CancellationToken cancellationToken)
        {
            await _service.UpdateRatingStatusById(id, rating, cancellationToken);
            return NoContent();
        }
    }
}
