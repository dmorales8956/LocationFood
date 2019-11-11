using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LocationFood.Web.Controllers.Data.Entities
{
    public class Restaurant
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        [MaxLength(20)]
        public string FixedPhone { get; set; }
        [MaxLength(20)]
        public string  CellPhone { get; set; }

        [MaxLength(100)]
        public string  Address{ get; set; }

        public int  Chair { get; set; }

        [DisplayFormat(DataFormatString = "{0:N6}")]
        public double Latitude { get; set; }

        [DisplayFormat(DataFormatString = "{0:N6}")]
        public double Longitude { get; set; }

        public AdminRestaurant AdminRestaurant { get; set; }

        public ICollection<Favorite> Favorites { get; set; }

        public RestaurantType RestaurantType { get; set; }

        public ICollection<Menu> Menus { get; set; }

        public ICollection<Reservation> Reservations { get; set; }
        public ICollection<RestaurantImage> RestaurantImages { get; set; }


        public string FirstImage
        {
            get
            {
                if (RestaurantImages == null || RestaurantImages.Count == 0)
                {
                    return "https://locationfood.azurewebsites.net/images/Restaurants/noImage.png";
                }

                return RestaurantImages.FirstOrDefault().ImageUrl;
            }
        }

    }
}
