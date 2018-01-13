using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MySql.Data;
using MySql.Data.MySqlClient;
using zaliczenie_ld_308.Controller;

namespace zaliczenie_ld_308
{
    class Program
    {
        static void Main(string[] args)
        {
            Menu menu = new Menu();
            while (true)
            {
                    menu.Display();
            }
        }
    }
}
