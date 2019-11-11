using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace LocationFood.Web.Helpers
{
    public interface ICombosHelper
    {
        IEnumerable<SelectListItem> GetComboRestaurantTypes();
    }
}