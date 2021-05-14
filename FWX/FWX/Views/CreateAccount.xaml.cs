using System;
using FWX.Data;
using System.Diagnostics;
using Android.Service.Notification;
using FWX.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FWX.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CreateAccount : ContentPage//, Behavior<Entry>
    {
        private User user = new User();
        private FWXDatabase database = new FWXDatabase();

        public CreateAccount()
        {
            InitializeComponent();
            emailEntry.ReturnCommand = new Command(() => passwordEntry.Focus());
            passwordEntry.ReturnCommand = new Command(() => confirmPasswordEntry.Focus());
        }

        private void SignUpValidation_OnClicked(object sender, EventArgs e)
        {
            if ((string.IsNullOrWhiteSpace(emailEntry.Text)) ||
                (string.IsNullOrWhiteSpace(passwordEntry.Text)) ||
                (string.IsNullOrEmpty(emailEntry.Text)) ||
                (string.IsNullOrEmpty(passwordEntry.Text)))
            {
                DisplayAlert("Enter Data", "Enter Valid Data", "OK");
            }
            else if (!string.Equals(passwordEntry.Text, confirmPasswordEntry.Text))
            {
                {
                    warningLabel.Text = "Enter the same password";
                    passwordEntry.Text = string.Empty;
                    confirmPasswordEntry.Text = string.Empty;
                    warningLabel.TextColor = Color.DarkRed;
                    warningLabel.IsVisible = true;
                    warningLabel.FontAttributes = FontAttributes.Bold;
                }
            }
            else
            {
                user.Email = emailEntry.Text;
                user.Password = passwordEntry.Text;
                try
                {
                    var returnValue = database.AddUser(user);
                    if (returnValue == "Sucessfully Added")
                    {
                        DisplayAlert("User Add", returnValue, "OK");
                        Navigation.PushModalAsync(new LoginPage());
                    }
                    else
                    {
                        DisplayAlert("User Added", returnValue, "OK");
                        warningLabel.IsVisible = false;
                        emailEntry.Text = string.Empty;
                        passwordEntry.Text = string.Empty;
                        confirmPasswordEntry.Text = string.Empty;
                    }
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex);
                }
            }
        }

        private void LogIn_OnClicked(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new LoginPage());
        }
    }
}