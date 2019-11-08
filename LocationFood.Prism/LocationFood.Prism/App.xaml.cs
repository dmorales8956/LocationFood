using Prism;
using Prism.Ioc;
using LocationFood.Prism.ViewModels;
using LocationFood.Prism.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using LocationFood.Common.Services;
using LocationFood.Common.Helpers;
using LocationFood.Common.Models;
using Newtonsoft.Json;
using System;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace LocationFood.Prism
{
    public partial class App
    {
        public App() : this(null) { }

        public App(IPlatformInitializer initializer) : base(initializer) { }

     

        protected override async void OnInitialized()
        {

            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("MTUzNjE2QDMxMzcyZTMyMmUzMFJQTXFRSnN6RXpKbzVkRktkTXpoK2R6YlNWWWlJeE9LUVE4ZGQyam1KMDQ9");
            InitializeComponent();

            var token = JsonConvert.DeserializeObject<TokenResponse>(Settings.Token);
            if (Settings.IsRemembered && token?.Expiration > DateTime.Now)
            {
                await NavigationService.NavigateAsync("/RestaurantMasterDetailPage/NavigationPage/ReservationPage");
            }
            else
            {
                await NavigationService.NavigateAsync("/NavigationPage/LoginPage");
            }
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.Register<IApiService, ApiService>();
            containerRegistry.Register<IGeolocatorService, GeolocatorService>();
            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<LoginPage, LoginPageViewModel>();
            containerRegistry.RegisterForNavigation<RegisterPage, RegisterPageViewModel>();
            containerRegistry.RegisterForNavigation<RememberPasswordPage, RememberPasswordPageViewModel>();
            containerRegistry.RegisterForNavigation<RestaurantMasterDetailPage, RestaurantMasterDetailPageViewModel>();
            containerRegistry.RegisterForNavigation<RestaurantsPage, RestaurantsPageViewModel>();
            containerRegistry.RegisterForNavigation<MapPage, MapPageViewModel>();
            containerRegistry.RegisterForNavigation<ReservationPage, ReservationPageViewModel>();
            containerRegistry.RegisterForNavigation<ChangePasswordPage, ChangePasswordPageViewModel>();
            containerRegistry.RegisterForNavigation<ProfilePage, ProfilePageViewModel>();
        }
    }
}
