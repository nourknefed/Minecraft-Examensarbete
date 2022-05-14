#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Minecraft.Data;
using Minecraft.Models;

namespace Minecraft.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlinthsController : ControllerBase
    {
        private readonly DataContext _context;

        public float Price { get; set; }

        public PlinthsController(DataContext context)
        {
            _context = context;
        }

        // GET: api/Plinths
        [EnableCors("AllowAll")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Plinth>>> GetPlinths()

        {
            
            return await _context.Plinths.ToListAsync();
            
        }


        //[EnableCors("AllowAll")]
        //[Route("CountByName")]
        //[HttpGet]
        //public async Task<ActionResult<List<int>>> GetCountByName()
        //{
        //    var plinths = await _context.Plinths.ToListAsync();
        //    var y = plinths.GroupBy(x => x.Name).ToList();


        //    List<int> counts = new();
        //    if (y is not null) { 
        //    }
        //    foreach (var p in y)
        //    {
        //        counts.Add(p.Count());
        //        //counts.Add(p.ToString());
        //    }

 
        //    return counts;
        //}

        [EnableCors("AllowAll")]
        [Route("Count")]
        [HttpGet]
        public async Task<ActionResult<List<string>>> GetCount(string name)
        {
            var plinths = await _context.Plinths.Where(x=> x.Name == name).ToListAsync();
            List<string> counts = new();
            foreach (var p in plinths)
            {
                if (p != null)
                {
                    counts.Add(p.Name);
                }
            }

            return counts;
        }

        [EnableCors("AllowAll")]
        [Route("Names")]
        [HttpGet]
        public async Task<ActionResult<List<string>>> GeNames()
        {
            var plinths = await _context.Plinths.ToListAsync();
            var y = plinths.GroupBy(x => x.Name).Select(y => y.First()).ToList();


            List<string> names = new();
            foreach (var p in y)
            {
                names.Add(p.Name);
            }


            return names;
        }



        // GET: api/Plinths/5
        [EnableCors("AllowAll")]
        [HttpGet("{id}")]
        public async Task<ActionResult<Plinth>> GetPlinth(string id)
        {
            var plinth = await _context.Plinths.FindAsync(id);

            if (plinth == null)
            {
                return NotFound();
            }

            return plinth;
        }



       

        // PUT: api/Plinths/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [EnableCors("AllowAll")]
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

        // POST: api/Plinths
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [EnableCors("AllowAll")]
        [HttpPost]
        public async Task<ActionResult<Plinth>> PostPlinth(Plinth plinth)
        {
            _context.Plinths.Add(plinth);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPlinth", new { id = plinth.Id }, plinth);
        }

        // DELETE: api/Plinths/5
        [EnableCors("AllowAll")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePlinth(string id)
        {
            var plinth = await _context.Plinths.FindAsync(id);
            if (plinth == null)
            {
                return NotFound();
            }

            _context.Plinths.Remove(plinth);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [EnableCors("AllowAll")]
        [HttpDelete]
        public async Task<IActionResult> Deleteall()
        {
            

            _context.Plinths.RemoveRange(_context.Plinths.ToList());
            await _context.SaveChangesAsync();

            return NoContent();
        }



        private bool PlinthExists(string id)
        {
            return _context.Plinths.Any(e => e.Id == id);
        }



        public float Total { get; set; }

        [HttpOptions(Name ="Totalprice") ]
        public float GetTotalPrice()
        {
            Total =  _context.Plinths.Sum(p => p.Price);
           

            return Total;

        }



    }
}
