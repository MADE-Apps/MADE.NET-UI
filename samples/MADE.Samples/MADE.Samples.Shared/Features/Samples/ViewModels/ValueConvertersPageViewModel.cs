namespace MADE.Samples.Features.Samples.ViewModels
{
    using System.IO;
    using System.Net.Http;
    using System.Threading.Tasks;
    using CommunityToolkit.Mvvm.Messaging;
    using MADE.Networking.Http.Requests.Streams;
    using MADE.UI.Views.Navigation;
    using MADE.UI.Views.Navigation.ViewModels;
    using Windows.UI.Xaml.Navigation;

    public class ValueConvertersPageViewModel : PageViewModel
    {
        private byte[] imageBytes;

        public ValueConvertersPageViewModel(INavigationService navigationService, IMessenger messenger)
            : base(navigationService, messenger)
        {
        }

        public bool True => true;

        public bool False => false;

        public byte[] ImageBytes
        {
            get => this.imageBytes;
            set => this.SetProperty(ref this.imageBytes, value);
        }

        public override async void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            await this.GetImageBytesAsync();
        }

        private async Task GetImageBytesAsync()
        {
#if __WASM__
            var handler = new Uno.UI.Wasm.WasmHttpHandler();
			var httpClient = new HttpClient(handler);
#else
            var httpClient = new HttpClient();
#endif

            var imageRequest = new StreamGetNetworkRequest(httpClient, "http://placekitten.com/420/420");
            var contentStream = await imageRequest.ExecuteAsync<Stream>();
            MemoryStream ms = new MemoryStream();
            contentStream.CopyTo(ms);
            this.ImageBytes = ms.ToArray();
        }
    }
}