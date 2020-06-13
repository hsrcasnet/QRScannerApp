using QRScannerApp.Services;
using QRScannerApp.ViewModels;
using Xamarin.Forms;

namespace QRScannerApp.Views
{
    public partial class ScannerPage : ContentPage
    {
        public ScannerPage()
        {
            InitializeComponent();

            var dialogService = new DialogService((title, msg, cancel) => this.DisplayAlert(title, msg, cancel));
            BindingContext = new ScannerViewModel(dialogService);

            
        }
    }
}
