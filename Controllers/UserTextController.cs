using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SpeakerManagerApi.Data;
using SpeakerManagerApi.Models;

namespace SpeakerManagerApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserTextsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public UserTextsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/UserTexts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserText>>> GetUserTexts()
        {
            var userTexts = await _context.UserTexts.ToListAsync();
            return Ok(userTexts);
        }

        // POST: api/UserTexts
        [HttpPost]
        public async Task<ActionResult<UserText>> PostUserText(UserText userText)
        {
            userText.IsOnTop = false;

            _context.UserTexts.Add(userText);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetUserTexts), new { id = userText.Id }, userText);
        }

        // PATCH: api/UserTexts/{id}/toggle-isOnTop
        [HttpPatch("{id}/toggle-isOnTop")]
        public async Task<IActionResult> ToggleIsOnTop(int id, [FromBody] bool isOnTop)
        {
            var userText = await _context.UserTexts.FindAsync(id);
            if (userText == null)
            {
                return NotFound();
            }

            userText.IsOnTop = isOnTop;
            _context.Entry(userText).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserTextExists(id))
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

        private bool UserTextExists(int id)
        {
            return _context.UserTexts.Any(e => e.Id == id);
        }
    }
}
