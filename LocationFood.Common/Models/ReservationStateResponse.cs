using System;
using System.Collections.Generic;
using System.Text;

namespace LocationFood.Common.Models
{
  public  class ReservationStateResponse
    {
        public int Id { get; set; }

        public DateTime StateDate { get; set; }

        public string Reservation { get; set; }

        public string State { get; set; }

        public DateTime DateLocal => StateDate.ToLocalTime();
    }
}
