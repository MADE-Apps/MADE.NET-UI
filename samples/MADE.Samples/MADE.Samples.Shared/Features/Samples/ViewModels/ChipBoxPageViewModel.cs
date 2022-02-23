namespace MADE.Samples.Features.Samples.ViewModels
{
    using CommunityToolkit.Mvvm.Messaging;
    using MADE.UI.Controls;
    using MADE.UI.Views.Navigation;
    using MADE.UI.Views.Navigation.ViewModels;

    public class ChipBoxPageViewModel : PageViewModel
    {
        public ChipBoxPageViewModel(INavigationService navigationService, IMessenger messenger)
            : base(navigationService, messenger)
        {
        }
    }
}