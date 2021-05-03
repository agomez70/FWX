using FWX.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FWX.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FWX.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Tracking : ContentPage
    {
        public MuscleGroup MuscleGroup { get; set; }
        public Equipment Equipment { get; set; }
        public Workout Workout { get; set; }
        public Tracking()
        {
            InitializeComponent();
            FWXDatabase db = new FWXDatabase();
            var x = db.GetEquipmentList();
            EquipmentPicker.ItemsSource = x;
            EquipmentPicker.ItemDisplayBinding = new Binding("EquipmentName");
            EquipmentPicker.SelectedItem = new Binding("Workout");
            EquipmentPicker.SelectedIndex = 0;
            EquipmentPicker.SelectedIndexChanged += (sender, args) =>
            {
                Equipment = (Equipment)EquipmentPicker.SelectedItem;
            };
            var y = db.GetMuscleGroupList();
            MuscleGroupPicker.ItemsSource = y;
            MuscleGroupPicker.ItemDisplayBinding = new Binding("MuscleName");
            MuscleGroupPicker.SelectedItem = new Binding("Workout");
            MuscleGroupPicker.SelectedIndex = 0;
            MuscleGroupPicker.SelectedIndexChanged += (sender, args) =>
            {
                MuscleGroup = (MuscleGroup)MuscleGroupPicker.SelectedItem;
            };
            var k = db.GetWorkoutList();
            WorkoutPicker.ItemsSource = k;
            WorkoutPicker.ItemDisplayBinding = new Binding("WorkoutName");
            WorkoutPicker.SelectedItem = new Binding("Workout");
            WorkoutPicker.SelectedIndex = 0;
            WorkoutPicker.SelectedIndexChanged += (sender, args) =>
            {
                Workout = (Workout)WorkoutPicker.SelectedItem;
            };

            // TODO: FIX THE WORKOUT TRACKER 
            // IMPLEMENT THE SEARCH FUNCTION ON THE TRACKER 
            // ADD THE WORKOUTS AFTER SELECTED CATEGORY ON THE WORKOUT LIST 
        }
    }
}