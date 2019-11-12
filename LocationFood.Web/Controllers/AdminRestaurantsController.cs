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
        private readonly IMailHelper _mailHelper;
        private readonly ICombosHelper _combosHelper;
        private readonly IConverterHelper _converterHelper;

        public AdminRestaurantsController(DataContext dataContext,
            IUserHelper userHelper,
            IMailHelper mailHelper,
            ICombosHelper combosHelper,
            IConverterHelper converterHelper)
        {
            _dataContext = dataContext;
            _userHelper = userHelper;
            _mailHelper = mailHelper;
            _combosHelper = combosHelper;
            _converterHelper = converterHelper;
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

                    var myToken = await _userHelper.GenerateEmailConfirmationTokenAsync(user);
                    var tokenLink = Url.Action("ConfirmEmail", "Account", new
                    {
                        userid = user.Id,
                        token = myToken
                    }, protocol: HttpContext.Request.Scheme);

                    _mailHelper.SendMail(model.Username, "Email confirmation",
                        $"<table style = 'max-width: 600px; padding: 10px; margin:0 auto; border-collapse: collapse;'>" +
                        $"  <tr>" +
                        $"    <td style = 'background-color: #34495e; text-align: center; padding: 0'>" +
                        $"       <a href = '' >" +
                        $"         <img width = '20%' style = 'display:block; margin: 1.5% 3%' src= ''>" +
                        $"       </a>" +
                        $"  </td>" +
                        $"  </tr>" +
                        $"  <tr>" +
                        $"  <td style = 'padding: 0'>" +
                        $"     <img style = 'padding: 0; display: block' src = '' width = '100%'>" +
                        $"  </td>" +
                        $"</tr>" +
                        $"<tr>" +
                        $" <td style = 'background-color: #ecf0f1'>" +
                        $"      <div style = 'color: #34495e; margin: 4% 10% 2%; text-align: justify;font-family: sans-serif'>" +
                        $"            <h1 style = 'color: #e67e22; margin: 0 0 7px' > Hola </h1>" +
                        $"                    <p style = 'margin: 2px; font-size: 15px'>" +
                        $"                      La mejor página  Especializada en ofertar servicios alimenticios<br>" +
                        $"                      ofreciendo las recetas mas deliciosas en diferentes tipos de restaurantes y en el momento oportuno....<br>" +
                        $"                      Entre los tipos de restaurantes  tenemos:</p>" +
                        $"      <ul style = 'font-size: 15px;  margin: 10px 0'>" +
                        $"        <li> Fast Casual.</li>" +
                        $"        <li> Buffet.</li>" +
                        $"        <li>  Fast Food.</li>" +
                        $"      </ul>" +
                        $"  <div style = 'width: 100%;margin:20px 0; display: inline-block;text-align: center'>" +
                        $"    <img style = 'padding: 0; width: 200px; margin: 5px' src = 'https://veterinarianuske.com/wp-content/uploads/2018/07/tarjetas.png'>" +
                        $"  </div>" +
                        $"  <div style = 'width: 100%; text-align: center'>" +
                        $"    <h2 style = 'color: #e67e22; margin: 0 0 7px' >Email Confirmation </h2>" +
                        $"    " +

                        $"    <a style ='text-decoration: none; border-radius: 5px; padding: 11px 23px; color: white; background-color: #3498db' href = \"{tokenLink}\">Confirm Email</a>" +
                        $"    <p style = 'color: #b3b3b3; font-size: 12px; text-align: center;margin: 30px 0 0' > LocationFood  2019 </p>" +
                        $"  </div>" +
                        $" </td >" +
                        $"</tr>" +
                        $"</table>");
                    ViewBag.Message = "The instructions to allow your user has been sent to email.";

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

        public async Task<IActionResult> AddRestaurant(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var admin = await _dataContext.AdminRestaurants.FindAsync(id);
            if (admin == null)
            {
                return NotFound();
            }

            var model = new RestaurantViewModel
            {
                AdminRestaurantId = admin.Id,
                RestaurantTypes = _combosHelper.GetComboRestaurantTypes()
            };

            return View(model);
        }

        public async Task<IActionResult> EditRestaurant(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var restaurant = await _dataContext.Restaurants
                .Include(r => r.AdminRestaurant)
                .Include(r => r.RestaurantType)
                .FirstOrDefaultAsync(r => r.Id == id);
            if (restaurant == null)
            {
                return NotFound();
            }

            var model = _converterHelper.ToRestaurantViewModel(restaurant);


            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AddRestaurant(RestaurantViewModel model)
        {
            if (ModelState.IsValid)
            {
                var restaurant = await _converterHelper.ToRestaurantAsycn(model, true);
                _dataContext.Restaurants.Add(restaurant);
                await _dataContext.SaveChangesAsync();
                return RedirectToAction($"Details/{model.AdminRestaurantId}");
            }
            
            return View(model);

        }

        [HttpPost]
        public async Task<IActionResult> EditRestaurant(RestaurantViewModel model)
        {
            if (ModelState.IsValid)
            {
                var restaurant = await _converterHelper.ToRestaurantAsycn(model, false);
                _dataContext.Restaurants.Update(restaurant);
                await _dataContext.SaveChangesAsync();
                return RedirectToAction($"Details/{model.AdminRestaurantId}");
            }

            return View(model);

        }

        public async Task<IActionResult> DetailsRestaurant(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var restaurant = await _dataContext.Restaurants
                .Include(a => a.AdminRestaurant)
                .ThenInclude(a => a.User)
                //.Include(m => m.Menus) 
                //.Include(f => f.Favorites)
                //.Include(re => re.Reservations)
                .Include(a => a.RestaurantType)
                .Include(r => r.RestaurantImages)
                .FirstOrDefaultAsync(r => r.Id == id);
            if (restaurant == null)
            {
                return NotFound();
            }

            return View(restaurant);
        }


    }
}
