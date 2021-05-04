﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android.OS;
using Android.Widget;
using FWX.Data;
using FWX.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FWX.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EquipmentList : ContentPage
    {
        public Equipment Equipment { get; set; }
        public EquipmentList()
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


        }

        private void Other_OnClicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new OtherEquipmentWorkouts());
        }

        private void Dumbbells_OnClicked(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}//TODO: BUILT THE BUTTONS THAT CORRESPOND TO EACH CATEGORY. THEN TRY TO BUILD THE CAROSOUL FOR THE PICTURES. 