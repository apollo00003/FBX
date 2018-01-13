using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using zaliczenie_ld_308.Entities;
using zaliczenie_ld_308.Utilities;

namespace zaliczenie_ld_308.Controller
{
    class Menu : Controller
    {
        public void Display()
        {
            CommonHelper.ClearConsole();
            if(this.env != "prod")
            {
                Console.WriteLine("Aktualnie pracujesz na środowisku {0}", this.env);
            }
            if(this.sessionUser != null)
            {
                Console.WriteLine("Jesteś zalogowany do systemu jako {0}", this.sessionUser.Username);
            }
            Console.WriteLine("Witaj na portalu FBX.pl");
            Console.WriteLine("Aby wyświetlic pomoc, naciśnij H");
            char key = CommonHelper.ParseKey(Console.ReadKey());
            this.ExecuteAction(key);
        }

        private void ExecuteAction(char action)
        {
            CommonHelper.ClearConsole();
            switch(action)
            {
                case '1'://ADD
                    {
                        CommonHelper.PrintElement("Dodawanie użytkownika", ConsoleColor.Blue);
                        User user = new User();
                        user.Create();
                    }
                    break;
                case '2'://GET
                    {
                        CommonHelper.PrintElement("Wyszukiwanie użytkownika.", ConsoleColor.Blue);
                        User user = new User();
                        user.Show();
                    }
                    break;
                case '3'://GETALL
                    {
                        CommonHelper.PrintElement("Lista wszystkich użytkowników.", ConsoleColor.Blue);
                        User user = new User();
                        user.ShowAll();
                    }
                    break;
                case '4'://ADD
                    {
                        CommonHelper.PrintElement("Dodawanie grupy", ConsoleColor.Blue);
                        Group group = new Group();
                        group.Create();
                    }
                    break;
                case '5'://GET
                    {
                        CommonHelper.PrintElement("Wyszukiwanie grupy.", ConsoleColor.Blue);
                        Group group = new Group();
                        group.Show();
                    }
                    break;
                case '6'://GETALL
                    {
                        CommonHelper.PrintElement("Lista wszystkich grup.", ConsoleColor.Blue);
                        Group group = new Group();
                        group.ShowAll();
                    }
                    break;
                case '7'://ADDUSERTOGROUP
                    {
                        CommonHelper.PrintElement("Dodaj użytkownika do grupy.", ConsoleColor.Blue);
                        User user = new User();
                        user.AddUserToGroup();
                    }
                    break;
                case '9'://GETUSERGROUPS
                    {
                        CommonHelper.PrintElement("Zaloguj się do systemu.", ConsoleColor.Blue);
                        this.Login();
                    }
                    break;
                case '0':
                    {
                        CommonHelper.PrintElement("Czy napewno chcesz wyjść z programu? y/n", ConsoleColor.Red);
                        char dec = CommonHelper.ParseKey(Console.ReadKey());
                        if (dec == 'y')
                        {
                            Console.WriteLine("Wychodzę z programu...");
                            Environment.Exit(0);
                        } else {
                            break;
                        }
                    }
                    break;
                case 'h':
                    this.DisplayHelp();
                    Console.ReadKey();
                    break;
                default:
                    CommonHelper.PrintElement("Dokonano niepoprawnego wyboru", ConsoleColor.DarkRed);
                    break;
            }
        }
        private void DisplayHelp()
        {
            CommonHelper.PrintElement("----- UŻYTKOWNICY -----", ConsoleColor.Cyan);
            Console.WriteLine("1: Dodaj użytkownika");
            Console.WriteLine("2: Wyszukaj użytkownika");
            Console.WriteLine("3: Wyświetl listę użytkowników");
            CommonHelper.PrintElement("-------- GRUPY --------", ConsoleColor.Cyan);
            Console.WriteLine("4: Dodaj grupę");
            Console.WriteLine("5: Wyświetl grupę");
            Console.WriteLine("6: Wyświetl listę grup");
            CommonHelper.PrintElement("-- GRUPY & UŻYTKOWNICY--", ConsoleColor.Cyan);
            Console.WriteLine("7: Dodaj użytkownika do grupy");
            Console.WriteLine("8: Wyświetl wszystkie grupy użytkownika");
            Console.WriteLine("9: Zaloguj do systemu");
            CommonHelper.PrintElement("-------- POZOSTAŁE --------", ConsoleColor.Cyan);
            Console.WriteLine("0: Wyjdź z programu");
            Console.WriteLine("Naciśnij dowolny klawisz, aby kontynuować...");
        }

    }
}
