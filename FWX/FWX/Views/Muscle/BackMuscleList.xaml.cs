using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android.Widget;
using FWX.Data;
using FWX.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FWX.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BackMuscleList : ContentPage
    {
        private FWXDatabase database = new FWXDatabase();


        public BackMuscleList()
        {
            BindingContext = this;

            InitializeComponent();
            FindWorkout(4);
        }

        List<Workout> FindWorkout(int id)
        {
            var workouts = database.GetMuscleList(id);
            BackListView.ItemsSource = workouts;
            BackListView.IsVisible = workouts.Any();
            return workouts;
        }


        void OnBackSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null)
                return;

            var workout = e.SelectedItem as Workout;

            BackListView.SelectedItem = null;

            Navigation.PushAsync(new WorkoutDetailsPage(workout));
        }
    }
}