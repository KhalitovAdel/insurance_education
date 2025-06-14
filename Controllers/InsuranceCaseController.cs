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
    public class InsuranceCaseController : Controller
    {
        private readonly AppDbContext _context;

        public InsuranceCaseController(AppDbContext context)
        {
            _context = context;
        }

        // GET: InsuranceCase
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.InsuranceCases.Include(i => i.Policy);
            return View(await appDbContext.ToListAsync());
        }

        // GET: InsuranceCase/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var insuranceCase = await _context.InsuranceCases
                .Include(i => i.Policy)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (insuranceCase == null)
            {
                return NotFound();
            }

            return View(insuranceCase);
        }

        // GET: InsuranceCase/Create
        public IActionResult Create()
        {
            ViewData["PolicyId"] = new SelectList(_context.Policies, "Id", "Type");
            return View();
        }

        // POST: InsuranceCase/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Date,Description,Status,PolicyId")] InsuranceCase insuranceCase)
        {
            if (ModelState.IsValid)
            {
                _context.Add(insuranceCase);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PolicyId"] = new SelectList(_context.Policies, "Id", "Type", insuranceCase.PolicyId);
            return View(insuranceCase);
        }

        // GET: InsuranceCase/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var insuranceCase = await _context.InsuranceCases.FindAsync(id);
            if (insuranceCase == null)
            {
                return NotFound();
            }
            ViewData["PolicyId"] = new SelectList(_context.Policies, "Id", "Type", insuranceCase.PolicyId);
            return View(insuranceCase);
        }

        // POST: InsuranceCase/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Date,Description,Status,PolicyId")] InsuranceCase insuranceCase)
        {
            if (id != insuranceCase.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(insuranceCase);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InsuranceCaseExists(insuranceCase.Id))
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
            ViewData["PolicyId"] = new SelectList(_context.Policies, "Id", "Type", insuranceCase.PolicyId);
            return View(insuranceCase);
        }

        // GET: InsuranceCase/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var insuranceCase = await _context.InsuranceCases
                .Include(i => i.Policy)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (insuranceCase == null)
            {
                return NotFound();
            }

            return View(insuranceCase);
        }

        // POST: InsuranceCase/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var insuranceCase = await _context.InsuranceCases.FindAsync(id);
            if (insuranceCase != null)
            {
                _context.InsuranceCases.Remove(insuranceCase);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InsuranceCaseExists(int id)
        {
            return _context.InsuranceCases.Any(e => e.Id == id);
        }
    }
}
