using System.Collections.Generic;
using System.Windows.Input;
using QRScannerApp.Services;
using Xamarin.Forms;
using ZXing;
using ZXing.Mobile;

namespace QRScannerApp.ViewModels
{
    public class ScannerViewModel : ViewModelBase
    {
        private bool isScanning;
        private bool isAnalyzing;
        private readonly IDialogService dialogService;

        public ScannerViewModel(IDialogService dialogService)
        {
            this.dialogService = dialogService;

            this.ScanResultCommand = new Command<object>((r) => this.OnScanResult(r));
            this.Options = new MobileBarcodeScanningOptions
            {
                PossibleFormats = new List<BarcodeFormat> { BarcodeFormat.QR_CODE },
                //DelayBetweenAnalyzingFrames = 150, // Default value: 150
                //DelayBetweenContinuousScans = 1000, // Default value: 1000
            };

            this.IsScanning = true;
            this.IsAnalyzing = true;
        }

        private async void OnScanResult(object result)
        {
            this.IsAnalyzing = false;
            this.IsScanning = false;

            await this.dialogService.ShowAlert("Barcode found", $"{result}", "OK cool");

            this.IsAnalyzing = true;
            this.IsScanning = true;
        }

        public bool IsScanning
        {
            get => this.isScanning;
            private set
            {
                this.isScanning = value;
                this.OnPropertyChanged(nameof(this.IsScanning));
            }
        }


        public bool IsAnalyzing
        {
            get => this.isAnalyzing;
            private set
            {
                this.isAnalyzing = value;
                this.OnPropertyChanged(nameof(IsAnalyzing));
            }
        }

        public ICommand ScanResultCommand { get; set; }

        public MobileBarcodeScanningOptions Options { get; }
    }
}
