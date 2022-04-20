using BlogSN.Backend.Services;
using BlogSN.Models;
using Microsoft.AspNetCore.Mvc;

namespace BlogSN.Backend.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _service;


        public CategoriesController(ICategoryService service)
        {
            _service = service;
        }


        [HttpGet("{categoryId}")]
        public async Task<ActionResult<IEnumerable<Post>>> GetCategoryPosts(int categoryId, CancellationToken cancellationToken)
        {
            return Ok(await _service.GetCategotyPosts(categoryId, cancellationToken));
        }
    }
}
