using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LocationFood.Web.Controllers.Data.Entities
{
    public class AdminRestaurant
    {
        public int Id { get; set; }

        public ICollection<Restaurant> Restaurants { get; set; }

    }
}
