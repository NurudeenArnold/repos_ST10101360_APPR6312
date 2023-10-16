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
    public class MonetaryDonationsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MonetaryDonationsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: MonetaryDonations
        public async Task<IActionResult> Index()
        {
              return _context.MonetaryDonations != null ? 
                          View(await _context.MonetaryDonations.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.MonetaryDonations'  is null.");
        }

        // GET: MonetaryDonations/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.MonetaryDonations == null)
            {
                return NotFound();
            }

            var monetaryDonations = await _context.MonetaryDonations
                .FirstOrDefaultAsync(m => m.MDonID == id);
            if (monetaryDonations == null)
            {
                return NotFound();
            }

            return View(monetaryDonations);
        }

        // GET: MonetaryDonations/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: MonetaryDonations/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MDonID,Date,Amount,DonorName")] MonetaryDonations monetaryDonations)
        {
            if (ModelState.IsValid)
            {
                if (monetaryDonations.DonorName == "A")
                {
                    monetaryDonations.DonorName = "Anonymous";
                }

                _context.Add(monetaryDonations);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(monetaryDonations);
        }

        // GET: MonetaryDonations/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.MonetaryDonations == null)
            {
                return NotFound();
            }

            var monetaryDonations = await _context.MonetaryDonations.FindAsync(id);
            if (monetaryDonations == null)
            {
                return NotFound();
            }
            return View(monetaryDonations);
        }

        // POST: MonetaryDonations/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MDonID,Date,Amount,DonorName")] MonetaryDonations monetaryDonations)
        {
            if (id != monetaryDonations.MDonID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(monetaryDonations);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MonetaryDonationsExists(monetaryDonations.MDonID))
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
            return View(monetaryDonations);
        }

        // GET: MonetaryDonations/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.MonetaryDonations == null)
            {
                return NotFound();
            }

            var monetaryDonations = await _context.MonetaryDonations
                .FirstOrDefaultAsync(m => m.MDonID == id);
            if (monetaryDonations == null)
            {
                return NotFound();
            }

            return View(monetaryDonations);
        }

        // POST: MonetaryDonations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.MonetaryDonations == null)
            {
                return Problem("Entity set 'ApplicationDbContext.MonetaryDonations'  is null.");
            }
            var monetaryDonations = await _context.MonetaryDonations.FindAsync(id);
            if (monetaryDonations != null)
            {
                _context.MonetaryDonations.Remove(monetaryDonations);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MonetaryDonationsExists(int id)
        {
          return (_context.MonetaryDonations?.Any(e => e.MDonID == id)).GetValueOrDefault();
        }
    }
}
