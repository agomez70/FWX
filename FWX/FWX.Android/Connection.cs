//using Android.App;
//using Android.Content;
//using Android.OS;
//using Android.Runtime;
//using Android.Views;
//using Android.Widget;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Reflection;
//using System.Runtime.CompilerServices;
//using System.Text;
//using System.IO;
//using FWX.Data;
//using SQLite;
//using Environment = System.Environment;

//namespace FWX.Droid
//{
//    public class Connection : IConnection
//    {
//        public SQLiteConnection CreateConnection()
//        {
//            var documentPath = System.Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
//            var path = Path.Combine(documentPath, "wxdb.db");
//            return new SQLiteConnection(path);
//        }
//    }
//}