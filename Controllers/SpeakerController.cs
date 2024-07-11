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
    public class SpeakerController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public SpeakerController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Speakers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Speaker>>> GetSpeakers()
        {
            var speakers = await _context.Speakers.ToListAsync();
            return Ok(speakers);
        }

        // POST: api/Speakers
        [HttpPost]
        public async Task<ActionResult<Speaker>> PostSpeaker(Speaker speaker)
        {
            _context.Speakers.Add(speaker);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetSpeakers), new { id = speaker.Id }, speaker);
        }
    }
}
