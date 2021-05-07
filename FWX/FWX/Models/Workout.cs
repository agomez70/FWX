using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using SQLite;
using Xamarin.Forms;

namespace FWX.Models
{
    public class Workout
    {
        [JsonProperty("muscle_id")]
        public int MuscleGroupID { get; set; }
        [JsonProperty("equipment_id")]
        public int EquipmentID { get; set; }
        [PrimaryKey]
        [JsonProperty("workout_id")]
        public int WorkoutID { get; set; }
        [JsonProperty("workout_name")]
        public string WorkoutName { get; set; }
        [JsonProperty("workout_image")]
        public string WorkoutImage { get; set; }

    }
}
