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


        [HttpGet("{categoryId}/posts")]
        public async Task<ActionResult<IEnumerable<Post>>> GetCategoryPosts(int categoryId, CancellationToken cancellationToken)
        {
            return Ok(await _service.GetCategoryPosts(categoryId, cancellationToken));
        }
        
        /// <summary>
        /// Get all categories
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<Category>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Category>>> GetAllCategory(CancellationToken cancellationToken)
        {
            return Ok(await _service.GetAllCategories(cancellationToken));
        }
        /// <summary>
        /// Get category by iod
        /// </summary>
        /// <param name="id"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Post))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Category>> GetCategory(int id, CancellationToken cancellationToken)
        {
            var category = await _service.GetCategoryById(id, cancellationToken);

            return category;
        }
    }
}
