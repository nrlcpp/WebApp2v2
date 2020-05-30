using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApp2v2.Models;

namespace WebApp2v2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentsController : ControllerBase
    {
        private readonly ExpensesDbContext _context;

        public CommentsController(ExpensesDbContext context)
        {
            _context = context;
        }

        // GET: api/Comments
        /// <summary>
        /// Return a list of comments.
        /// </summary>
        /// <returns>A list of comments.</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Comment>>> GetComments()
        {
            return await _context.Comments.ToListAsync();
        }

        // GET: api/Comments/5
        /// <summary>
        /// Return a specific comment.
        /// </summary>
        /// <param name="id">The id of the selected comment.</param>
        /// <returns>The comment.</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<Comment>> GetComment(long id)
        {
            var comment = await _context.Comments.FindAsync(id);

            if (comment == null)
            {
                return NotFound();
            }

            return comment;
        }

        // PUT: api/Comments/5
        /// <summary>
        /// Update a specific comment.
        /// </summary>
        /// <param name="id">The id of the selected comment.</param>
        /// <param name="comment">The updated comment.</param>
        /// <returns>No comment.</returns>
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutComment(long id, Comment comment)
        {
            if (id != comment.Id)
            {
                return BadRequest();
            }

            _context.Entry(comment).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CommentExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Comments
        /// <summary>
        /// Add a new comment.
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// {
        ///     "id": 0,
        ///     "text": "string",
        ///     "important": true,
        ///     "expenseId": 0
        /// }
        /// </remarks>
        /// <param name="comment">The comment to be added.</param>
        /// <returns>A comment.</returns>
        /// <response code="201">Returns the newly created Comment</response>
        /// <response code="400">If the Comment is null</response> 
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Comment>> PostComment(Comment comment)
        {
            _context.Comments.Add(comment);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetComment", new { id = comment.Id }, comment);
        }

        // DELETE: api/Comments/5
        /// <summary>
        /// Delete an comment.
        /// </summary>
        /// <param name="id">The id of the comment wich will be deleted.</param>
        /// <returns>Deleted comment.</returns>
        [HttpDelete("{id}")]
        public async Task<ActionResult<Comment>> DeleteComment(long id)
        {
            var comment = await _context.Comments.FindAsync(id);
            if (comment == null)
            {
                return NotFound();
            }

            _context.Comments.Remove(comment);
            await _context.SaveChangesAsync();

            return comment;
        }

        private bool CommentExists(long id)
        {
            return _context.Comments.Any(e => e.Id == id);
        }
    }
}
