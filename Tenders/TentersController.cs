using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Tenders.Data;
using Tenders.Models;

namespace Tenders
{
    public class TentersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TentersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Tenters
        public async Task<IActionResult> Index()
        {
            return View(await _context.Tenter.ToListAsync());
        }

        // GET: Tenters/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tenter = await _context.Tenter
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tenter == null)
            {
                return NotFound();
            }

            return View(tenter);
        }

        // GET: Tenters/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Tenters/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Description,StartPrice,FinalPrice,CretedOn,CreatedBy,CPVCode,Status")] Tenter tenter)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tenter);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tenter);
        }

        // GET: Tenters/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tenter = await _context.Tenter.FindAsync(id);
            if (tenter == null)
            {
                return NotFound();
            }
            return View(tenter);
        }

        // POST: Tenters/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description,StartPrice,FinalPrice,CretedOn,CreatedBy,CPVCode,Status")] Tenter tenter)
        {
            if (id != tenter.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tenter);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TenterExists(tenter.Id))
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
            return View(tenter);
        }

        // GET: Tenters/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tenter = await _context.Tenter
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tenter == null)
            {
                return NotFound();
            }

            return View(tenter);
        }

        // POST: Tenters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tenter = await _context.Tenter.FindAsync(id);
            _context.Tenter.Remove(tenter);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TenterExists(int id)
        {
            return _context.Tenter.Any(e => e.Id == id);
        }
    }
}
