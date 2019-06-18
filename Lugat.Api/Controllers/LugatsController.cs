using Lugat.Api.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lugat.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LugatsController : ControllerBase
    {
        private readonly LugatContext _context;

        public LugatsController(LugatContext context)
        {
            _context = context;
        }

        // GET: api/Lugats
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Models.Lugat>>> GetLugatlar()
        {
            return await _context.Lugatlar.ToListAsync();
        }

        // GET: api/Lugats/5
        [HttpGet("{id}")]
        [Route("detail")]
        public async Task<ActionResult<Models.Lugat>> DetailLugat(int lugatId)
        {
            var lugat = await _context.Lugatlar.FindAsync(lugatId);

            if (lugat == null)
            {
                return NotFound();
            }

            return lugat;
        }

        [HttpGet("{id}")]
        [Route("search")]
        public async Task<ActionResult<IEnumerable<Models.Lugat>>> SearchLugat(string key)
        {
            var lugat = await _context.Lugatlar.Where(l=>l.Kirpilmis.StartsWith(key)).ToListAsync();

            if (lugat == null)
            {
                return NotFound();
            }

            return lugat;
        }

        // PUT: api/Lugats/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLugat(int id, Models.Lugat lugat)
        {
            if (id != lugat.Id)
            {
                return BadRequest();
            }

            _context.Entry(lugat).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LugatExists(id))
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

        // POST: api/Lugats
        [HttpPost]
        public async Task<ActionResult<Models.Lugat>> PostLugat(Models.Lugat lugat)
        {
            _context.Lugatlar.Add(lugat);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLugat", new { id = lugat.Id }, lugat);
        }

        // DELETE: api/Lugats/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Models.Lugat>> DeleteLugat(int id)
        {
            var lugat = await _context.Lugatlar.FindAsync(id);
            if (lugat == null)
            {
                return NotFound();
            }

            _context.Lugatlar.Remove(lugat);
            await _context.SaveChangesAsync();

            return lugat;
        }

        private bool LugatExists(int id)
        {
            return _context.Lugatlar.Any(e => e.Id == id);
        }
    }
}
