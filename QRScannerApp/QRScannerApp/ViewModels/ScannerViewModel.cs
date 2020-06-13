using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Input;
using QRScannerApp.Services;
using Xamarin.Forms;
using ZXing;
using ZXing.Mobile;

namespace QRScannerApp.ViewModels
{
    public class ScannerViewModel : INotifyPropertyChanged
    {
        private bool isScanning;
        private bool isAnalyzing;
        private readonly IDialogService dialogService;

        public event PropertyChangedEventHandler PropertyChanged;

        public ScannerViewModel(IDialogService dialogService)
        {
            this.dialogService = dialogService;

            this.ScanResultCommand = new Command<object>((r) => this.OnScanResult(r));
            this.Options = new MobileBarcodeScanningOptions
            {
                PossibleFormats = new List<BarcodeFormat> { BarcodeFormat.QR_CODE },
                //DelayBetweenAnalyzingFrames = 2000,
            };

            this.IsScanning = true;
            this.IsAnalyzing = true;
        }

        private void OnScanResult(object result)
        {
            this.IsAnalyzing = false;
            this.IsScanning = false;

            dialogService.ShowAlert("Barcode found", $"{result}", "OK, cool");
        }

        public bool IsScanning
        {
            get => isScanning;
            private set
            {
                isScanning = value;
                OnPropertyChanged(nameof(IsScanning));
            }
        }


        public bool IsAnalyzing
        {
            get => isAnalyzing;
            private set
            {
                isAnalyzing = value;
                OnPropertyChanged(nameof(IsAnalyzing));
            }
        }

        public ICommand ScanResultCommand { get; set; }

        public MobileBarcodeScanningOptions Options { get; }

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
