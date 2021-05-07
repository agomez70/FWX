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
    public partial class ShouldersMuscleList : ContentPage
    {
        public FWXDatabase database = new FWXDatabase();


        public ShouldersMuscleList()
        {
            BindingContext = this;

            InitializeComponent();
            FindWorkout(7);
        }

        List<Workout> FindWorkout(int id)
        {
            var workouts = database.GetMuscleList(id);
            ShouldersListView.ItemsSource = workouts;
            ShouldersListView.IsVisible = workouts.Any();
            return workouts;
        }


        void OnShouldersSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null)
                return;

            var workout = e.SelectedItem as Workout;

            ShouldersListView.SelectedItem = null;

            Navigation.PushAsync(new WorkoutDetailsPage(workout));
        }
    }
}