using FWX.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android.Widget;
using FWX.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FWX.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ArmsMuscleList : ContentPage
    {
        private FWXDatabase database = new FWXDatabase();


        public ArmsMuscleList()
        {
            BindingContext = this;

            InitializeComponent();
            FindWorkout(3);
        }

        List<Workout> FindWorkout(int id)
        {
            var workouts = database.GetMuscleList(id);
            ArmsListView.ItemsSource = workouts;
            ArmsListView.IsVisible = workouts.Any();
            return workouts;
        }


        void OnArmsSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null)
                return;

            var workout = e.SelectedItem as Workout;

            ArmsListView.SelectedItem = null;

            Navigation.PushModalAsync(new WorkoutDetailsPage(workout));
        }
    }
}