using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Home.Contex;
using Home.Models;

namespace Home.Controllers
{
    public class TransportsModelsController : Controller
    {
        private readonly AppDbContext _context;

        public TransportsModelsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: TransportsModels
        public async Task<IActionResult> Index()
        {
            return View(await _context.Transports.ToListAsync());
        }

        // GET: TransportsModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var transportsModel = await _context.Transports
                .FirstOrDefaultAsync(m => m.Id == id);
            if (transportsModel == null)
            {
                return NotFound();
            }

            return View(transportsModel);
        }

        // GET: TransportsModels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TransportsModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,trname,trcategory,trprice,trcomment,trdate")] TransportsModel transportsModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(transportsModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(transportsModel);
        }

        // GET: TransportsModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var transportsModel = await _context.Transports.FindAsync(id);
            if (transportsModel == null)
            {
                return NotFound();
            }
            return View(transportsModel);
        }

        // POST: TransportsModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,trname,trcategory,trprice,trcomment,trdate")] TransportsModel transportsModel)
        {
            if (id != transportsModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(transportsModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TransportsModelExists(transportsModel.Id))
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
            return View(transportsModel);
        }

        // GET: TransportsModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var transportsModel = await _context.Transports
                .FirstOrDefaultAsync(m => m.Id == id);
            if (transportsModel == null)
            {
                return NotFound();
            }

            return View(transportsModel);
        }

        // POST: TransportsModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var transportsModel = await _context.Transports.FindAsync(id);
            if (transportsModel != null)
            {
                _context.Transports.Remove(transportsModel);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TransportsModelExists(int id)
        {
            return _context.Transports.Any(e => e.Id == id);
        }
    }
}
