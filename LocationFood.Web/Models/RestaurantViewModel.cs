using LocationFood.Web.Controllers.Data.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LocationFood.Web.Models
{
    public class RestaurantViewModel : Restaurant
    {
        public int AdminRestaurantId { get; set; }

        [Required(ErrorMessage = "The field {0} is mandatory.")]
        [Display(Name = "Restaurant Type")]
        [Range(1, int.MaxValue, ErrorMessage = "You must select a restaurant type.")]
        public int RestaurantTypeId { get; set; }

        public IEnumerable<SelectListItem> RestaurantTypes { get; set; }
    }
}
