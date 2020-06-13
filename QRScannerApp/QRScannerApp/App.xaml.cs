using System;
using QRScannerApp.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace QRScannerApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new ScannerPage();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
