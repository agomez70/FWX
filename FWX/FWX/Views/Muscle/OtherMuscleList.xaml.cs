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
    public partial class OtherMuscleList : ContentPage
    {
        private FWXDatabase database = new FWXDatabase();


        public OtherMuscleList()
        {
            BindingContext = this;

            InitializeComponent();
            FindWorkout(1);
        }

        List<Workout> FindWorkout(int id)
        {
            var workouts = database.GetMuscleList(id);
            OtherListView.ItemsSource = workouts;
            OtherListView.IsVisible = workouts.Any();
            return workouts;
        }


        void OnOtherSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null)
                return;

            var workout = e.SelectedItem as Workout;

            OtherListView.SelectedItem = null;

            Navigation.PushModalAsync(new WorkoutDetailsPage(workout));
        }
    }
}