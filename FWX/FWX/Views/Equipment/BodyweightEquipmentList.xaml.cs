using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FWX.Data;
using FWX.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FWX.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BodyweightEquipmentList : ContentPage
    {
        private FWXDatabase database = new FWXDatabase();

        public BodyweightEquipmentList()
        {
            BindingContext = this;
            InitializeComponent();
            FindWorkout(8);
        }

        List<Workout> FindWorkout(int id)
        {
            var workouts = database.GetWorkoutList(id);
            BodyWeightListView.ItemsSource = workouts;
            BodyWeightListView.IsVisible = workouts.Any();
            return workouts;
        }

        void OnBodyWeightSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null)
            {
                return;
            }

            var workout = e.SelectedItem as Workout;

            BodyWeightListView.SelectedItem = null;

            Navigation.PushAsync(new WorkoutDetailsPage(workout));
        }
    }
}