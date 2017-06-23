using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectFour
{
   static class ConsoleHelper
    {
        public static void WriteLineColoredBackground(ConsoleColor color, string text)
        {
            Console.BackgroundColor = color;
            Console.WriteLine(text);
            Console.ResetColor();
        }

        public static void WriteColoredBackground(ConsoleColor color, string text)
        {
            Console.BackgroundColor = color;
            Console.Write(text);
            Console.ResetColor();
        }

        public static void WriteLineColoredForeground(ConsoleColor color, string text)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(text);
            Console.ResetColor();
        }

        public static void WriteColoredForeground(ConsoleColor color, string text)
        {
            Console.ForegroundColor = color;
            Console.Write(text);
            Console.ResetColor();
        }

        public static void WriteLineColoredForeAndBackground(ConsoleColor foregroundColor, ConsoleColor backgroundColor, string text)
        {
            Console.ForegroundColor = foregroundColor;
            Console.BackgroundColor = backgroundColor;
            Console.WriteLine(text);
            Console.ResetColor();
        }

        public static void WriteColoredForeAndBackground(ConsoleColor foregroundColor, ConsoleColor backgroundColor, string text)
        {
            Console.ForegroundColor = foregroundColor;
            Console.BackgroundColor = backgroundColor;
            Console.Write(text);
            Console.ResetColor();
        }
    }
}
