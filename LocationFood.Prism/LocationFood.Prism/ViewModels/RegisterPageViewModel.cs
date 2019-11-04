using Prism.Navigation;

namespace LocationFood.Prism.ViewModels
{
    public class RegisterPageViewModel : ViewModelBase
    {
        public RegisterPageViewModel(INavigationService navigationService) : base(navigationService)
        {
            Title = "Register new user";
        }
    }
}
