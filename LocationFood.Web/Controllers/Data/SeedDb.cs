using LocationFood.Web.Controllers.Data;
using LocationFood.Web.Controllers.Data.Entities;
using LocationFood.Web.Helpers;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace LocationFood.Web.Data
{
    public class SeedDb
    {
        private readonly DataContext _dataContext;
        private readonly IUserHelper _userHelper;

        public SeedDb(
            DataContext context,
            IUserHelper userHelper)
        {
            _dataContext = context;
            _userHelper = userHelper;
        }

        public async Task SeedAsync()
        {
            await _dataContext.Database.EnsureCreatedAsync();
            await CheckRoles();
            var admin = await CheckUserAsync("1010", "Diana", "Morales", "diana@gmail.com", "310 634 2789", "Calle Luna Calle Sol", "Admin");
            var customer = await CheckUserAsync("2020", "Bresney", "Quintana", "bresney@hotmail.com", "320 634 4847", "Calle Luna Calle Sol", "Customer");
            var manager = await CheckUserAsync("3030", "Bresney", "Quintana", "bresney11@hotmail.com", "320 634 4847", "Calle Luna Calle Sol", "Manager");
            await CheckManagerAsync(manager);
            await CheckAdminsAsync(admin);
            await CheckCustomerAsync(customer);
        }

        private async Task CheckCustomerAsync(User user)
        {
            if (!_dataContext.Customers.Any())
            {
                _dataContext.Customers.Add(new Customer { User = user });
                await _dataContext.SaveChangesAsync();
            }
        }

        private async Task CheckAdminsAsync(User user)
        {

            if (!_dataContext.AdminRestaurants.Any())
            {
                _dataContext.AdminRestaurants.Add(new AdminRestaurant { User = user });
                await _dataContext.SaveChangesAsync();
            }
        }

        private async Task CheckRoles()
        {
            await _userHelper.CheckRoleAsync("Admin");
            await _userHelper.CheckRoleAsync("Customer");
            await _userHelper.CheckRoleAsync("Manager");
        }

        private async Task<User> CheckUserAsync(
            string document,
            string firstName,
            string lastName,
            string email,
            string phone,
            string address,
            string role)
        {
            var user = await _userHelper.GetUserByEmailAsync(email);
            if (user == null)
            {
                user = new User
                {
                    FirstName = firstName,
                    LastName = lastName,
                    Email = email,
                    UserName = email,
                    PhoneNumber = phone,
                    Address = address,
                    Document = document
                };

                await _userHelper.AddUserAsync(user, "123456");
                await _userHelper.AddUserToRoleAsync(user, role);
            }

            return user;
        }


        private async Task checkRestaurantsTypesAsync()
        {
            if (!_dataContext.RestaurantTypes.Any())
            {
                _dataContext.RestaurantTypes.Add(new RestaurantType { Name = "Buffet" });
                _dataContext.RestaurantTypes.Add(new RestaurantType { Name = " Fast Casual" });
                _dataContext.RestaurantTypes.Add(new RestaurantType { Name = " Fast Food" });
                await _dataContext.SaveChangesAsync();
            }
        }
        private async Task CheckManagerAsync(User user)
        {
            if (!_dataContext.Managers.Any())
            {
                _dataContext.Managers.Add(new Manager { User = user });
                await _dataContext.SaveChangesAsync();
            }
        }

    }
}