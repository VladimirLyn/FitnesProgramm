using FitnesProgramm_BL.Model;
using FitnesProgramm_BL.Controller;
using System;

namespace FitnesProgramm_CMD
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Приветствуем вас");

            Console.WriteLine("Введите имя пользователя");
            var name = Console.ReadLine();

            var userController = new UserController(name);
            

            userController.Save();

        }
    }
}
