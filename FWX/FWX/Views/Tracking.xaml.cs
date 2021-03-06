using System;
using System.Diagnostics;
using FWX.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FWX.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Tracking : ContentPage
    {
        private readonly Stopwatch stopwatch;
        public Tracking()
        {
            InitializeComponent();
            stopwatch = new Stopwatch();

            LabelStopWatch.Text = "00:00";
        }

        void Cell_OnTapped(object sender, EventArgs e)
        {
            var page = new WorkoutListPicker();
            
            page.WorkoutList.ItemSelected += (source, args) =>
            {
                var temp = (Workout) page.WorkoutList.SelectedItem;
                WorkoutPicker.Text = temp.WorkoutName;
                Navigation.PopAsync();
            };

            Navigation.PushModalAsync(page);
        }

        private void BtnStart_OnClicked(object sender, EventArgs e)
        {
            if (!stopwatch.IsRunning)
            {
                stopwatch.Start();

                Device.StartTimer(TimeSpan.FromSeconds(1), () =>
                {
                    LabelStopWatch.Text = stopwatch.Elapsed.Seconds.ToString();

                    if (!stopwatch.IsRunning)
                    {
                        return false;
                    }
                    else
                    {
                        return true;
                    }

                });
            }
        }

        private void BtnStop_OnClicked(object sender, EventArgs e)
        {
            BtnStart.Text = "Resume";
            stopwatch.Stop();
        }

        private void BtnReset_OnClicked(object sender, EventArgs e)
        {
            LabelStopWatch.Text = "00:00";
            BtnStart.Text = "Start";
            stopwatch.Reset();
        }

        private void Next_OnClicked(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new Tracking());
        }

        private void Done_Clicked(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new MainMenu());
        }
    }
}