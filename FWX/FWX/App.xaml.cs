using System;
using FWX.Data;
using FWX.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: ExportFont("Roose Sally.otf", Alias = "TitleFont")]
[assembly: ExportFont("Background Echo DEMO.otf", Alias = "ButtonFont")]
[assembly: ExportFont("ALOSKA (otf).otf", Alias = "LabelFont")]
[assembly: ExportFont("Barqon.ttf", Alias = "EntryFont")]

namespace FWX
{
    public partial class App : Application
    {
        private static FWXDatabase forceDatabase;

        public static FWXDatabase ForceDatabase
        {
            get
            {
                if (forceDatabase == null)
                {
                    forceDatabase = new FWXDatabase();
                }

                return forceDatabase;
            }
        }
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage (new MainPage());
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
