using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using FWX.Models;
using SQLite;
using SQLitePCL;
using Xamarin.Forms;

namespace FWX.Data
{
    public class FWXDatabase
    {
        private static SQLiteConnection Database;

        public FWXDatabase()
        {
            string DatabasePath =
                Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "wxdb.db");
            Assembly assembly = IntrospectionExtensions.GetTypeInfo(typeof(App)).Assembly;
            Stream embeddedDatabaseStream = assembly.GetManifestResourceStream("FWX.wxdb.db");

            //if (File.Exists(DatabasePath))
            //{
            //    File.Delete(DatabasePath);
            //    FileStream fileStreamToWrite = File.Create(DatabasePath);
            //    embeddedDatabaseStream.Seek(0, SeekOrigin.Begin);
            //    embeddedDatabaseStream.CopyTo(fileStreamToWrite);
            //    fileStreamToWrite.Close();
            //}

            if (!File.Exists(DatabasePath))
            {
                FileStream fileStreamToWrite = File.Create(DatabasePath);
                embeddedDatabaseStream.Seek(0, SeekOrigin.Begin);
                embeddedDatabaseStream.CopyTo(fileStreamToWrite);
                fileStreamToWrite.Close();
            }

            Database = new SQLiteConnection(DatabasePath);
            //Database = DependencyService.Get<IConnection>().CreateConnection();
        }

        public List<Equipment> GetEquipmentList()
        {
            List<Equipment> equipments = Database.Table<Equipment>().ToList();
            return equipments;
        }

        public List<MuscleGroup> GetMuscleGroupList()
        {
            List<MuscleGroup> muscle = Database.Table<MuscleGroup>().ToList();
            return muscle;
        }

        public List<Workout> GetWorkoutList()
        {
            List<Workout> workout = Database.Table<Workout>().ToList();
            return workout;
        }

        public List<Workout> GetOtherEquipmentList()
        {
            List<Workout> workout = Database.Query<Workout>("Select * from Workout where EquipmentID = 1");
            return workout;
        }

    }
}
