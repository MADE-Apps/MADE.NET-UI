namespace MADE.Samples.Features.Samples.Pages
{
    using CommunityToolkit.Mvvm.Messaging;
    using MADE.Samples.Features.Samples.ViewModels;
    using MADE.UI.Views.Navigation;
    using MADE.UI.Views.Navigation.Pages;
    using Microsoft.Extensions.DependencyInjection;

    public sealed partial class ChipBoxPage : MvvmPage
    {
        public ChipBoxPage()
        {
            this.InitializeComponent();
            this.DataContext = new ChipBoxPageViewModel(
                App.Services.GetService<INavigationService>(),
                App.Services.GetService<IMessenger>());
        }

        public ChipBoxPageViewModel ViewModel => this.DataContext as ChipBoxPageViewModel;
    }
}
