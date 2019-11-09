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
    public class RestaurantTypesController : Controller
    {
        private readonly DataContext _context;

        public RestaurantTypesController(DataContext context)
        {
            _context = context;
        }

        // GET: RestaurantTypes
        public async Task<IActionResult> Index()
        {
            return View(await _context.RestaurantTypes.ToListAsync());
        }

        // GET: RestaurantTypes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var restaurantType = await _context.RestaurantTypes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (restaurantType == null)
            {
                return NotFound();
            }

            return View(restaurantType);
        }

        // GET: RestaurantTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: RestaurantTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Remarks,Name")] RestaurantType restaurantType)
        {
            if (ModelState.IsValid)
            {
                _context.Add(restaurantType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(restaurantType);
        }

        // GET: RestaurantTypes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var restaurantType = await _context.RestaurantTypes.FindAsync(id);
            if (restaurantType == null)
            {
                return NotFound();
            }
            return View(restaurantType);
        }

        // POST: RestaurantTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Remarks,Name")] RestaurantType restaurantType)
        {
            if (id != restaurantType.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(restaurantType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RestaurantTypeExists(restaurantType.Id))
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
            return View(restaurantType);
        }

        // GET: RestaurantTypes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var restaurantType = await _context.RestaurantTypes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (restaurantType == null)
            {
                return NotFound();
            }

            return View(restaurantType);
        }

        // POST: RestaurantTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var restaurantType = await _context.RestaurantTypes.FindAsync(id);
            _context.RestaurantTypes.Remove(restaurantType);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RestaurantTypeExists(int id)
        {
            return _context.RestaurantTypes.Any(e => e.Id == id);
        }
    }
}
