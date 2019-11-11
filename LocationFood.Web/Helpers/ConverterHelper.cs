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
        private readonly ICombosHelper _combosHelper;

        public ConverterHelper(DataContext dataContext,
            ICombosHelper combosHelper)
        {
            _dataContext = dataContext;
            _combosHelper = combosHelper;
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

        public RestaurantViewModel ToRestaurantViewModel(Restaurant restaurant)
        {
            return new RestaurantViewModel
            {
                Name = restaurant.Name,
                FixedPhone = restaurant.FixedPhone,
                CellPhone = restaurant.CellPhone,
                Address = restaurant.Address,
                Chair = restaurant.Chair,
                Latitude = restaurant.Latitude,
                Longitude = restaurant.Longitude,
                Id = restaurant.Id,
                AdminRestaurant = restaurant.AdminRestaurant,
                RestaurantImages = restaurant.RestaurantImages,
                Favorites = restaurant.Favorites,
                Menus = restaurant.Menus,
                Reservations = restaurant.Reservations,
                AdminRestaurantId = restaurant.AdminRestaurant.Id,
                RestaurantTypeId = restaurant.RestaurantType.Id,
                RestaurantTypes = _combosHelper.GetComboRestaurantTypes()

            };
        }
    }
}
