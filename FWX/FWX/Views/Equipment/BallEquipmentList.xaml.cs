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
    public partial class BallEquipmentList : ContentPage
    {
        private FWXDatabase database = new FWXDatabase();


        public BallEquipmentList()
        {
            BindingContext = this;

            InitializeComponent();
            FindWorkout(6);
        }

        List<Workout> FindWorkout(int id)
        {
            var workouts = database.GetWorkoutList(id);
            ballListView.ItemsSource = workouts;
            ballListView.IsVisible = workouts.Any();
            return workouts;
        }


        void OnBallSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null)
                return;

            var workout = e.SelectedItem as Workout;

            ballListView.SelectedItem = null;

            Navigation.PushModalAsync(new WorkoutDetailsPage(workout));
        }
    }

}