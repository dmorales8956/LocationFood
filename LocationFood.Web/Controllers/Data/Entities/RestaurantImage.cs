using System.ComponentModel.DataAnnotations;

namespace LocationFood.Web.Controllers.Data.Entities
{
    public class RestaurantImage
    {
        public int Id { get; set; }

        [Display(Name = "Image")]
        public string ImageUrl { get; set; }

        public string ImageFullPath => string.IsNullOrEmpty(ImageUrl)
            ? null
            : $"https://locationfood.azurewebsites.net{ImageUrl.Substring(1)}";

        public Restaurant Restaurant { get; set; }
    }
}
