using LocationFood.Common.Models;
using LocationFood.Web.Controllers.Data;
using LocationFood.Web.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LocationFood.Web.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminRestaurantsController : ControllerBase
    {
        private readonly DataContext _dataContext;
        private readonly IUserHelper _userHelper;

        public AdminRestaurantsController(DataContext dataContext,
            IUserHelper userHelper)
        {
            _dataContext = dataContext;
            _userHelper = userHelper;
        }

        [HttpGet]
        [Route("GetRestaurants")]
        public async Task<IActionResult> GetRestaurants()
        {
            var restaurants = await _dataContext.Restaurants
                .Include(r => r.RestaurantType)
                .Include(r => r.RestaurantImages)
                .ToListAsync();

            var response = new List<RestaurantResponse>(restaurants.Select(r => new RestaurantResponse
            {
                Address = r.Address,
                Name = r.Name,
                Id = r.Id,
                FixedPhone = r.FixedPhone,
                Latitude = r.Latitude,
                Longitude = r.Longitude,
                CellPhone = r.CellPhone,
                Chair = r.Chair,
                RestaurantImages = new List<RestaurantImageResponse>(r.RestaurantImages.Select(ri => new RestaurantImageResponse
                {
                    Id = ri.Id,
                    ImageUrl = ri.ImageFullPath
                }).ToList()),
                RestaurantType = r.RestaurantType.Name,
            }).ToList());

            return Ok(response);
        }
    }
}
