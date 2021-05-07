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
    public partial class AbsMuscleList : ContentPage
    {
        private FWXDatabase database = new FWXDatabase();


        public AbsMuscleList()
        {
            BindingContext = this;

            InitializeComponent();
            FindWorkout(2);
        }

        List<Workout> FindWorkout(int id)
        {
            var workouts = database.GetMuscleList(id);
            AbsListView.ItemsSource = workouts;
            AbsListView.IsVisible = workouts.Any();
            return workouts;
        }


        void OnAbsSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null)
                return;

            var workout = e.SelectedItem as Workout;

            AbsListView.SelectedItem = null;

            Navigation.PushAsync(new WorkoutDetailsPage(workout));
        }
    }
}