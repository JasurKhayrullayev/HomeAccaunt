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
    public class InternetsModelsController : Controller
    {
        private readonly AppDbContext _context;

        public InternetsModelsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: InternetsModels
        public async Task<IActionResult> Index()
        {
            return View(await _context.Internets.ToListAsync());
        }

        // GET: InternetsModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var internetsModel = await _context.Internets
                .FirstOrDefaultAsync(m => m.Id == id);
            if (internetsModel == null)
            {
                return NotFound();
            }

            return View(internetsModel);
        }

        // GET: InternetsModels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: InternetsModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,inpcodenum,inname,incategory,inprice,incomment,indate")] InternetsModel internetsModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(internetsModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(internetsModel);
        }

        // GET: InternetsModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var internetsModel = await _context.Internets.FindAsync(id);
            if (internetsModel == null)
            {
                return NotFound();
            }
            return View(internetsModel);
        }

        // POST: InternetsModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,inpcodenum,inname,incategory,inprice,incomment,indate")] InternetsModel internetsModel)
        {
            if (id != internetsModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(internetsModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InternetsModelExists(internetsModel.Id))
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
            return View(internetsModel);
        }

        // GET: InternetsModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var internetsModel = await _context.Internets
                .FirstOrDefaultAsync(m => m.Id == id);
            if (internetsModel == null)
            {
                return NotFound();
            }

            return View(internetsModel);
        }

        // POST: InternetsModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var internetsModel = await _context.Internets.FindAsync(id);
            if (internetsModel != null)
            {
                _context.Internets.Remove(internetsModel);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InternetsModelExists(int id)
        {
            return _context.Internets.Any(e => e.Id == id);
        }
    }
}
