using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace PlanningApp
{
    public class BinaryDao : IDao
    {
        private List<User> _users = null;

        public BinaryDao()
        {
            if (!Directory.Exists("User Data"))
            {
                Directory.CreateDirectory("User Data");
            }

            FileStream fsStream;
            if (!File.Exists("./users.dat"))
            {
                fsStream = File.Create("./users.dat");
            }
            else
            {
                fsStream = new FileStream("./users.dat", FileMode.Open, FileAccess.ReadWrite);
            }
            var formatter = new BinaryFormatter();
            if (fsStream.Length != 0)
            {
                try
                {
                    _users = (List<User>)formatter.Deserialize(fsStream);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else
            {
                _users = new List<User>();
                formatter.Serialize(fsStream, _users);
            }

            fsStream.Close();
        }

        ~BinaryDao()
        {
            UpdateUsersListInFile();
        }

        public bool CheckUserExist(User user)
        {
            foreach (var curUser in _users)
            {
                if (user.Username.Equals(curUser.Username))
                    return true;
            }

            return false;
        }

        public bool CheckUserValid(User user)
        {
            foreach (var curUser in _users)
            {
                if (user.Username.Equals(curUser.Username) && user.HashedPassword.Equals(curUser.HashedPassword))
                    return true;
            }

            return false;

        }

        public bool AddNewUser(User signupUser)
        {
            if (CheckUserExist(signupUser))
                return false;
            if (_users == null)
                return false;
            _users.Add(signupUser);

            var fStream = File.Create("User Data\\" + signupUser.Username + ".dat");
            var formatter = new BinaryFormatter();
            formatter.Serialize(fStream, new BindingList<Plan>());
            fStream.Close();

            return true;
        }

        public bool UpdateUsersListInFile()
        {
            if (_users == null) return false;
            if (!File.Exists("./users.dat"))
            {
                return false;
            }
            var fsStream = new FileStream("./users.dat", FileMode.Open, FileAccess.Write);
            var formatter = new BinaryFormatter();
            formatter.Serialize(fsStream, _users);
            fsStream.Close();

            return true;
        }

        public BindingList<Plan> LoadPlans(User user)
        {
            // USER NOT EXIST
            if (!File.Exists("User Data\\" + user.Username + ".dat"))
                return null;

            var fStream = new FileStream("User Data\\" + user.Username + ".dat", FileMode.Open, FileAccess.Read);
            var formatter = new BinaryFormatter();
            var plans = (BindingList<Plan>)formatter.Deserialize(fStream);
            fStream.Close();
            return plans;
        }

        public bool SavePlans(User user, BindingList<Plan> plans)
        {
            // USER NOT EXIST
            if (!File.Exists("User Data\\" + user.Username + ".dat"))
                return false;

            var fStream = new FileStream("User Data\\" + user.Username + ".dat", FileMode.Open, FileAccess.Write);
            var formatter = new BinaryFormatter();
            formatter.Serialize(fStream, plans);
            fStream.Close();
            return true;
        }
    }
}