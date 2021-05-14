using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FWX.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FWX.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainMenu : ContentPage
    {
        public MainMenu()
        {
            InitializeComponent();
        }


        private void Tracker_OnClicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Tracking());
        }

        private void WorkoutList_OnClicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new WorkoutList());
        }
        private void LogOut_OnClicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new MainPage());
        }
    }
}