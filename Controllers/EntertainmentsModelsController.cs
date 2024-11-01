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
    public class EntertainmentsModelsController : Controller
    {
        private readonly AppDbContext _context;

        public EntertainmentsModelsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: EntertainmentsModels
        public async Task<IActionResult> Index()
        {
            return View(await _context.Entertainments.ToListAsync());
        }

        // GET: EntertainmentsModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var entertainmentsModel = await _context.Entertainments
                .FirstOrDefaultAsync(m => m.Id == id);
            if (entertainmentsModel == null)
            {
                return NotFound();
            }

            return View(entertainmentsModel);
        }

        // GET: EntertainmentsModels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: EntertainmentsModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,enname,encategory,enplace,enprice,encomment,endate")] EntertainmentsModel entertainmentsModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(entertainmentsModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(entertainmentsModel);
        }

        // GET: EntertainmentsModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var entertainmentsModel = await _context.Entertainments.FindAsync(id);
            if (entertainmentsModel == null)
            {
                return NotFound();
            }
            return View(entertainmentsModel);
        }

        // POST: EntertainmentsModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,enname,encategory,enplace,enprice,encomment,endate")] EntertainmentsModel entertainmentsModel)
        {
            if (id != entertainmentsModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(entertainmentsModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EntertainmentsModelExists(entertainmentsModel.Id))
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
            return View(entertainmentsModel);
        }

        // GET: EntertainmentsModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var entertainmentsModel = await _context.Entertainments
                .FirstOrDefaultAsync(m => m.Id == id);
            if (entertainmentsModel == null)
            {
                return NotFound();
            }

            return View(entertainmentsModel);
        }

        // POST: EntertainmentsModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var entertainmentsModel = await _context.Entertainments.FindAsync(id);
            if (entertainmentsModel != null)
            {
                _context.Entertainments.Remove(entertainmentsModel);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EntertainmentsModelExists(int id)
        {
            return _context.Entertainments.Any(e => e.Id == id);
        }
    }
}
