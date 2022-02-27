namespace MADE.Samples.Features.Samples.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Windows.Input;
    using CommunityToolkit.Mvvm.Input;
    using CommunityToolkit.Mvvm.Messaging;
    using MADE.Collections;
    using MADE.UI.Controls;
    using MADE.UI.Views.Navigation;
    using MADE.UI.Views.Navigation.ViewModels;

    public class ChipBoxPageViewModel : PageViewModel
    {
        private static readonly IList<string> Places = new List<string>
        {
            "Austria",
            "Belgium",
            "Bulgaria",
            "Croatia",
            "Cyprus",
            "Czechia",
            "Denmark",
            "Estonia",
            "Finland",
            "France",
            "Germany",
            "Greece",
            "Hungary",
            "Ireland",
            "Italy",
            "Latvia",
            "Lithuania",
            "Luxembourg",
            "Malta",
            "Netherlands",
            "Poland",
            "Portugal",
            "Romania",
            "Slovakia",
            "Slovenia",
            "Spain",
            "Sweden"
        };

        public ChipBoxPageViewModel(INavigationService navigationService, IMessenger messenger)
                : base(navigationService, messenger)
        {
        }

        public ICommand SuggestionTextChangeCommand => new RelayCommand<string>(this.OnSuggestionTextChanged);

        public ObservableCollection<ChipItem> SelectedChips { get; } = new()
        {
            new ChipItem("United Kingdom")
        };

        public ObservableCollection<string> ChipSuggestions { get; } = new(Places);

        private void OnSuggestionTextChanged(string obj)
        {
            ChipSuggestions.MakeEqualTo(Places.Where(x => x.Contains(obj, StringComparison.CurrentCultureIgnoreCase)));
        }
    }
}