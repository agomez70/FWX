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
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void LogIn_OnClicked(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new LoginPage());
        }

        private void SignUp_OnClicked(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new CreateAccount());
        }
    }
}