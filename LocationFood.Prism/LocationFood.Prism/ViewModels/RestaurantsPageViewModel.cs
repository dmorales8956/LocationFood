using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LocationFood.Prism.ViewModels
{
    public class RestaurantsPageViewModel : ViewModelBase
    {
        public RestaurantsPageViewModel(INavigationService navigationService) : base(navigationService)
        {
            Title = "Restaurants";
        }
    }
}
