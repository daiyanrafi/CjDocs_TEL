using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using office.Data;
using office.Models;

namespace office.Controllers
{
    public class DocsTempController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DocsTempController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: DocsTemp
        public async Task<IActionResult> Index()
        {
              return _context.Docs != null ? 
                          View(await _context.Docs.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Docs'  is null.");
        }

        // GET: DocsTemp/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Docs == null)
            {
                return NotFound();
            }

            var doc = await _context.Docs
                .FirstOrDefaultAsync(m => m.Id == id);
            if (doc == null)
            {
                return NotFound();
            }

            return View(doc);
        }

        // GET: DocsTemp/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: DocsTemp/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Url,Tittle,Description,Section,CreateDateTime")] Doc doc)
        {
            if (ModelState.IsValid)
            {
                _context.Add(doc);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(doc);
        }

        // GET: DocsTemp/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Docs == null)
            {
                return NotFound();
            }

            var doc = await _context.Docs.FindAsync(id);
            if (doc == null)
            {
                return NotFound();
            }
            return View(doc);
        }

        // POST: DocsTemp/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Url,Tittle,Description,Section,CreateDateTime")] Doc doc)
        {
            if (id != doc.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(doc);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DocExists(doc.Id))
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
            return View(doc);
        }

        // GET: DocsTemp/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Docs == null)
            {
                return NotFound();
            }

            var doc = await _context.Docs
                .FirstOrDefaultAsync(m => m.Id == id);
            if (doc == null)
            {
                return NotFound();
            }

            return View(doc);
        }

        // POST: DocsTemp/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Docs == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Docs'  is null.");
            }
            var doc = await _context.Docs.FindAsync(id);
            if (doc != null)
            {
                _context.Docs.Remove(doc);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DocExists(int id)
        {
          return (_context.Docs?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
