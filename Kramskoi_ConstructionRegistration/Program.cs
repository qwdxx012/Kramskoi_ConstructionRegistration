using Kramskoi_ConstructionRegistration;
using Kramskoi_ConstructionRegistration.Models;
using PasswordSecurity;
using System;
using System.Text;

namespace Kramskoi_ConstructionRegistration
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.InputEncoding = Encoding.UTF8;
            Console.OutputEncoding = Encoding.UTF8;

            Console.WriteLine("Создание новой учетной записи для пользователя");
            Console.WriteLine();

            Console.Write("Введите имя пользователя: ");
            string firstName = Console.ReadLine();

            Console.Write("Введите фамилию пользователя: ");
            string lastName = Console.ReadLine();

            Console.Write("Введите логин пользователя: ");
            string login = Console.ReadLine();

            if (DbHelper.IsLoginExists(login))
            {
                Console.WriteLine("Пользователь с таким логином уже существует");
                Console.ReadKey();
                return;
            }

            Console.Write("Введите пароль пользователя: ");
            string password = Console.ReadLine();

            string passwordHash = PasswordHasher.GetPasswordHash(password);
            Console.WriteLine("Хешированный пароль пользователя: " + passwordHash);

            Users newUser = new Users
            {
                FirstName = firstName,
                LastName = lastName,
                Login = login,
                PasswordHash = passwordHash,
                RoleID = DbHelper.GetRoleIdByName("Пользователь")
            };

            DbHelper.AddUser(newUser);
            Console.WriteLine("Учетная запись добавлена");

            Console.ReadKey();
        }
    }
}
