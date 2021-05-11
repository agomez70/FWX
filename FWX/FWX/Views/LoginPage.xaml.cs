using FWX.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android.Telephony;
using FWX.Data;
using SQLite;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FWX.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        private FWXDatabase database;
        public LoginPage()
        {
            InitializeComponent();
            database = new FWXDatabase();
            emailEntry.ReturnCommand = new Command(() => passwordEntry.Focus());
            firstPassword.ReturnCommand = new Command(() => secondPassword.Focus());
            var forgetPassword_Tap = new TapGestureRecognizer();
            forgetPassword_Tap.Tapped += ForgetPassword_Tap_Tapped;
            forgetLabel.GestureRecognizers.Add(forgetPassword_Tap);

        }

        private void ForgetPassword_Tap_Tapped(object sender, EventArgs e)
        {
            popupLoadingView.IsVisible = true;
        }

        private string login;
        private void UpdateButton_OnClicked(object sender, EventArgs e)
        {
            if ((string.IsNullOrWhiteSpace(emailValidationEntry.Text)) ||
                (string.IsNullOrEmpty(emailValidationEntry.Text)))
            {
                DisplayAlert("Alert!", "Enter Email", "OK");
            }
            else
            {
                login = emailValidationEntry.Text;
                var textResult = database.UpdateUserValidation(emailValidationEntry.Text);
                if (textResult)
                {
                    popupLoadingView.IsVisible = false;
                    passwordView.IsVisible = true;
                }
                else
                {
                    DisplayAlert("User Email Does Not Exist", "Enter a Correct Email", "OK");
                }
            }
        }
        private void PasswordButton_OnClicked(object sender, EventArgs e)
        {
            if (!string.Equals(firstPassword.Text, secondPassword.Text))
            {
                warningLabel.Text = "Enter The Same Password";
                warningLabel.TextColor = Color.DarkRed;
                warningLabel.IsVisible = true;
                warningLabel.FontAttributes = FontAttributes.Bold;
            }
            else if ((string.IsNullOrWhiteSpace(firstPassword.Text)) ||
                     (string.IsNullOrWhiteSpace(secondPassword.Text)))
            {
                DisplayAlert("Alert!", "Enter a Password", "OK");
            }
            else
            {
                try
                {
                    var returnOne = database.UpdateUser(login, firstPassword.Text);
                    passwordView.IsVisible = false;
                    if (returnOne)
                    {
                        DisplayAlert("Password Updated", "User Data Updated", "OK");
                    }
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        private void LoginValidation_OnClicked(object sender, EventArgs e)
        {
            if (emailEntry.Text != null && passwordEntry.Text != null)
            {
                var validData = database.LoginValidate(emailEntry.Text, passwordEntry.Text);
                if (validData)
                {
                    popupLoadingView.IsVisible = false;
                    Navigation.PushAsync(new MainMenu());
                }
                else
                {
                    popupLoadingView.IsVisible = false;
                    DisplayAlert("Login Failed", "Username or Password Incorrect", "OK");
                }
            }
            else
            {
                popupLoadingView.IsVisible = false;
                DisplayAlert("Uhmmmm", "Enter Email and Password Please", "OK");
            }
        }
    }
}