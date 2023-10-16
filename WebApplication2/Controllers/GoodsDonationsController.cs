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
    public class GoodsDonationsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public GoodsDonationsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: GoodsDonations
        public async Task<IActionResult> Index()
        {
              return _context.GoodsDonations != null ? 
                          View(await _context.GoodsDonations.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.GoodsDonations'  is null.");
        }

        // GET: GoodsDonations/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.GoodsDonations == null)
            {
                return NotFound();
            }

            var goodsDonations = await _context.GoodsDonations
                .FirstOrDefaultAsync(m => m.GDonID == id);
            if (goodsDonations == null)
            {
                return NotFound();
            }

            return View(goodsDonations);
        }

        // GET: GoodsDonations/Create
        public IActionResult Create()
        {
            var categories = _context.Categories.ToList();

            var categoryOptions = categories.Select(c => new SelectListItem
            {
                Value = c.Name, 
                Text = c.Name 
            }).ToList();
            categoryOptions.Add(new SelectListItem { Value = "Clothes", Text = "Clothes" });
            categoryOptions.Add(new SelectListItem { Value = "Foods", Text = "Foods" });

            ViewBag.CategoryOptions = categoryOptions;

            return View();
        }

        // POST: GoodsDonations/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("GDonID,Date,NumberOfItems,Category,Description,DonorName")] GoodsDonations goodsDonations)
        {
            if (ModelState.IsValid)
            {
                if (goodsDonations.DonorName == "A")
                {
                    goodsDonations.DonorName = "Anonymous";
                }

                _context.Add(goodsDonations);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            var categories = _context.Categories.ToList();
            var categoryOptions = categories.Select(c => new SelectListItem
            {
                Value = c.Name,
                Text = c.Name
            }).ToList();
            ViewBag.CategoryOptions = categoryOptions;

            return View(goodsDonations);
        }

        // GET: GoodsDonations/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.GoodsDonations == null)
            {
                return NotFound();
            }

            var goodsDonations = await _context.GoodsDonations.FindAsync(id);
            if (goodsDonations == null)
            {
                return NotFound();
            }
            return View(goodsDonations);
        }

        // POST: GoodsDonations/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("GDonID,Date,NumberOfItems,Category,Description,DonorName")] GoodsDonations goodsDonations)
        {
            if (id != goodsDonations.GDonID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(goodsDonations);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GoodsDonationsExists(goodsDonations.GDonID))
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
            return View(goodsDonations);
        }

        // GET: GoodsDonations/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.GoodsDonations == null)
            {
                return NotFound();
            }

            var goodsDonations = await _context.GoodsDonations
                .FirstOrDefaultAsync(m => m.GDonID == id);
            if (goodsDonations == null)
            {
                return NotFound();
            }

            return View(goodsDonations);
        }

        // POST: GoodsDonations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.GoodsDonations == null)
            {
                return Problem("Entity set 'ApplicationDbContext.GoodsDonations'  is null.");
            }
            var goodsDonations = await _context.GoodsDonations.FindAsync(id);
            if (goodsDonations != null)
            {
                _context.GoodsDonations.Remove(goodsDonations);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GoodsDonationsExists(int id)
        {
          return (_context.GoodsDonations?.Any(e => e.GDonID == id)).GetValueOrDefault();
        }
    }
}
