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
           
          
            InitializeComponent();

            var token = JsonConvert.DeserializeObject<TokenResponse>(Settings.Token);
            if (Settings.IsRemembered && token?.Expiration > DateTime.Now)
            {
                await NavigationService.NavigateAsync("/RestaurantMasterDetailPage/NavigationPage/RestaurantsPage");
            }
            else
            {
                await NavigationService.NavigateAsync("/NavigationPage/LoginPage");
            }
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.Register<IApiService, ApiService>();
            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<LoginPage, LoginPageViewModel>();
            containerRegistry.RegisterForNavigation<RegisterPage, RegisterPageViewModel>();
            containerRegistry.RegisterForNavigation<RegisterPage, RegisterPageViewModel>();
            containerRegistry.RegisterForNavigation<RememberPasswordPage, RememberPasswordPageViewModel>();

            containerRegistry.RegisterForNavigation<RestaurantMasterDetailPage, RestaurantMasterDetailPageViewModel>();
            containerRegistry.RegisterForNavigation<RestaurantsPage, RestaurantsPageViewModel>();
        }
    }
}
