﻿using System;
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
        private readonly DataContext _dataContext;

        public AdminRestaurantsController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        // GET: AdminRestaurants
        public IActionResult Index()
        {
            return View(_dataContext.AdminRestaurants
                .Include(a => a.User)
                .Include(a => a.Restaurants));
        }

        // GET: AdminRestaurants/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var adminRestaurant = await _dataContext.AdminRestaurants
                .Include(a => a.User)
                .Include(a => a.Restaurants)
                .FirstOrDefaultAsync(a => a.Id == id);
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
                _dataContext.Add(adminRestaurant);
                await _dataContext.SaveChangesAsync();
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

            var adminRestaurant = await _dataContext.AdminRestaurants.FindAsync(id);
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
                    _dataContext.Update(adminRestaurant);
                    await _dataContext.SaveChangesAsync();
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

            var adminRestaurant = await _dataContext.AdminRestaurants
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
            var adminRestaurant = await _dataContext.AdminRestaurants.FindAsync(id);
            _dataContext.AdminRestaurants.Remove(adminRestaurant);
            await _dataContext.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AdminRestaurantExists(int id)
        {
            return _dataContext.AdminRestaurants.Any(e => e.Id == id);
        }
    }
}
