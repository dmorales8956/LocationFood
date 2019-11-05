using Prism.Navigation;

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
