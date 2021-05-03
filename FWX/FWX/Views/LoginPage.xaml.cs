using FWX.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FWX.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        private void LoginButton_OnClicked(object sender, EventArgs e)
        { 
            Navigation.PushAsync(new MainMenu());
            
        }

        private void RegisterButton_OnClicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new CreateAccount());
        }
    }
}