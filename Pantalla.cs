using System;
using System.Collections.Generic;
using System.Text;

namespace Trabajofinal
{
    class Pantalla
    {
        public static void pantalla1(int y, int x)
        {

            Console.SetCursorPosition(1, 1); Console.Write("┌");
            Console.SetCursorPosition(1, 6); Console.Write("┌");
            Console.SetCursorPosition(119, 1); Console.Write("┐");
            Console.SetCursorPosition(119, 6); Console.Write("┐");
            Console.SetCursorPosition(1, 5); Console.Write("└");
            Console.SetCursorPosition(1, 27); Console.Write("└");
            Console.SetCursorPosition(119, 5); Console.Write("┘");
            Console.SetCursorPosition(119, 27); Console.Write("┘");

            for (x = 2; x <= 118; x++)
            {
                Console.SetCursorPosition(x, 1); Console.Write("─");
                Console.SetCursorPosition(x, 27); Console.Write("─");
                Console.SetCursorPosition(x, 5); Console.Write("─");
                Console.SetCursorPosition(x, 6); Console.Write("─");
            }
            for (y = 2; y <= 4; y++)
            {
                Console.SetCursorPosition(1, y); Console.Write("│");
            }
            for (y = 7; y <= 26; y++)
            {
                Console.SetCursorPosition(1, y); Console.Write("│");
            }
            for (y = 2; y <= 4; y++)
            {
                Console.SetCursorPosition(1, y); Console.Write("│");
            }
            for (y = 2; y <= 4; y++)
            {
                Console.SetCursorPosition(119, y); Console.Write("│");

            }
            for (y = 7; y <= 26; y++)
            {
                Console.SetCursorPosition(119, y); Console.Write("│");

            }
        }
    }
}
