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
    public partial class MuscleGroupList : ContentPage
    {
        public MuscleGroup MuscleGroup { get; set; }
        public MuscleGroupList()
        {
            InitializeComponent();
            FWXDatabase db = new FWXDatabase();
            var x = db.GetMuscleGroupList();
            MuscleGroupPicker.ItemsSource = x;
            MuscleGroupPicker.ItemDisplayBinding = new Binding("EquipmentName");
            MuscleGroupPicker.SelectedItem = new Binding("Workout");
            MuscleGroupPicker.SelectedIndex = 0;
            MuscleGroupPicker.SelectedIndexChanged += (sender, args) =>
            {
                MuscleGroup = (MuscleGroup)MuscleGroupPicker.SelectedItem;
            };
        }

       
    }
}