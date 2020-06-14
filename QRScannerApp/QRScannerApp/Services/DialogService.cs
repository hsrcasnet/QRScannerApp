using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace QRScannerApp.Services
{
    public class DialogService : IDialogService
    {
        private readonly Func<string, string, string, Task> displayAlertDelegate;

        public DialogService(Func<string, string, string, Task> displayAlertDelegate)
        {
            this.displayAlertDelegate = displayAlertDelegate;
        }

        public Task ShowAlert(string title, string message, string cancel)
        {
            return Device.InvokeOnMainThreadAsync(() => displayAlertDelegate(title, message, cancel));
        }
    }
}