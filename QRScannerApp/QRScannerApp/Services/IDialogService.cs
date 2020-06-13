namespace QRScannerApp.Services
{
    public interface IDialogService
    {
        void ShowAlert(string title, string message, string cancel);
    }
}