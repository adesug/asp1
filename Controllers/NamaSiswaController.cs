using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using belajarASPDB.Data;
using belajarASPDB.Models;
using Microsoft.AspNetCore.Authorization;

namespace belajarASPDB.Controllers
{
    public class NamaSiswaController : Controller
    {
        private readonly ApplicationDbContext _context;

        public NamaSiswaController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: NamaSiswa
        [Authorize]
        public async Task<IActionResult> Index()
        {

            return _context.NamaSiswaModel != null ?
                View(await _context.NamaSiswaModel.ToListAsync()) :
                Problem("Entity set ApplicationDbContext.NamaSiswaModel' is null. ");
        }

        // GET: NamaSiswa/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var namaSiswaModel = await _context.NamaSiswaModel
                .FirstOrDefaultAsync(m => m.id == id);
            if (namaSiswaModel == null)
            {
                return NotFound();
            }

            return View(namaSiswaModel);
        }

        // GET: NamaSiswa/Create

        [Authorize]
        public IActionResult Create()
        {
            return View();
        }

        // POST: NamaSiswa/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,nama,alamat,usia")] NamaSiswaModel namaSiswaModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(namaSiswaModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(namaSiswaModel);
        }

        // GET: NamaSiswa/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var namaSiswaModel = await _context.NamaSiswaModel.FindAsync(id);
            if (namaSiswaModel == null)
            {
                return NotFound();
            }
            return View(namaSiswaModel);
        }

        // POST: NamaSiswa/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,nama,alamat,usia")] NamaSiswaModel namaSiswaModel)
        {
            if (id != namaSiswaModel.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(namaSiswaModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NamaSiswaModelExists(namaSiswaModel.id))
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
            return View(namaSiswaModel);
        }

        // GET: NamaSiswa/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var namaSiswaModel = await _context.NamaSiswaModel
                .FirstOrDefaultAsync(m => m.id == id);
            if (namaSiswaModel == null)
            {
                return NotFound();
            }

            return View(namaSiswaModel);
        }

        // POST: NamaSiswa/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var namaSiswaModel = await _context.NamaSiswaModel.FindAsync(id);
            if (namaSiswaModel != null)
            {
                _context.NamaSiswaModel.Remove(namaSiswaModel);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Cari()
        {
            return View();
        }

        public async Task<IActionResult> HasilPencarian(String KataKunci)
        {
            return View("Index", await _context.NamaSiswaModel.Where(j => j.nama.Contains(KataKunci)).ToListAsync());
        }

        private bool NamaSiswaModelExists(int id)
        {
            return _context.NamaSiswaModel.Any(e => e.id == id);
        }
    }
}
