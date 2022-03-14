namespace MADE.Samples.Features.Samples.Pages
{
    using CommunityToolkit.Mvvm.Messaging;
    using MADE.Samples.Features.Samples.ViewModels;
    using MADE.UI.Views.Navigation;
    using MADE.UI.Views.Navigation.Pages;
    using Microsoft.Extensions.DependencyInjection;

    public sealed partial class RichEditToolbarPage : MvvmPage
    {
        public RichEditToolbarPage()
        {
            this.InitializeComponent();
            this.DataContext = new RichEditToolbarPageViewModel(
                App.Services.GetService<INavigationService>(),
                App.Services.GetService<IMessenger>());

#if WINDOWS_UWP
            this.CustomRichEditToolbarControl.TargetRichEditBox = this.CustomRichEditBox;
#endif
        }

        public RichEditToolbarPageViewModel ViewModel => this.DataContext as RichEditToolbarPageViewModel;
    }
}
