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
    public partial class CableEquipmentList : ContentPage
    {
        private FWXDatabase database = new FWXDatabase();


        public CableEquipmentList()
        {
            BindingContext = this;

            InitializeComponent();
            FindWorkout(4);
        }

        List<Workout> FindWorkout(int id)
        {
            var workouts = database.GetWorkoutList(id);
            CableListView.ItemsSource = workouts;
            CableListView.IsVisible = workouts.Any();
            return workouts;
        }


        void OnCableSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null)
                return;

            var workout = e.SelectedItem as Workout;

            CableListView.SelectedItem = null;

            Navigation.PushModalAsync(new WorkoutDetailsPage(workout));
        }
    }
}