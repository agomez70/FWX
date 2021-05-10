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
        private readonly FWXDatabase _database = new FWXDatabase();
        private readonly Workout _workout;

        public WorkoutDetailsPage(Workout workout)
        {
            //if (workout == null)
            //{
            //    throw new ArgumentNullException(nameof(workout));
            //}

            _workout = workout;

            InitializeComponent();

        }
        protected override void OnAppearing()
        {
            BindingContext = _database.GetWorkout(_workout);

            base.OnAppearing();
        }
    }
}