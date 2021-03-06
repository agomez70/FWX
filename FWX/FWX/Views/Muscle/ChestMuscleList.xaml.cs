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
    public partial class ChestMuscleList : ContentPage
    {
        private FWXDatabase database = new FWXDatabase();


        public ChestMuscleList()
        {
            BindingContext = this;

            InitializeComponent();
            FindWorkout(5);
        }

        List<Workout> FindWorkout(int id)
        {
            var workouts = database.GetMuscleList(id);
            ChestListView.ItemsSource = workouts;
            ChestListView.IsVisible = workouts.Any();
            return workouts;
        }


        void OnChestSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null)
                return;

            var workout = e.SelectedItem as Workout;

            ChestListView.SelectedItem = null;

            Navigation.PushModalAsync(new WorkoutDetailsPage(workout));
        }
    }
}