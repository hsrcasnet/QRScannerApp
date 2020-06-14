using System.Threading.Tasks;

namespace QRScannerApp.Services
{
    public interface IDialogService
    {
        Task ShowAlert(string title, string message, string cancel);
    }
}