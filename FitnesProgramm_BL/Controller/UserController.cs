
using FitnesProgramm_BL.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;

namespace FitnesProgramm_BL.Controller
{
    /// <summary>
    /// Контролленр Пользователя
    /// </summary>
    public class UserController
    {
        public List<User> Users { get; }
        public User CurrentUser { get; }
        public UserController(string userName)
        {
            if (string.IsNullOrWhiteSpace(userName))
            {
                throw new ArgumentNullException("Имя не может быть 0", nameof(userName));
            }
            Users = GetUsersData();

            CurrentUser = Users.SingleOrDefault(u => u.Name == userName);
            if(CurrentUser == null)
            {
                CurrentUser = new User();
            }
        }
        public List<User> GetUsersData ()
        {
            var formatter = new BinaryFormatter();

            using (var fs = new FileStream("users.dat", FileMode.OpenOrCreate))
            {

                if (formatter.Deserialize(fs) is List<User> users)
                {
                   return users;
                }

               else
                {
                    return new List<User>();
                }
            }
            return null;
        }
        public void Save()
        {
            var formatter = new BinaryFormatter();
            using (var fs = new FileStream("users.dat", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, Users);
            }
        }
    }
}
