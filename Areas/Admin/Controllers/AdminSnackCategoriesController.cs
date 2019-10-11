using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LanchesWeb.Models;
using Microsoft.AspNetCore.Authorization;

namespace LanchesWeb.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class AdminSnackCategoriesController : Controller
    {
        private readonly LanchesWebContext _context;

        public AdminSnackCategoriesController(LanchesWebContext context)
        {
            _context = context;
        }

        // GET: Admin/AdminSnackCategories
        public async Task<IActionResult> Index()
        {
            return View(await _context.SnackCategories.ToListAsync());
        }

        // GET: Admin/AdminSnackCategories/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var snackCategory = await _context.SnackCategories
                .FirstOrDefaultAsync(m => m.Id == id);
            if (snackCategory == null)
            {
                return NotFound();
            }

            return View(snackCategory);
        }

        // GET: Admin/AdminSnackCategories/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/AdminSnackCategories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Description")] SnackCategory snackCategory)
        {
            if (ModelState.IsValid)
            {
                _context.Add(snackCategory);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(snackCategory);
        }

        // GET: Admin/AdminSnackCategories/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var snackCategory = await _context.SnackCategories.FindAsync(id);
            if (snackCategory == null)
            {
                return NotFound();
            }
            return View(snackCategory);
        }

        // POST: Admin/AdminSnackCategories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description")] SnackCategory snackCategory)
        {
            if (id != snackCategory.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(snackCategory);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SnackCategoryExists(snackCategory.Id))
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
            return View(snackCategory);
        }

        // GET: Admin/AdminSnackCategories/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var snackCategory = await _context.SnackCategories
                .FirstOrDefaultAsync(m => m.Id == id);
            if (snackCategory == null)
            {
                return NotFound();
            }

            return View(snackCategory);
        }

        // POST: Admin/AdminSnackCategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var snackCategory = await _context.SnackCategories.FindAsync(id);
            _context.SnackCategories.Remove(snackCategory);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SnackCategoryExists(int id)
        {
            return _context.SnackCategories.Any(e => e.Id == id);
        }
    }
}
