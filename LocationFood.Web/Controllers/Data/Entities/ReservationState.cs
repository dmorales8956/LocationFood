using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LocationFood.Web.Controllers.Data.Entities
{
    public class ReservationState
    {
        public int Id { get; set; }


        [Display(Name = "State Date")]
        [Required(ErrorMessage = "The field {0} is mandatory.")]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        public DateTime StateDate { get; set; }

        [Display(Name = "State Date")]
        [Required(ErrorMessage = "The field {0} is mandatory.")]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        public DateTime StateDateLocal => StateDate.ToLocalTime();


        [Display(Name = "State Hour")]
        [Required(ErrorMessage = "The field {0} is mandatory.")]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        public DateTime StateHour { get; set; }

        [Display(Name = "State Hour")]
        [Required(ErrorMessage = "The field {0} is mandatory.")]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        public DateTime StateHourLocal => StateHour.ToLocalTime();

        public Reservation Reservation { get; set; }

        public State State { get; set; }
    }
}
