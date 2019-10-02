using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LocationFood.Web.Controllers.Data.Entities
{
    public class Customer
    {
        public int Id { get; set; }

        public User User { get; set; }
        public ICollection<Favorite> Favorites { get; set; }

        public ICollection<Reservation> Reservations { get; set; }
    }
}
