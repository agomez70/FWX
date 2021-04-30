using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace FWX.Models
{
    public class Equipment
    {
        [PrimaryKey]
        public int EquipmentID { get; set; }
        public string EquipmentName { get; set; }
    }
}
