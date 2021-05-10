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
    public partial class WorkoutListPicker : ContentPage
    {
        private FWXDatabase database = new FWXDatabase();

        public WorkoutListPicker()
        {
            InitializeComponent();

            WorkoutPickerListView.ItemsSource = database.GetAll();
        }
        public ListView WorkoutList
        {
            get { return WorkoutPickerListView; }
        }
    }
}