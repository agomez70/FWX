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
    public partial class WorkoutDetailsPage : ContentPage
    {
        private FWXDatabase _database = new FWXDatabase();

        public WorkoutDetailsPage(Workout workout)
        {
            //BindingContext = this;
            InitializeComponent();
            _database.GetWorkout(workout);
            ImageWorkout.Source = workout.WorkoutImage;
            WorkoutName.Text = workout.WorkoutName;
        }
    }
}