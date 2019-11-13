using LocationFood.Common.Helpers;
using LocationFood.Common.Models;
using LocationFood.Common.Services;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Maps;

namespace LocationFood.Prism.Views
{
    public partial class MapPage : ContentPage
    {
        private readonly IGeolocatorService _geolocatorService;
        private readonly IApiService _apiService;

        public MapPage(IGeolocatorService geolocatorService, IApiService apiService)
        {
            InitializeComponent();
            _geolocatorService = geolocatorService;
            _apiService = apiService;
            ShowRestaurantsAsync();
            MoveMapToCurrentPositionAsync();

        }
        private async void ShowRestaurantsAsync()
        {
            //Aqui consume la url de azure
            var url = App.Current.Resources["UrlAPI"].ToString();
            var token = JsonConvert.DeserializeObject<TokenResponse>(Settings.Token);


            var response = await _apiService.GetListAsync<RestaurantResponse>(
                url,
                "api",
                "/AdminRestaurants/GetRestaurants",
                "bearer",
                token.Token);

            if (!response.IsSuccess)
            {
                await App.Current.MainPage.DisplayAlert("Error", response.Message, "Accept");
                return;
            }

            var restaurants = (List<RestaurantResponse>)response.Result;

            foreach (var restaurant in restaurants)
            {
                MyMap.Pins.Add(new Pin
                {
                    Address = restaurant.Address,
                    Label = restaurant.Name,
                    Position = new Position(restaurant.Latitude, restaurant.Longitude),
                    Type = PinType.Place
                });
            }
        }
        private async void MoveMapToCurrentPositionAsync()
        {
            await _geolocatorService.GetLocationAsync();
            var position = new Position(
                _geolocatorService.Latitude,
                _geolocatorService.Longitude);
            MyMap.MoveToRegion(MapSpan.FromCenterAndRadius(
                position,
                Distance.FromKilometers(.5)));
        }
    }
}