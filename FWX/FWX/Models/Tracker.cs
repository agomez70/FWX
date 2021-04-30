using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace FWX.Models
{
    public class Tracker
    {
        [PrimaryKey]
        public int TrackerID { get; set; }
        public int UserID { get; set; }
        public DateTime WorkoutDate { get; set; }
        public int WorkoutID { get; set; }
        public int Sets { get; set; }
        public int Reps { get; set; }
        public TimeSpan Rest { get; set; }
        public int Weight { get; set; }
    }
}
