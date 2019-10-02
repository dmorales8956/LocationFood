using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LocationFood.Web.Controllers.Data.Entities
{
    public class State
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<ReservationState> ReservationStates { get; set; }
    }
}
