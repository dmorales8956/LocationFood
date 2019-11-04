using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LocationFood.Prism.ViewModels
{
    public class RestaurantMasterDetailPageViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;
        public RestaurantMasterDetailPageViewModel(INavigationService navigationService) : base(navigationService)
        {
            _navigationService = navigationService;
          
        }
    }
}
