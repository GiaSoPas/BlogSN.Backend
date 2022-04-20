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
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Post>>> GetPosts(CancellationToken cancellationToken)
        {
            return Ok(await _service.GetPosts(cancellationToken));
        }


        // GET: api/Posts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Post>> GetPost(int id, CancellationToken cancellationToken)
        {
            var post = await _service.GetPostById(id, cancellationToken);

            if (post == null)
            {
                return NotFound();
            }

            return post;
        }

        // PUT: api/Posts/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPost(int id, [FromBody]Post post, CancellationToken cancellationToken)
        {
            if (id != post.Id)
            {
                return BadRequest();
            }

            await _service.UpdatePostById(id, post, cancellationToken);

           

            return NoContent();
        }

        // POST: api/Posts
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Post>> PostPost(Post post, CancellationToken cancellationToken)
        {
            await _service.CreatePost(post, cancellationToken);

            return CreatedAtAction("GetPost", new { id = post.Id }, post);
        }

        // DELETE: api/Posts/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePost(int id, CancellationToken cancellationToken)
        {
            await _service.DeletePostById(id, cancellationToken);
            
            return NoContent();
        }

    }
}
