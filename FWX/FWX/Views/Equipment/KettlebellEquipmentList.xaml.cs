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
    public partial class KettlebellEquipmentList : ContentPage
    {
        private FWXDatabase database = new FWXDatabase();


        public KettlebellEquipmentList()
        {
            BindingContext = this;

            InitializeComponent();
            FindWorkout(5);
        }

        List<Workout> FindWorkout(int id)
        {
            var workouts = database.GetWorkoutList(id);
            KettlebellListView.ItemsSource = workouts;
            KettlebellListView.IsVisible = workouts.Any();
            return workouts;
        }


        void OnKettlebellSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null)
                return;

            var workout = e.SelectedItem as Workout;

            KettlebellListView.SelectedItem = null;

            Navigation.PushAsync(new WorkoutDetailsPage(workout));
        }
    }
}