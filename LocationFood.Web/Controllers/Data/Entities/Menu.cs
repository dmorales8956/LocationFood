using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LocationFood.Web.Controllers.Data.Entities
{
    public class Menu
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Remarks { get; set; }

        public decimal Price { get; set; }

        public Restaurant Restaurant { get; set; }

        public ICollection<MenuReservation> MenuReservations { get; set; }
    }
}
