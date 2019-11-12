using LocationFood.Web.Controllers.Data.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LocationFood.Web.Models
{
    public class RestaurantImageViewModel : RestaurantImage
    {
        [Display(Name = "Image")]
        public IFormFile ImageFile { get; set; }
    }
}
