using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using zaliczenie_ld_308.Services;
using zaliczenie_ld_308.Utilities;

namespace zaliczenie_ld_308.Entities
{
    class User : SimpleEntity, IEntity<User>
    {
        public User() { }
        public User(int id, string Username, string Email, string Password)
        {
            this.Id = id;
            this.Username = Username;
            this.Email = Email;
            this.Password = Password;
        }
        public User(string Username, string Email, string Password)
        {
            this.Username = Username;
            this.Email = Email;
            this.Password = Password;
        }

        public override int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public List<Group> GroupList { get; set; }

        public User Create()
        {
            User user = new User();
            Console.WriteLine("Wprowadź login: ");
            user.Username = Console.ReadLine();

            Console.WriteLine("Wprowadź email: ");
            user.Email = Console.ReadLine();

            Console.WriteLine("Wprowadź hasło: ");
            user.Password = Console.ReadLine();

            UserService userService = new UserService();
            bool res = userService.Create(user);

            if(res == true)
            {
                CommonHelper.PrintElement("Użytkownik został pomyślnie utworzony.", ConsoleColor.Green);
            } else {
                CommonHelper.PrintElement("Wystąpił błąd podczas tworzenia użytkownika", ConsoleColor.DarkRed);
            }
            CommonHelper.PressAnyKey();

            return user;
        }
        public User Show()
        {
            Console.WriteLine("Wpisz login użytkownika: ");
            User user = new User
            {
                Username = Console.ReadLine()
            };

            Console.WriteLine("Wskazany użytkownik {0}", user.Username);

            UserService userService = new UserService();
            user = userService.Get(user);
            if(user != null)
            {
                Console.WriteLine("username: {0}", user.Username);
                Console.WriteLine("email: {0}", user.Email);
                Console.WriteLine("password: {0}", user.Password);
                Console.WriteLine("Grupy użytkownika: ");
                if (user.GroupList == null)
                {
                    CommonHelper.PrintElement("Nie znaleziono żądnych przypisanych grup", ConsoleColor.Black);
                }
                else
                {
                    foreach (Group group in user.GroupList)
                    {
                        Console.WriteLine(" - " + group.Name);
                    }
                }
            } else
            {
                CommonHelper.PrintElement("Wskazany użytkownik nie istnieje", ConsoleColor.DarkRed);
            }
            CommonHelper.PressAnyKey();

            return this;
        }
        public List<User> ShowAll()
        {
            UserService userService = new UserService();
            List<User> userList = userService.GetAll();

            Console.WriteLine("Username");
            foreach(User user in userList)
            {
                Console.WriteLine(" - " + user.Username);
            }
            CommonHelper.PressAnyKey();
            
            return userList;
        }
        public void AddUserToGroup()
        {
            User user = new User();
            Group group = new Group();

            Console.WriteLine("Wprowadź login użytkownika");
            user.Username = Console.ReadLine();
            Console.WriteLine("Wprowadź nazwę grupy");
            group.Name = Console.ReadLine();

            UserService userGroupService = new UserService();
            bool res = userGroupService.AddUserToGroup(user, group);

            if (res)
            {
                CommonHelper.PrintElement("Użytkownik został pomyślnie dodany do grupy.", ConsoleColor.Green);
                CommonHelper.PressAnyKey();
            }
            else
            {
                CommonHelper.PrintElement("Wystąpił błąd podczas dodawania użytkownika do grupy", ConsoleColor.DarkRed);
                CommonHelper.PressAnyKey();
            }
        }
    }
}
