using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StockTicker.Models;

namespace StockTicker.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OverviewsController : ControllerBase
    {
        private readonly MariaDbContext _context;

        public OverviewsController(MariaDbContext context)
        {
            _context = context;
        }

        // GET: api/Overviews
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Overview>>> GetOverviews()
        {
            return await _context.Overviews.ToListAsync();
        }

        // GET: api/Overviews/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Overview>> GetOverview(long id, string includeStockTickers = "false")
        {
            var overview = await _context.Overviews.FindAsync(id);

            if (overview == null)
            {
                return NotFound();
            }

            bool inclueStockTickerItems = includeStockTickers == "true";

            if (!inclueStockTickerItems)
            {
                overview.OverviewStockTickerItems = null;
            }

            return overview;
        }

        // PUT: api/Overviews/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOverview(long id, OverviewDTO overviewDTO)
        {
            Overview? overview = await _context.Overviews.FindAsync(id);


            if (overview == null)
            {
                return NotFound();
            }

            overview = PatchOverview(overviewDTO, overview);



            _context.Entry(overview).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OverviewExists(id))
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

        // POST: api/Overviews
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Overview>> PostOverview(Overview overview)
        {
            _context.Overviews.Add(overview);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOverview", new { id = overview.ID }, overview);
        }

        // DELETE: api/Overviews/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOverview(long id)
        {
            var overview = await _context.Overviews.FindAsync(id);
            if (overview == null)
            {
                return NotFound();
            }

            _context.Overviews.Remove(overview);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool OverviewExists(long id)
        {
            return _context.Overviews.Any(e => e.ID == id);
        }

        private static Overview PatchOverview(OverviewDTO overviewDTO, Overview overview)
        {
            overview.Name = overviewDTO.Name != null ? overviewDTO.Name.Trim() : overview.Name;
            overview.Description = overviewDTO.Description != null ? overviewDTO.Description.Trim() : overview.Description;
            overview.OverviewStockTickerItems = overviewDTO.OverviewStockTickerItems ?? overview.OverviewStockTickerItems;
            return overview;
        }


    }
}
