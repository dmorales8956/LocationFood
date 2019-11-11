using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LocationFood.Web.Controllers.Data;
using LocationFood.Web.Controllers.Data.Entities;
using LocationFood.Web.Models;
using LocationFood.Web.Helpers;

namespace LocationFood.Web.Controllers
{
    public class AdminRestaurantsController : Controller
    {
        private readonly DataContext _dataContext;
        private readonly IUserHelper _userHelper;

        public AdminRestaurantsController(DataContext dataContext,
            IUserHelper userHelper)
        {
            _dataContext = dataContext;
            _userHelper = userHelper;
        }

        // GET: AdminRestaurants
        public IActionResult Index()
        {
            return View(_dataContext.AdminRestaurants
                .Include(a => a.User)
                .Include(a => a.Restaurants)
                );
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
                .ThenInclude(r => r.RestaurantImages)
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
        public async Task<IActionResult> Create(AddUserViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await CreateUserAsync(model);
                if (user != null)
                {
                    var admin = new AdminRestaurant
                    {
                        Restaurants = new List<Restaurant>(),
                        User = user
                    };

                    _dataContext.AdminRestaurants.Add(admin);
                    await _dataContext.SaveChangesAsync();
                    return RedirectToAction("Index");
                }

                ModelState.AddModelError(string.Empty, "User with this emailalready exist");
            }
            return View(model);
        }

        private async Task<User> CreateUserAsync(AddUserViewModel model)
        {
            var user = new User
            {
                Address = model.Address,
                Document = model.Document,
                Email = model.Username,
                FirstName = model.FirstName,
                LastName = model.LastName,
                PhoneNumber = model.PhoneNumber,
                UserName = model.Username
            };

            var result = await _userHelper.AddUserAsync(user, model.Password);
            if (result.Succeeded)
            {
                user = await _userHelper.GetUserByEmailAsync(model.Username);
                await _userHelper.AddUserToRoleAsync(user, "Admin");
                return user;
            }

            return null;
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
