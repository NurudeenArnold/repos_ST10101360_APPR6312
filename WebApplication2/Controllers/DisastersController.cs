using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication2.Areas.Identity.Data;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class DisastersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DisastersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Disasters
        public async Task<IActionResult> Index()
        {
              return _context.Disasters != null ? 
                          View(await _context.Disasters.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Disasters'  is null.");
        }

        // GET: Disasters/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Disasters == null)
            {
                return NotFound();
            }

            var disasters = await _context.Disasters
                .FirstOrDefaultAsync(m => m.DisID == id);
            if (disasters == null)
            {
                return NotFound();
            }

            return View(disasters);
        }

        // GET: Disasters/Create
        public IActionResult Create()
        {
            var Options = new List<SelectListItem>();
            Options.Add(new SelectListItem { Value = "Clothes", Text = "Clothes" });
            Options.Add(new SelectListItem { Value = "Foods", Text = "Foods" });

            ViewBag.Options = Options;

            return View();
        }

        // POST: Disasters/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DisID,StartDate,EndDate,Location,Description,AidType")] Disasters disasters)
        {
            if (ModelState.IsValid)
            {
                _context.Add(disasters);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(disasters);
        }

        // GET: Disasters/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Disasters == null)
            {
                return NotFound();
            }

            var disasters = await _context.Disasters.FindAsync(id);
            if (disasters == null)
            {
                return NotFound();
            }
            return View(disasters);
        }

        // POST: Disasters/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DisID,StartDate,EndDate,Location,Description,AidType")] Disasters disasters)
        {
            if (id != disasters.DisID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(disasters);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DisastersExists(disasters.DisID))
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
            return View(disasters);
        }

        // GET: Disasters/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Disasters == null)
            {
                return NotFound();
            }

            var disasters = await _context.Disasters
                .FirstOrDefaultAsync(m => m.DisID == id);
            if (disasters == null)
            {
                return NotFound();
            }

            return View(disasters);
        }

        // POST: Disasters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Disasters == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Disasters'  is null.");
            }
            var disasters = await _context.Disasters.FindAsync(id);
            if (disasters != null)
            {
                _context.Disasters.Remove(disasters);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DisastersExists(int id)
        {
          return (_context.Disasters?.Any(e => e.DisID == id)).GetValueOrDefault();
        }
    }
}
