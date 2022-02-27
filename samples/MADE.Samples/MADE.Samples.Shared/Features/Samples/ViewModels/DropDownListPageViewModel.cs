namespace MADE.Samples.Features.Samples.ViewModels
{
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Windows.Input;
    using CommunityToolkit.Mvvm.Input;
    using CommunityToolkit.Mvvm.Messaging;
    using MADE.Collections;
    using MADE.UI.Views.Navigation;
    using MADE.UI.Views.Navigation.ViewModels;

    public class DropDownListPageViewModel : PageViewModel
    {
        public DropDownListPageViewModel(INavigationService navigationService, IMessenger messenger)
            : base(navigationService, messenger)
        {
        }

        public ICommand SelectedItemsUpdateCommand => new RelayCommand<IEnumerable<object>>(
            selectedItems => this.OnSelectedItemsUpdated(selectedItems.Cast<string>()));

        public ObservableCollection<string> Items { get; } = new()
        {
            "Red",
            "Green",
            "Blue",
            "Cyan",
            "Magenta",
            "Yellow",
            "White"
        };

        public ObservableCollection<string> SelectedItems { get; } = new();

        private void OnSelectedItemsUpdated(IEnumerable<string> obj)
        {
            this.SelectedItems.MakeEqualTo(obj);
        }
    }
}