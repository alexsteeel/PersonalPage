using Microsoft.AspNetCore.Mvc;
using PersonalPage.Data.Entities;
using PersonalPage.Data.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PersonalPage.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostsController : ControllerBase
    {
        private readonly IBaseRepository<Post> _db;

        public PostsController(IBaseRepository<Post> db)
        {
            _db = db;
        }

        // GET: api/Posts
        [HttpGet]
        public async Task<IEnumerable<Post>> GetPosts()
        {
            var posts = await _db.GetAllAsync();
            return posts;
        }

        // GET: api/Posts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Post>> GetPost(int id)
        {
            var post = await _db.GetByIdAsync(id);

            if (post == null)
            {
                return NotFound();
            }

            return post;
        }

        // POST: api/Posts/Create
        [HttpPost]
        public async Task<ActionResult<Post>> CreatePost(Post post)
        {
            var createdPost = await _db.CreateAsync(post);
            return CreatedAtAction("GetPost", new { id = createdPost.Id }, createdPost);
        }

        // PUT: api/Posts/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePost(long id, Post post)
        {
            if (id != post.Id)
            {
                return BadRequest();
            }

            await _db.UpdateAsync(post);
            return Ok();
        }

        // DELETE: api/Posts/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeletePost(int id)
        {
            var post = await _db.GetByIdAsync(id);
            if (post == null)
            {
                return NotFound();
            }

            await _db.Delete(post);
            return Ok();
        }
    }
}
