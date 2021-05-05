using System;
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
        public EquipmentList()
        {
            InitializeComponent();
        }

        private void Other_OnClicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new OtherEquipmentWorkouts());
        }

        private void Dumbbells_OnClicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new DumbbellEquipmentList());
        }

        private void Barbell_OnClicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new BarbellEquipmentList());
        }

        private void Cables_OnClicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new CableEquipmentList());
        }

        private void Kettlebells_OnClicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new KettlebellEquipmentList());
        }

        private void Ball_OnClicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new BallEquipmentList());
        }

        private void Bands_OnClicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new BandEquipmentList());
        }

        private void Bodyweight_OnClicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new BodyweightEquipmentList());
        }
    }
}