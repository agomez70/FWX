using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android.Content;
using FWX.Data;
using FWX.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FWX.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BarbellEquipmentList : ContentPage
    {
        private FWXDatabase database = new FWXDatabase();

        public BarbellEquipmentList()
        {
            BindingContext = this;
            InitializeComponent();
            FindWorkout(3);
        }
        List<Workout> FindWorkout(int id)
        {
            var workouts = database.GetWorkoutList(id);
            barbellListView.ItemsSource = workouts;
            barbellListView.IsVisible = workouts.Any();
            return workouts;
        }


        void OnBarbellSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null)
                return;

            var workout = e.SelectedItem as Workout;

            barbellListView.SelectedItem = null;

            Navigation.PushAsync(new WorkoutDetailsPage(workout));
        }

    }
}