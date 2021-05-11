using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using Xamarin.Forms;

namespace FWX.Models
{
    public class Workout
    {
        public int MuscleGroupID { get; set; }
        public int EquipmentID { get; set; }
        [PrimaryKey]
        public int WorkoutID { get; set; }
        public string WorkoutName { get; set; }
        public string WorkoutImage { get; set; }
    }
}
