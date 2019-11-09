using LocationFood.Common.Models;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace LocationFood.Prism.ViewModels
{
    public class RestaurantMasterDetailPageViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;
        public RestaurantMasterDetailPageViewModel(
            INavigationService navigationService) : base(navigationService)
        {
            _navigationService = navigationService;
            LoadMenus();

        }
        public ObservableCollection<MenuItemViewModel> Menus { get; set; }

        private void LoadMenus()
        {
            var menus = new List<Menu>
            {
                new Menu
                {
                    Icon = "ic_action_home",
                    PageName = "RestaurantsPage",
                    Title = "Restaurants"
                },

                new Menu
                {
                    Icon = "ic_action_restaurant_menu",
                    PageName = "ReservationPage",
                    Title = "Reservation"
                },

                new Menu
                {
                    Icon = "ic_action_person",
                    PageName = "ProfilePage",
                    Title = "Perfil"
                },

                new Menu
                {
                    Icon = "ic_action_map",
                    PageName = "MapPage",
                    Title = "Map"
                },

                new Menu
                {
                    Icon = "ic_action_exit_to_app",
                    PageName = "LoginPage",
                    Title = "Logout"
                }
            };

            Menus = new ObservableCollection<MenuItemViewModel>(
                menus.Select(m => new MenuItemViewModel(_navigationService)
                {
                    Icon = m.Icon,
                    PageName = m.PageName,
                    Title = m.Title
                }).ToList());
        }
    }
}
