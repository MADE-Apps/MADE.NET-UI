namespace MADE.Samples.Features.Samples.ViewModels
{
    using CommunityToolkit.Mvvm.Messaging;
    using MADE.UI.Views.Navigation;
    using MADE.UI.Views.Navigation.ViewModels;

    public class RichEditToolbarPageViewModel : PageViewModel
    {
        public RichEditToolbarPageViewModel(INavigationService navigationService, IMessenger messenger)
            : base(navigationService, messenger)
        {
        }
    }
}