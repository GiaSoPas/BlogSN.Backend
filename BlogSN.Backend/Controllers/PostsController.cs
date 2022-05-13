#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BlogSN.Backend.Data;
using BlogSN.Models;
using BlogSN.Backend.Services;
using Models.ModelsBlogSN;
using Microsoft.AspNetCore.Authorization;

namespace BlogSN.Backend.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class PostsController : ControllerBase
    {
        private readonly IPostService _service;


        public PostsController(IPostService service)
        {
            _service = service;
        }

        // GET: api/Posts
        /// <summary>
        /// Get all posts
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<Post>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Post>>> GetPosts(CancellationToken cancellationToken)
        {
            return Ok(await _service.GetPosts(cancellationToken));
        }

       

        // GET: api/Posts/5
        /// <summary>
        /// Get post by id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Post))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Post>> GetPost(int id, CancellationToken cancellationToken)
        {
            var post = await _service.GetPostById(id, cancellationToken);

            return post;
        }

        // PUT: api/Posts/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        /// <summary>
        /// Update post
        /// </summary>
        /// <param name="id"></param>
        /// <param name="post"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> PutPost(int id, [FromBody]Post post, CancellationToken cancellationToken)
        {
            await _service.UpdatePostById(id, post, cancellationToken);
            
            return NoContent();
        }

        // POST: api/Posts
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        /// <summary>
        /// Create post
        /// </summary>
        /// <param name="post"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpPost]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(Post))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Post>> PostPost(Post post, CancellationToken cancellationToken)
        {
            await _service.CreatePost(post, cancellationToken);

            return CreatedAtAction("GetPost", new { id = post.Id }, post);
        }

        // DELETE: api/Posts/5
        /// <summary>
        /// Delete post by id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeletePost(int id, CancellationToken cancellationToken)
        {
            await _service.DeletePostById(id, cancellationToken);
            
            return NoContent();
        }
        
        [HttpGet("{postId}/comments")]
        public async Task<ActionResult<IEnumerable<Post>>> GetCategoryPosts(int postId, CancellationToken cancellationToken)
        {
            return Ok(await _service.GetCommnetsByPost(postId, cancellationToken));
        }

    }
}
