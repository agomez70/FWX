using System;
using FWX.Data;
using FWX.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

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

            MainPage = new NavigationPage (new LoginPage());
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
