using LocationFood.Web.Controllers.Data.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LocationFood.Web.Models
{
    public class ReservationViewModel : Reservation
    {
        public int RestaurantId { get; set; }

        [Required(ErrorMessage = "The field {0} is mandatory.")]
        [Display(Name = "Customer")]
        [Range(1, int.MaxValue, ErrorMessage = "You must select a customer.")]
        public int customerId { get; set; }

        public IEnumerable<SelectListItem> Customers { get; set; }
    }
}
