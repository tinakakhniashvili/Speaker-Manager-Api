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
        [HttpGet("{id}")]
        public async Task<ActionResult<UserText>> GetUserText(int id)
        {
            var userText = await _context.UserTexts.FindAsync(id);
            if (userText == null)
            {
                return NotFound();
            }
            return Ok(userText);
        }

        // POST: api/UserTexts
        [HttpPost]
        public async Task<ActionResult<UserText>> PostUserText(UserText userText)
        {
            //userText.IsOnTop = userText.IsOnTop;

            _context.UserTexts.Add(userText);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetUserText), new { id = userText.Id }, userText);
        }
    }
}
