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
            Database.CreateTable<User>();
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

        public string AddUser(User user)
        {
            var response = Database.Table<User>();
            var data = response.Where(x => x.Email == user.Email && x.Password == user.Password).FirstOrDefault();
            if (data == null)
            {
                Database.Insert(user);
                return "Sucessfully Added";
            }
            else
            {
                return "Email already exists";
            }
        }

        public bool UpdateUserValidation(string id)
        {
            var response = Database.Table<User>();
            var data = (from values in response
                where values.Email == id
                select values).Single();

            if (data == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public bool UpdateUser(string email, string pwd)
        {
            var response = Database.Table<User>();
            var data = (from values in response
                where values.Email == email
                select values).Single();
            if (true)
            {
                data.Password = pwd;
                Database.Update(data);
                return true;
            }
        }

        public bool LoginValidate(string email, string pwd)
        {
            var response = Database.Table<User>();
            var data = response.Where(x => x.Email == email && x.Password == pwd).FirstOrDefault();

            if (data != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
