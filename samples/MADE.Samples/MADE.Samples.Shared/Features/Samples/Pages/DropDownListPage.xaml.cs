namespace MADE.Samples.Features.Samples.Pages
{
    using CommunityToolkit.Mvvm.Messaging;
    using MADE.Samples.Features.Samples.ViewModels;
    using MADE.UI.Views.Navigation;
    using MADE.UI.Views.Navigation.Pages;
    using Microsoft.Extensions.DependencyInjection;

    public sealed partial class DropDownListPage : MvvmPage
    {
        public DropDownListPage()
        {
            this.InitializeComponent();
            this.DataContext = new DropDownListPageViewModel(
                App.Services.GetService<INavigationService>(),
                App.Services.GetService<IMessenger>());
        }

        public DropDownListPageViewModel ViewModel => this.DataContext as DropDownListPageViewModel;
    }
}
