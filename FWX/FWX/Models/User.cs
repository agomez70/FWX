using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace FWX.Models
{
    public class User
    {
        [PrimaryKey, AutoIncrement]
        public int UserID { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
