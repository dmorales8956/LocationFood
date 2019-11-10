using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LocationFood.Web.Controllers.Data.Entities
{
    public class RestaurantType
    {
        public int Id { get; set; }

        public string Remarks { get; set; }

        public ICollection<Restaurant> Restaurants { get; set; }
        public string Name { get; set; }
    }
}
