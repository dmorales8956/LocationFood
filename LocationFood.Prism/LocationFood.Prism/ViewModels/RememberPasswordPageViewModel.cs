using Prism.Navigation;

namespace LocationFood.Prism.ViewModels
{
    public class RememberPasswordPageViewModel : ViewModelBase
    {
        public RememberPasswordPageViewModel(INavigationService navigationService) : base(navigationService)
        {
            Title = "Remember Password";
        }
    }
}
