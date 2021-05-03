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
        //public MuscleGroup MuscleGroup { get; set; }
        //public Equipment Equipment { get; set; }
        public Tracking()
        {
            InitializeComponent();
            //FWXDatabase db = new FWXDatabase();
            //var x = db.GetEquipmentList();
            //EquipmentPicker.ItemsSource = x;
            //EquipmentPicker.ItemDisplayBinding = new Binding("EquipmentName");
            //EquipmentPicker.SelectedItem = new Binding("Workout");
            //EquipmentPicker.SelectedIndex = 0;
            //EquipmentPicker.SelectedIndexChanged += (sender, args) =>
            //{
            //    Equipment = (Equipment) EquipmentPicker.SelectedItem;
            //};
            //var y = db.GetMuscleGroupList();
            //MuscleGroupPicker.ItemsSource = y;
            //MuscleGroupPicker.ItemDisplayBinding = new Binding("MuscleGroup");
            //MuscleGroupPicker.SelectedItem = new Binding("Workout");
            //MuscleGroupPicker.SelectedIndex = 0;
            //MuscleGroupPicker.SelectedIndexChanged += (sender, args) =>
            //{
            //    MuscleGroup = (MuscleGroup) MuscleGroupPicker.SelectedItem;
            //};
        }
    }
}