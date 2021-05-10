using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Reflection;
using System.Threading.Tasks;
using FWX.Models;
using SQLite;

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
        }

        public List<Workout> GetWorkoutList(int id)
        {

            var response = Database.Query<Workout>($"Select * From Workout where EquipmentID = {id}").ToList<Workout>();
            return response;
        }
        public List<Workout> GetMuscleList(int id)
        {
            var response = Database.Query<Workout>($"Select * From Workout where MuscleGroupID = {id}").ToList<Workout>();
            return response;
        }

        public List<Workout> GetAll()
        {
            var response = Database.Query<Workout>("Select * From Workout").ToList<Workout>();
            return response;
        }

        public Workout GetWorkout(Workout name)
        {
            var response = Database.Get<Workout>(name);
            return response;
        }
    }
}
