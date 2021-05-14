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
        public MuscleGroupList()
        {
            InitializeComponent();
        }
        private void Other_OnClicked(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new OtherMuscleList());
        }
        private void Abs_OnClicked(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new AbsMuscleList());
        }
        private void Arms_OnClicked(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new ArmsMuscleList());
        }
        private void Back_OnClicked(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new BackMuscleList());
        }
        private void Chest_OnClicked(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new ChestMuscleList());
        }
        private void Legs_OnClicked(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new LegsMuscleList());
        }
        private void Shoulders_OnClicked(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new ShouldersMuscleList());
        }
    }
}