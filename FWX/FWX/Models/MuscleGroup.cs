using System;
using System.Collections.Generic;
using System.Security.Principal;
using System.Text;
using SQLite;

namespace FWX.Models
{
    public class MuscleGroup
    {
        [PrimaryKey]
        public int MuscleGroupID { get; set; }
        public string MuscleName { get; set; }
    }
}
