using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using zaliczenie_ld_308.Services;
using zaliczenie_ld_308.Utilities;

namespace zaliczenie_ld_308.Entities
{
    class Group : SimpleEntity, IEntity<Group>
    {
        public override int Id { get; set; }
        public string Name { get; set; }

        public Group Create()
        {
            Group group = new Group();
            Console.Write("Wpisz nazwę grupy: ");
            group.Name = Console.ReadLine();

            GroupService groupService = new GroupService();
            bool res = groupService.Create(group);

            if (res == true)
            {
                Console.WriteLine("Grupa została pomyślnie utworzona.");
            }
            else
            {
                Console.WriteLine("Wystąpił błąd podczas tworzenia użytkownika");
            }
            CommonHelper.PressAnyKey();

            return this;
        }
        public Group Show()
        {
            Console.WriteLine("Wpisz nazwę grupy: ");
            Group group = new Group
            {
                Name = Console.ReadLine()
            };
            Console.WriteLine("Wskazana grupa {0}", group.Name);

            GroupService groupService = new GroupService();
            group = groupService.Get(group);
            if(group != null)
            {
                Console.WriteLine("name: {0}", group.Name);
            } else
            {
                CommonHelper.PrintElement("Wskazana grupa nie istnieje", ConsoleColor.DarkRed);
            }
            CommonHelper.PressAnyKey();

            return this;
        }
        public List<Group> ShowAll()
        {
            GroupService groupService = new GroupService();
            List<Group> GroupList = groupService.GetAll();

            Console.WriteLine("Name");
            foreach (Group group in GroupList)
            {
                Console.WriteLine(" - " + group.Name);
            }
            CommonHelper.PressAnyKey();

            return GroupList;
        }
    }
}
