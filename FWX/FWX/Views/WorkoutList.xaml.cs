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
    public partial class WorkoutList : ContentPage
    {
        public WorkoutList()
        {
            InitializeComponent();
        }

        private void EquipmentButton_OnClicked(object sender, EventArgs e)
        {


            Navigation.PushModalAsync(new EquipmentList());
        }

        private void MuscleGroupButton_OnClicked(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new MuscleGroupList());
        }
    }
}