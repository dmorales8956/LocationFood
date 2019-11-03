using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LocationFood.Web.Controllers.Data;
using LocationFood.Web.Controllers.Data.Entities;

namespace LocationFood.Web.Controllers
{
    public class AdminRestaurantsController : Controller
    {
        private readonly DataContext _context;

        public AdminRestaurantsController(DataContext context)
        {
            _context = context;
        }

        // GET: AdminRestaurants
        public async Task<IActionResult> Index()
        {
            return View(await _context.AdminRestaurants.ToListAsync());
        }

        // GET: AdminRestaurants/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var adminRestaurant = await _context.AdminRestaurants
                .FirstOrDefaultAsync(m => m.Id == id);
            if (adminRestaurant == null)
            {
                return NotFound();
            }

            return View(adminRestaurant);
        }

        // GET: AdminRestaurants/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AdminRestaurants/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id")] AdminRestaurant adminRestaurant)
        {
            if (ModelState.IsValid)
            {
                _context.Add(adminRestaurant);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(adminRestaurant);
        }

        // GET: AdminRestaurants/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var adminRestaurant = await _context.AdminRestaurants.FindAsync(id);
            if (adminRestaurant == null)
            {
                return NotFound();
            }
            return View(adminRestaurant);
        }

        // POST: AdminRestaurants/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id")] AdminRestaurant adminRestaurant)
        {
            if (id != adminRestaurant.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(adminRestaurant);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AdminRestaurantExists(adminRestaurant.Id))
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
            return View(adminRestaurant);
        }

        // GET: AdminRestaurants/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var adminRestaurant = await _context.AdminRestaurants
                .FirstOrDefaultAsync(m => m.Id == id);
            if (adminRestaurant == null)
            {
                return NotFound();
            }

            return View(adminRestaurant);
        }

        // POST: AdminRestaurants/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var adminRestaurant = await _context.AdminRestaurants.FindAsync(id);
            _context.AdminRestaurants.Remove(adminRestaurant);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AdminRestaurantExists(int id)
        {
            return _context.AdminRestaurants.Any(e => e.Id == id);
        }
    }
}
