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
    public partial class LegsMuscleList : ContentPage
    {
        private FWXDatabase database = new FWXDatabase();


        public LegsMuscleList()
        {
            BindingContext = this;

            InitializeComponent();
            FindWorkout(6);
        }

        List<Workout> FindWorkout(int id)
        {
            var workouts = database.GetMuscleList(id);
            LegsListView.ItemsSource = workouts;
            LegsListView.IsVisible = workouts.Any();
            return workouts;
        }


        void OnLegsSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null)
                return;

            var workout = e.SelectedItem as Workout;

            LegsListView.SelectedItem = null;

            Navigation.PushAsync(new WorkoutDetailsPage(workout));
        }
    }
}