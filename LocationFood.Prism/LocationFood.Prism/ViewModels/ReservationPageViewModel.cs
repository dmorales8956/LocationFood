using Prism.Navigation;

namespace LocationFood.Prism.ViewModels
{
    public class ReservationPageViewModel : ViewModelBase
    {
        public ReservationPageViewModel(INavigationService navigationService) : base(navigationService)
        {
            Title = "Reservation";
        }
    }
}
