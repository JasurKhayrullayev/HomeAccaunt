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
    public class MobilesModelsController : Controller
    {
        private readonly AppDbContext _context;

        public MobilesModelsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: MobilesModels
        public async Task<IActionResult> Index()
        {
            return View(await _context.Mobiles.ToListAsync());
        }

        // GET: MobilesModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mobilesModel = await _context.Mobiles
                .FirstOrDefaultAsync(m => m.Id == id);
            if (mobilesModel == null)
            {
                return NotFound();
            }

            return View(mobilesModel);
        }

        // GET: MobilesModels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: MobilesModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,mobnumber,mobname,mobcategory,mobprice,mobcomment,mobdate")] MobilesModel mobilesModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(mobilesModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(mobilesModel);
        }

        // GET: MobilesModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mobilesModel = await _context.Mobiles.FindAsync(id);
            if (mobilesModel == null)
            {
                return NotFound();
            }
            return View(mobilesModel);
        }

        // POST: MobilesModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,mobnumber,mobname,mobcategory,mobprice,mobcomment,mobdate")] MobilesModel mobilesModel)
        {
            if (id != mobilesModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(mobilesModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MobilesModelExists(mobilesModel.Id))
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
            return View(mobilesModel);
        }

        // GET: MobilesModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mobilesModel = await _context.Mobiles
                .FirstOrDefaultAsync(m => m.Id == id);
            if (mobilesModel == null)
            {
                return NotFound();
            }

            return View(mobilesModel);
        }

        // POST: MobilesModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var mobilesModel = await _context.Mobiles.FindAsync(id);
            if (mobilesModel != null)
            {
                _context.Mobiles.Remove(mobilesModel);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MobilesModelExists(int id)
        {
            return _context.Mobiles.Any(e => e.Id == id);
        }
    }
}
