using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WarnerMediaAPI.Models;

namespace WarnerMediaAPI.Controllers
{
    [Route("titles")]
    [ApiController]
    [AllowAnonymous]
    public class TitlesController : ControllerBase
    {
        private readonly TitlesContext _context;

        public TitlesController(TitlesContext context)
        {
            _context = context;
        }

        // GET: titles
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Title>>> GetTitles()
        {
            return await _context.Titles.Include(t => t.OtherNames).ToListAsync();
        }

        // GET: titles/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Title>> GetTitle(int id)
        {
            var title = await _context.Titles
                .Include(t => t.Awards)
                .Include(t => t.StoryLines)
                .Include(t => t.StoryLines)
                .Include(t => t.OtherNames)
                .Include(t => t.Genres)
                .FirstOrDefaultAsync(t => t.TitleId == id);

            // this list is huge so instead of exploding out link graph, we will do a separate query
            // this literally took the query for one title from 4s to 70ms
            title.TitleParticipants = await _context.TitleParticipants.Include(t => t.Participant).Where(tp => tp.TitleId == id).ToListAsync();

            if (title == null)
            {
                return NotFound();
            }

            return title;
        }
    }
}
