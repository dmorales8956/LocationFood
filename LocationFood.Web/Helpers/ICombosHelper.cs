using System.Collections.Generic;
using LocationFood.Web.Controllers.Data.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace LocationFood.Web.Helpers
{
    public interface ICombosHelper
    {
        IEnumerable<SelectListItem> GetComboRestaurantTypes();
        IEnumerable<SelectListItem> GetComboCustomers();
    }
}