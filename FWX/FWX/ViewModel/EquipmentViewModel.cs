using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;
using System.Xml.Serialization;
using FWX.Data;
using FWX.Models;
using Xamarin.Forms;

namespace FWX.ViewModel
{
    public class EquipmentViewModel : INotifyPropertyChanged
    {
        FWXDatabase db = new FWXDatabase();
        
        public ObservableCollection<Workout> Workout { get; private set; }

        public Workout PreviousWorkout { get; set; }
        public Workout CurrentWorkout { get; set; }
        public Workout CurrentItem { get; set; }
        public int PreviousPosition { get; set; }
        public int CurrentPosition { get; set; }
        public int Position { get; set; }

        public ICommand ItemChangedCommand => new Command<Workout>(ItemChanged);
        public ICommand PositionChangedCommnad => new Command<int>(PositionChanged);

        public EquipmentViewModel()
        {
            var otherEquipment = db.GetOtherEquipmentList();

            CurrentItem = Workout.Skip(3).FirstOrDefault();
            OnPropertyChanged("CurrentItem");
            Position = 3;
            OnPropertyChanged("Position");
        }

        void ItemChanged(Workout item)
        {
            PreviousWorkout = CurrentWorkout;
            CurrentWorkout = item;
            OnPropertyChanged("PreviousWorkout");
            OnPropertyChanged("CurrentWorkout");
        }

        void PositionChanged(int position)
        {
            PreviousPosition = CurrentPosition;
            CurrentPosition = position;
            OnPropertyChanged("PreviousPosition");
            OnPropertyChanged("CurrentPosition");
        }

        public event PropertyChangedEventHandler PropertyChanged;

        void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
