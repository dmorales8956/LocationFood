using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LocationFood.Common.Models
{
    public class RestaurantResponse
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string FixedPhone { get; set; }
        public string CellPhone { get; set; }

        public string Address { get; set; }

        public int Chair { get; set; }

        public string RestaurantType { get; set; }

        public double Latitude { get; set; }

        public double Longitude { get; set; }

        public ICollection<RestaurantImageResponse> RestaurantImages { get; set; }

        public string FirstImage
        {
            get
            {
                if (RestaurantImages == null || RestaurantImages.Count == 0)
                {
                    return "https://myleasing.azurewebsites.net/images/Restaurant/noImage.png";
                }

                return RestaurantImages.FirstOrDefault().ImageUrl;
            }
        }
    }
}
