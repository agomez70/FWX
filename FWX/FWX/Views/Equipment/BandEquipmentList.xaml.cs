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
    public partial class BandEquipmentList : ContentPage
    {
        private FWXDatabase database = new FWXDatabase();

        public BandEquipmentList()
        {
            BindingContext = this;
            InitializeComponent();
            FindWorkout(7);
        }
        List<Workout> FindWorkout(int id)
        {
            var workouts = database.GetWorkoutList(id);
            bandListView.ItemsSource = workouts;
            bandListView.IsVisible = workouts.Any();
            return workouts;
        }
        void OnBandSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null)
                return;

            var workout = e.SelectedItem as Workout;

            bandListView.SelectedItem = null;

            Navigation.PushModalAsync(new WorkoutDetailsPage(workout));
        }
    }
}