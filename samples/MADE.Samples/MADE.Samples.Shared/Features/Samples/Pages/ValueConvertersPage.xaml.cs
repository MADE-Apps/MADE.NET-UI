namespace MADE.Samples.Features.Samples.Pages
{
    using CommunityToolkit.Mvvm.Messaging;
    using MADE.Samples.Features.Samples.ViewModels;
    using MADE.UI.Views.Navigation;
    using MADE.UI.Views.Navigation.Pages;
    using Microsoft.Extensions.DependencyInjection;

    public sealed partial class ValueConvertersPage : MvvmPage
    {
        public ValueConvertersPage()
        {
            this.InitializeComponent();
            this.DataContext = new ValueConvertersPageViewModel(
                App.Services.GetService<INavigationService>(),
                App.Services.GetService<IMessenger>());
        }

        public ValueConvertersPageViewModel ViewModel => this.DataContext as ValueConvertersPageViewModel;
    }
}