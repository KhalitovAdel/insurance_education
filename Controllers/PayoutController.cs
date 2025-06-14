using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using insurance;
using insurance.Models;

namespace insurance.Controllers
{
    public class PayoutController : Controller
    {
        private readonly AppDbContext _context;

        public PayoutController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Payout
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.Payouts.Include(p => p.InsuranceCase);
            return View(await appDbContext.ToListAsync());
        }

        // GET: Payout/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var payout = await _context.Payouts
                .Include(p => p.InsuranceCase)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (payout == null)
            {
                return NotFound();
            }

            return View(payout);
        }

        // GET: Payout/Create
        public IActionResult Create()
        {
            ViewData["InsuranceCaseId"] = new SelectList(_context.InsuranceCases, "Id", "Description");
            return View();
        }

        // POST: Payout/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Amount,Date,InsuranceCaseId")] Payout payout)
        {
            if (ModelState.IsValid)
            {
                _context.Add(payout);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["InsuranceCaseId"] = new SelectList(_context.InsuranceCases, "Id", "Description", payout.InsuranceCaseId);
            return View(payout);
        }

        // GET: Payout/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var payout = await _context.Payouts.FindAsync(id);
            if (payout == null)
            {
                return NotFound();
            }
            ViewData["InsuranceCaseId"] = new SelectList(_context.InsuranceCases, "Id", "Description", payout.InsuranceCaseId);
            return View(payout);
        }

        // POST: Payout/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Amount,Date,InsuranceCaseId")] Payout payout)
        {
            if (id != payout.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(payout);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PayoutExists(payout.Id))
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
            ViewData["InsuranceCaseId"] = new SelectList(_context.InsuranceCases, "Id", "Description", payout.InsuranceCaseId);
            return View(payout);
        }

        // GET: Payout/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var payout = await _context.Payouts
                .Include(p => p.InsuranceCase)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (payout == null)
            {
                return NotFound();
            }

            return View(payout);
        }

        // POST: Payout/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var payout = await _context.Payouts.FindAsync(id);
            if (payout != null)
            {
                _context.Payouts.Remove(payout);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PayoutExists(int id)
        {
            return _context.Payouts.Any(e => e.Id == id);
        }
    }
}
