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
            Navigation.PushModalAsync(new OtherEquipmentWorkouts());
        }

        private void Dumbbells_OnClicked(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new DumbbellEquipmentList());
        }

        private void Barbell_OnClicked(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new BarbellEquipmentList());
        }

        private void Cables_OnClicked(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new CableEquipmentList());
        }

        private void Kettlebells_OnClicked(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new KettlebellEquipmentList());
        }

        private void Ball_OnClicked(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new BallEquipmentList());
        }

        private void Bands_OnClicked(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new BandEquipmentList());
        }

        private void Bodyweight_OnClicked(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new BodyweightEquipmentList());
        }
    }
}