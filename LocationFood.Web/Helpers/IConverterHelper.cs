using System.Threading.Tasks;
using LocationFood.Web.Controllers.Data.Entities;
using LocationFood.Web.Models;

namespace LocationFood.Web.Helpers
{
    public interface IConverterHelper
    {
        Task<Restaurant> ToRestaurantAsycn(RestaurantViewModel model, bool isNew);
    }
}