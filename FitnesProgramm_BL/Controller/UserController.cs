
using FitnesProgramm_BL.Model;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace FitnesProgramm_BL.Controller
{
    /// <summary>
    /// Контролленр Пользователя
    /// </summary>
    public  class UserController
    {
        public User User { get; }
        public UserController(string userName, string genderName, DateTime birthDay,double weight,double height)
        {
            //TODO: Проверка
            var gender = new Gender(genderName);
            User  = new User(userName, gender, birthDay, weight, height);
        }
        /// <summary>
        /// Сохранение данных пользователя
        /// </summary>
        public void Save()
        {
            var formatter = new BinaryFormatter();
            using (var fs = new FileStream("users.dat", FileMode.OpenOrCreate)) 
            {
                formatter.Serialize(fs, User);
            }
        }
        /// <summary>
        /// получить данные пользователя
        /// </summary>
        /// <returns></returns>
        /// <exception cref="FileLoadException"></exception>
        public UserController ()
        {
            var formatter = new BinaryFormatter();

            using (var fs = new FileStream("users.dat", FileMode.OpenOrCreate))
            {

               if( formatter.Deserialize(fs) is User user)
                {
                    User = user;
                }
                //TODO: Что делать если пользователя не прочитали ?
            }
            
        }
    }
}
