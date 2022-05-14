#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Minecraft.Data;
using Minecraft.Models;

namespace Minecraft.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlinthsSqlController : ControllerBase
    {
        private readonly DataDbContext _context;
        private readonly DataContext _context1;

        public PlinthsSqlController(DataDbContext context, DataContext context1 )
        {
            _context = context;
            _context1 = context1;
        }

        // GET: api/PlinthsSql
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Plinth>>> GetPlinth()
        {
            return await _context.Plinth.ToListAsync();
        }

        // GET: api/PlinthsSql/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Plinth>> GetPlinth(string id)
        {
            var plinth = await _context.Plinth.FindAsync(id);

            if (plinth == null)
            {
                return NotFound();
            }

            return plinth;
        }

        // PUT: api/PlinthsSql/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPlinth(string id, Plinth plinth)
        {
            if (id != plinth.Id)
            {
                return BadRequest();
            }

            _context.Entry(plinth).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PlinthExists(id))
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

        // POST: api/PlinthsSql
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<List<Plinth>>> PostPlinth(Plinth plinth)
        {
            var list = await _context1.Plinths.ToListAsync();
            foreach (var item in list)
            {

                plinth = item;
                _context.Plinth.Add(plinth);

            }
            _context.Plinth.AddRange(list);





            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (PlinthExists(plinth.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetPlinth", new { id = plinth.Id }, list);
        }

        // DELETE: api/PlinthsSql/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePlinth(string id)
        {
            var plinth = await _context.Plinth.FindAsync(id);
            if (plinth == null)
            {
                return NotFound();
            }

            _context.Plinth.Remove(plinth);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PlinthExists(string id)
        {
            return _context.Plinth.Any(e => e.Id == id);
        }
    }
}
