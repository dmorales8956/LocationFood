using LocationFood.Web.Controllers.Data;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LocationFood.Web.Helpers
{
    public class CombosHelper : ICombosHelper
    {
        private readonly DataContext _dataContext;

        public CombosHelper(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public IEnumerable<SelectListItem> GetComboCustomers()
        {
            var list = _dataContext.Customers.Select(c => new SelectListItem
            {
                Text = c.User.FullName,
                Value = $"{c.Id}"
            })
                .OrderBy(rt => rt.Text)
                .ToList();

            list.Insert(0, new SelectListItem
            {
                Text = "(Select a customer...",
                Value = "0"
            });

            return list;
        }

        public IEnumerable<SelectListItem> GetComboRestaurantTypes()
        {
            var list = _dataContext.RestaurantTypes.Select(rt => new SelectListItem
            {
                Text = rt.Name,
                Value = $"{rt.Id}"
            })
                .OrderBy(rt => rt.Text)
                .ToList();

            list.Insert(0, new SelectListItem
            {
                Text = "(Select a restaurant type...",
                Value = "0"
            });

            return list;
        }
    }
}
