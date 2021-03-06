namespace MADE.Samples.Features.Home.ViewModels
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Windows.Input;
    using CommunityToolkit.Mvvm.Input;
    using CommunityToolkit.Mvvm.Messaging;
    using MADE.Collections;
    using MADE.Data.Validation.Extensions;
    using MADE.Foundation.Platform;
    using MADE.Samples.Features.Samples.Data;
    using MADE.Samples.Features.Samples.Pages;
    using MADE.UI.ViewManagement;
    using MADE.UI.Views.Navigation;
    using MADE.UI.Views.Navigation.ViewModels;

    public class MainPageViewModel : PageViewModel
    {
        public MainPageViewModel(INavigationService navigationService, IMessenger messenger)
            : base(navigationService, messenger)
        {
        }

        public ICommand NavigateToSampleCommand => new RelayCommand<Sample>(NavigateToSample);

        public ICollection<SampleGroup> SampleGroups { get; } = GetSampleGroups();

        public ICollection<Sample> Samples => SampleGroups.SelectMany(x => x.Samples).ToList();

        private static ICollection<SampleGroup> GetSampleGroups()
        {
            var controls = new SampleGroup
            {
                Name = "Controls",
                Samples =
                {
                    new Sample(
                        "ChipBox",
                        typeof(ChipBoxPage),
                        "/Features/Samples/Assets/ChipBox/ChipBox.png"),
                    new Sample(
                        "DropDownList",
                        typeof(DropDownListPage),
                        "/Features/Samples/Assets/DropDownList/DropDownList.png"),
                    new Sample(
                        "FilePicker",
                        typeof(FilePickerPage),
                        "/Features/Samples/Assets/FilePicker/FilePicker.png"),
                    new Sample(
                        "InputValidator",
                        typeof(InputValidatorPage),
                        "/Features/Samples/Assets/InputValidator/InputValidator.png"),
                }
            };

#if WINDOWS_UWP
            AddPlatformSpecificSample(
                controls,
                new Sample(
                    "RichEditToolbar",
                    typeof(RichEditToolbarPage),
                    "/Features/Samples/Assets/RichEditToolbar/RichEditToolbar.png"));
#endif

            var helpers = new SampleGroup
            {
                Name = "Helpers",
                Samples =
                {
                    new Sample(
                        "AppDialog",
                        typeof(AppDialogPage),
                        "/Features/Samples/Assets/AppDialog/AppDialog.png"),
                    new Sample(
                        "Value Converters",
                        typeof(ValueConvertersPage),
                        "/Features/Samples/Assets/ValueConverters/ValueConverters.png")
                }
            };

            if (PlatformApiHelper.IsTypeSupported(typeof(WindowManager)))
            {
                AddPlatformSpecificSample(
                    helpers,
                    new Sample(
                        "WindowManager",
                        typeof(WindowManagerPage),
                        "/Features/Samples/Assets/WindowManager/WindowManager.png"));
            }

            var list = new List<SampleGroup> {controls, helpers};

            return list;
        }

        private static void AddPlatformSpecificSample(SampleGroup sampleGroup, Sample sample)
        {
            sampleGroup.Samples.InsertAtPotentialIndex(
                sample,
                (item, compare) => compare.Name.IsLessThanOrEqualTo(item.Name));
        }

        private void NavigateToSample(Sample sample)
        {
            NavigationService.NavigateTo(sample.Page);
        }
    }
}