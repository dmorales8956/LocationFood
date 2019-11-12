using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LocationFood.Web.Controllers.Data.Entities
{
    public class Reservation
    {
        public int Id { get; set; }

        public int Quantity { get; set; }

        [Display(Name = "Reservation Date")]
        [Required(ErrorMessage = "The field {0} is mandatory.")]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd HH:mm}", ApplyFormatInEditMode = true)]
        public DateTime ReservationDate { get; set; }

        [Display(Name = "Reservation Date")]
        [Required(ErrorMessage = "The field {0} is mandatory.")]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd HH:mm}", ApplyFormatInEditMode = true)]
        public DateTime ReservationDateLocal => ReservationDate.ToLocalTime();


        [Display(Name = "Reservation Hour")]
        [Required(ErrorMessage = "The field {0} is mandatory.")]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd HH:mm}", ApplyFormatInEditMode = true)]
        public DateTime ReservationHour { get; set; }

        [Display(Name = "Reservation Hour")]
        [Required(ErrorMessage = "The field {0} is mandatory.")]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd HH:mm}", ApplyFormatInEditMode = true)]
        public DateTime ReservationHourLocal => ReservationHour.ToLocalTime();

        public ICollection<MenuReservation> MenuReservations { get; set; }

        public Restaurant Restaurant { get; set; }

        public Customer Customer { get; set; }

        public ICollection<ReservationState> ReservationStates { get; set; }
        
    }
}
