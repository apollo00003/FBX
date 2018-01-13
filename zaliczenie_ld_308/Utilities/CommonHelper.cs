using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zaliczenie_ld_308.Utilities
{
    static class CommonHelper
    {
        public static void ClearConsole()
        {
            Console.Clear();
        }
        public static char ParseKey(ConsoleKeyInfo key)
        {
            return key.KeyChar;
        }

        public static void PrintElement(string text, ConsoleColor backgroundConsoleColor = ConsoleColor.White, ConsoleColor foregroundConsoleColor = ConsoleColor.Black)
        {
            Console.BackgroundColor = backgroundConsoleColor;
            Console.ForegroundColor = foregroundConsoleColor;
            Console.WriteLine(text);
            Console.ResetColor();
        }
        public static void PressAnyKey()
        {
            CommonHelper.PrintElement("Wciśnij dowolny klawisz, aby kontynować.", ConsoleColor.DarkCyan);
            Console.ReadKey();
        }

        public static void TranslateResponse(int responseCode, string successText)
        {
            switch (responseCode)
            {
                case 200:
                    CommonHelper.PrintElement(successText, ConsoleColor.Green);
                    CommonHelper.PressAnyKey();
                    break;
                case 901:
                    CommonHelper.PrintElement("Wskazany użytkownik nie istnieje", ConsoleColor.DarkRed);
                    CommonHelper.PressAnyKey();
                    break;
                case 902:
                    CommonHelper.PrintElement("Wskazana grupa nie istnieje", ConsoleColor.DarkRed);
                    CommonHelper.PressAnyKey();
                    break;
                case 904:
                    CommonHelper.PrintElement("Wystąpił błąd podczas wykonywania zapytania", ConsoleColor.DarkRed);
                    CommonHelper.PressAnyKey();
                    break;
            }
        }
    }
}
