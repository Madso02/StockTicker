using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using StockTicker.Models;

namespace StockTicker.Controllers
{
    public class StockTickerItemsController : Controller
    {
        private readonly MariaDbContext _context;

        public StockTickerItemsController(MariaDbContext context)
        {
            _context = context;
        }

        // GET: StockTickers
        public async Task<IActionResult> Index()
        {
            return View(await _context.StockTickerItems.ToListAsync());
        }

        // GET: StockTickers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var stockTicker = await _context.StockTickerItems
                .FirstOrDefaultAsync(m => m.Id == id);
            if (stockTicker == null)
            {
                return NotFound();
            }

            return View(stockTicker);
        }

        // GET: StockTickers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: StockTickers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Symbol,Price")] StockTickerItem stockTicker)
        {
            if (ModelState.IsValid)
            {
                _context.Add(stockTicker);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(stockTicker);
        }

        // GET: StockTickers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var stockTicker = await _context.StockTickerItems.FindAsync(id);
            if (stockTicker == null)
            {
                return NotFound();
            }
            return View(stockTicker);
        }

        // POST: StockTickers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id, [Bind("Id,Symbol,Price")] StockTickerItem stockTicker)
        {
            if (id != stockTicker.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(stockTicker);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StockTickerExists(stockTicker.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(stockTicker);
        }

        // GET: StockTickers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var stockTicker = await _context.StockTickerItems
                .FirstOrDefaultAsync(m => m.Id == id);
            if (stockTicker == null)
            {
                return NotFound();
            }

            return View(stockTicker);
        }

        // POST: StockTickers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
            var stockTicker = await _context.StockTickerItems.FindAsync(id);
            if (stockTicker != null)
            {
                _context.StockTickerItems.Remove(stockTicker);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StockTickerExists(int? id)
        {
            return _context.StockTickerItems.Any(e => e.Id == id);
        }
    }
}
