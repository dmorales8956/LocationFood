using LocationFood.Web.Controllers.Data.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LocationFood.Web.Controllers.Data
{
    public class DataContext : IdentityDbContext<User>
    {
        public DataContext(DbContextOptions<DataContext>options):base(options)
        {

        }
        
        public DbSet<AdminRestaurant> AdminRestaurants { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Favorite> Favorites { get; set; }
        public DbSet<Manager> Managers { get; set; }
        public DbSet<Menu> Menus { get; set; }
        public DbSet<MenuReservation> MenuReservations { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<ReservationState> ReservationStates { get; set; }
        public DbSet<Restaurant> Restaurants { get; set; }
        public DbSet<RestaurantType> RestaurantTypes { get; set; }
        public DbSet<State> States { get; set; }



    }
}
