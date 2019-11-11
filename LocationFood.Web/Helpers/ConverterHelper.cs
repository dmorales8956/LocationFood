using LocationFood.Web.Controllers.Data;
using LocationFood.Web.Controllers.Data.Entities;
using LocationFood.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LocationFood.Web.Helpers
{
    public class ConverterHelper : IConverterHelper
    {
        private readonly DataContext _dataContext;

        public ConverterHelper(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public async Task<Restaurant> ToRestaurantAsycn(RestaurantViewModel model, bool isNew)
        {
            return new Restaurant
            {
                Name = model.Name,
                FixedPhone = model.FixedPhone,
                CellPhone = model.CellPhone,
                Address = model.Address,
                Chair = model.Chair,
                Latitude = model.Latitude,
                Longitude = model.Longitude,
                Id = isNew ? 0 : model.Id,
                AdminRestaurant = await _dataContext.AdminRestaurants.FindAsync(model.AdminRestaurantId),
                RestaurantImages = isNew ? new List<RestaurantImage>() : model.RestaurantImages,
                RestaurantType = await _dataContext.RestaurantTypes.FindAsync(model.RestaurantTypeId),
                Favorites = isNew ? new List<Favorite>() : model.Favorites,
                Menus = isNew ? new List<Menu>() : model.Menus,
                Reservations = isNew ? new List<Reservation>() : model.Reservations


            };
        }
    }
}
