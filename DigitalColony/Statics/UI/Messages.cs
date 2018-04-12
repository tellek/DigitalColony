using System;
using System.Collections.Generic;
using System.Text;

namespace DigitalColony.Statics.UI
{
    public static class Messages
    {
        public static void PostMessage(string text)
        {
            
            Console.SetCursorPosition(0, 29);
            Console.ForegroundColor = ConsoleColor.White;
            for (int i = text.Length; i < 119; i++)
            {
                text += " ";
            }
            Console.Write(text.Substring(0, 118));
        }
    }
}
