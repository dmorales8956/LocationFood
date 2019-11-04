using System;
using System.Collections.Generic;
using System.Text;

namespace LocationFood.Common.Models
{
   public  class ReservationResponse
    {
        public int Id { get; set; }

        public int Quantity { get; set; }

        public DateTime ReservationDate { get; set; }

        public DateTime ReservationHour { get; set; }

      
        public string RestaurantType { get; set; }

        public ICollection<ReservationStateResponse> ReservationStates { get; set; }
    }
}
