using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LocationFood.Web.Controllers.Data.Entities
{
    public class MenuReservation
    {
        public int Id { get; set; }

        public int Quantity { get; set; }

        public int Chair { get; set; }

        public Menu Menu { get; set; }
        public Reservation Reservation { get; set; }

    }
}
