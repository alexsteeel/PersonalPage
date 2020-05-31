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

        // POST: api/Comments
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Comment>> PostComment(Post post)
        {
            var createdPost = await _db.AddAsync(post);

            return CreatedAtAction("GetPost", new { id = createdPost.Id }, createdPost);
        }
    }
}
