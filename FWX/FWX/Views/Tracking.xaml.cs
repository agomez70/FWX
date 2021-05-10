using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FWX.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Tracking : ContentPage
    {
        //private Stopwatch stopwatch;
        public Tracking()
        {
            InitializeComponent();
            //stopwatch = new Stopwatch();

            //LabelStopWatch.Text = "00:00:000";
        }

        void Cell_OnTapped(object sender, EventArgs e)
        {
            var page = new WorkoutListPicker();
            page.WorkoutList.ItemSelected += (source, args) =>
            {
                WorkoutPicker.Text = args.SelectedItem.ToString();
                Navigation.PopAsync();
            };

            Navigation.PushAsync(page);
        }

        //private void BtnStart_OnClicked(object sender, EventArgs e)
        //{
        //    if (!stopwatch.IsRunning)
        //    {
        //        stopwatch.Start();

        //        Device.StartTimer(TimeSpan.FromSeconds(1), () =>
        //        {
        //            LabelStopWatch.Text = stopwatch.Elapsed.ToString();

        //            if (!stopwatch.IsRunning)
        //            {
        //                return false;
        //            }
        //            else
        //            {
        //                return true;
        //            }
                    
        //        });
        //    }
        //}

        //private void BtnStop_OnClicked(object sender, EventArgs e)
        //{
        //    BtnStart.Text = "Resume";
        //    stopwatch.Stop();
        //}

        //private void BtnReset_OnClicked(object sender, EventArgs e)
        //{
        //    LabelStopWatch.Text = "00:00:000";
        //    BtnStart.Text = "Start";
        //    stopwatch.Reset();
        //}
    }
}