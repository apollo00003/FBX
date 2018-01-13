using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using zaliczenie_ld_308.Entities;
using zaliczenie_ld_308.Utilities;

namespace zaliczenie_ld_308.Controller
{
    class Controller
    {
        protected User sessionUser = null;
        protected string database = "fbx";
        protected string host = "51.15.93.185";
        protected string password = "qwerty123";
        protected string username = "jipp";
        protected string env = "DEV";
        protected void CatchException(Exception ex)
        {
            if(this.env != "prod")
            {
                Console.WriteLine(ex);
            } else
            {
                Console.WriteLine("Wystąpił nieoczekiwany błąd, nastąpi zamknięcie programu...");
                Console.ReadKey();
            }
        }
        public void Login()
        {
            User user = new User();
            Console.WriteLine("Wpisz login użytkownika");
            user.Username = Console.ReadLine();
            Console.WriteLine("Wpisz hasło użytkownika");
            user.Password = Console.ReadLine();

            bool isLoginSuccesfull = Security.Login.Authorize(user);
            if (isLoginSuccesfull == true)
            {
                CommonHelper.PrintElement("Pomyślnie zalogowano do systemu.", ConsoleColor.Green);
                this.sessionUser = user;
            }
            else
            {
                CommonHelper.PrintElement("Nazwa użytkownika lub hasło są nieprawidłowe", ConsoleColor.DarkRed);
            }

            CommonHelper.PressAnyKey();
        }
    }
}
