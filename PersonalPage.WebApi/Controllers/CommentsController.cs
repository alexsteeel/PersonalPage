using Microsoft.AspNetCore.Mvc;
using PersonalPage.Data.Entities;
using PersonalPage.Data.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PersonalPage.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentsController : ControllerBase
    {
        private readonly IBaseRepository<Comment> _db;

        public CommentsController(IBaseRepository<Comment> db)
        {
            _db = db;
        }

        // GET: api/Comments
        [HttpGet]
        public async Task<IEnumerable<Comment>> GetComments()
        {
            var comments = await _db.GetAllAsync();
            return comments;
        }

        // GET: api/Comments/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Comment>> GetComment(int id)
        {
            var comment = await _db.GetByIdAsync(id);

            if (comment == null)
            {
                return NotFound();
            }

            return comment;
        }

        // POST: api/Comments
        [HttpPost]
        public async Task<ActionResult<Comment>> PostComment(Comment comment)
        {
            var createdComment = await _db.CreateAsync(comment);

            return CreatedAtAction("GetComment", new { id = createdComment.Id }, createdComment);
        }

        // PUT: api/Comments/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateComment(int id, Comment comment)
        {
            if (id != comment.Id)
            {
                return BadRequest();
            }

            await _db.UpdateAsync(comment);
            return Ok();
        }

        // DELETE: api/Comments/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteComment(int id)
        {
            var comment = await _db.GetByIdAsync(id);
            if (comment == null)
            {
                return NotFound();
            }

            await _db.Delete(comment);
            return Ok();
        }
    }
}
