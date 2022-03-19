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
            if (userController.isNewUser)
            {
                Console.Write("Введите пол: ");
                var gender = Console.ReadLine();
                DateTime birthDate;
                double height;

                while (true)
                {

                    Console.Write("Ввдеите дату рождения (дд.мм.гггг): ");

                    if (DateTime.TryParse(Console.ReadLine(), out birthDate))
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Неверный формат даты рождения");
                    }
                }



                userController.SetNewUserData();
            }

            Console.WriteLine(userController.CurrentUser);
            Console.ReadLine();
        }
    }
}
