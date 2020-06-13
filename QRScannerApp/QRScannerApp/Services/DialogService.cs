using System;
using Xamarin.Forms;

namespace QRScannerApp.Services
{
    public class DialogService : IDialogService
    {
        private readonly Action<string, string, string> displayAlertDelegate;

        public DialogService(Action<string, string, string> displayAlertDelegate)
        {
            this.displayAlertDelegate = displayAlertDelegate;
        }

        public void ShowAlert(string title, string message, string cancel)
        {
            Device.BeginInvokeOnMainThread(() => displayAlertDelegate(title, message, cancel));
        }
    }
}