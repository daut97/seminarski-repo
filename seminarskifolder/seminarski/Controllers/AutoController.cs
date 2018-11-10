using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Klase;
using seminarski.Data;
using Microsoft.AspNetCore.Authorization;

namespace seminarski.Controllers
{
    public class AutoController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AutoController(ApplicationDbContext context)
        {
            _context = context;
        }

        [Authorize(Roles = "Admin")]

        // GET: Auto
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Auto.Include(a => a.Proizvodjac);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Auto/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var auto = await _context.Auto
                .Include(a => a.Proizvodjac)
                .FirstOrDefaultAsync(m => m.AutoID == id);
            if (auto == null)
            {
                return NotFound();
            }

            return View(auto);
        }

        // GET: Auto/Create
        public IActionResult Create()
        {
            ViewData["ProizvodjacID"] = new SelectList(_context.Proizvodjac, "ProizvodjacID", "Naziv");//Prikazujemo naziv(drugi atr)// ProizvodjacID naziv viewbaga
            return View();
        }

        // POST: Auto/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AutoID,ProizvodjacID,Model,Boja,Godiste,Novo")] Auto auto)
        {
            if (ModelState.IsValid)
            {
                _context.Add(auto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ProizvodjacID"] = new SelectList(_context.Proizvodjac, "ProizvodjacID", "ProizvodjacID", auto.ProizvodjacID);
            return View(auto);
        }

        // GET: Auto/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var auto = await _context.Auto.FindAsync(id);
            if (auto == null)
            {
                return NotFound();
            }
            ViewData["ProizvodjacID"] = new SelectList(_context.Proizvodjac, "ProizvodjacID", "ProizvodjacID", auto.ProizvodjacID);
            return View(auto);
        }

        // POST: Auto/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AutoID,ProizvodjacID,Model,Boja,Godiste,Novo")] Auto auto)
        {
            if (id != auto.AutoID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(auto);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AutoExists(auto.AutoID))
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
            ViewData["ProizvodjacID"] = new SelectList(_context.Proizvodjac, "ProizvodjacID", "ProizvodjacID", auto.ProizvodjacID);
            return View(auto);
        }

        // GET: Auto/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var auto = await _context.Auto
                .Include(a => a.Proizvodjac)
                .FirstOrDefaultAsync(m => m.AutoID == id);
            if (auto == null)
            {
                return NotFound();
            }

            return View(auto);
        }

        // POST: Auto/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var auto = await _context.Auto.FindAsync(id);
            _context.Auto.Remove(auto);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AutoExists(int id)
        {
            return _context.Auto.Any(e => e.AutoID == id);
        }
    }
}
