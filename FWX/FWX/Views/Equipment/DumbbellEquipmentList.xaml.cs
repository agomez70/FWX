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
    public partial class DumbbellEquipmentList : ContentPage
    {
        private FWXDatabase database = new FWXDatabase();


        public DumbbellEquipmentList()
        {
            BindingContext = this;

            InitializeComponent();
            FindWorkout(2);
        }

        List<Workout> FindWorkout(int id)
        {
            var workouts = database.GetWorkoutList(id);
            DumbbellListView.ItemsSource = workouts;
            DumbbellListView.IsVisible = workouts.Any();
            return workouts;
        }


        void OnDumbbellSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null)
                return;

            var workout = e.SelectedItem as Workout;

            DumbbellListView.SelectedItem = null;

            Navigation.PushAsync(new WorkoutDetailsPage(workout));
        }
    }
}