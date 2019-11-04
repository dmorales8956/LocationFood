using LocationFood.Web.Controllers.Data;
using LocationFood.Web.Controllers.Data.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace LocationFood.Web.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestaurantTypesController : ControllerBase
    {
        private readonly DataContext _context;

        public RestaurantTypesController(DataContext context)
        {
            _context = context;
        }

        // GET: api/RestaurantTypes
        [HttpGet]
        public IEnumerable<RestaurantType> GetRestaurantTypes()
        {
            return _context.RestaurantTypes;
        }
    }
}