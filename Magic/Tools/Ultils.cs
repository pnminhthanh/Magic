using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Magic.Tools
{
    class Ultils
    {
        public static string FormatText(string text, int numberChar = 15)
        {
            if (text == null)
            {
                return "";
            }
            else
            {
                if (text.Length > numberChar)
                {
                    return text;
                }
                else
                {
                    int countSpace = numberChar - text.Length;
                    for (int i = 0; i < countSpace; i++)
                    {
                        text = text + ' ';
                    }
                    return text;
                }
            }
        }

        public static void Border(int length, int height, int left, int top)
        {
            for (int i = 0; i < length; i++)
            {
                Console.SetCursorPosition(left + i, top);
                if (i == 0 || i == length - 1)
                {
                    for (int j = 0; j < height; j++)
                    {
                        Console.SetCursorPosition(left + i, top + j + 1);
                        Console.Write("|");
                    }
                }
                else
                {
                    Console.Write("_");
                    Console.SetCursorPosition(left + i, top + height);
                    Console.Write("_");
                }
            }
        }
    }
}
