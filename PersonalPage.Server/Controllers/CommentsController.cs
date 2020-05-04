using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PersonalPage.Data;
using PersonalPage.Data.Entities;
using PersonalPage.Data.Repositories;

namespace PersonalPage.Server.Controllers
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
            var comments = await _db.GetAsync();
            return comments;
        }

        // GET: api/Comments/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Comment>> GetComment(int id)
        {
            var comment = await _db.FindAsync(x => x.Id == id);

            if (comment == null)
            {
                return NotFound();
            }

            return comment;
        }

        // POST: api/Comments
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Comment>> PostComment(Comment comment)
        {
            var createdComment = await _db.CreateAsync(comment);

            return CreatedAtAction("GetComment", new { id = createdComment.Id }, createdComment);
        }
    }
}
