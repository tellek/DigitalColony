using DigitalColony.BaseEntity;
using DigitalColony.Colonists;
using DigitalColony.Evironment.Scenery;
using DigitalColony.Statics;
using DigitalColony.Statics.UI;
using MoreLinq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace DigitalColony
{
    public class Program
    {
        private static int xCells = 118;
        private static int yCells = 28;

        static void Main(string[] args)
        {
            Console.CursorVisible = false;
            var area = new List<Entity>();
            PlaceMountains(area);
            var jim = new Colonist(area){ X=59, Y=14 };
            area.Add(jim);

            while (true)
            {
                // Time in ticks.
                DrawArea(area);
                jim.Tick();

                Thread.Sleep(500);
            }
        }

        static void DrawArea(List<Entity> area)
        {
            foreach (var c in area.Where(n => n.Redraw))
            {
                if (c.GetType() == typeof(Mountain)) { WriteToConsole('M', c.X, c.Y); }
                if (c.GetType() == typeof(Colonist)) { WriteToConsole('C', c.X, c.Y); }
                c.Redraw = false;
                if (c.Moved)
                {
                    WriteToConsole(' ', c.Px, c.Py);
                    c.Moved = false;
                }
            }
        }

        static void PlaceMountains(List<Entity> area)
        {
            for (int i = 0; i < yCells + 1; i++)
            {
                area.Add(new Mountain(area) { Name = "Mountain", X = 0, Y = i, Redraw = true });
                area.Add(new Mountain(area) { Name = "Mountain", X = xCells, Y = i, Redraw = true });
            }
            for (int i = 1; i < xCells; i++)
            {
                area.Add(new Mountain(area) { Name = "Mountain", X = i, Y = 0, Redraw = true });
                area.Add(new Mountain(area) { Name = "Mountain", X = i, Y = yCells, Redraw = true });
            }
        }

        static void WriteToConsole(char value, int x, int y)
        {
            Console.SetCursorPosition(x, y);
            switch (value)
            {
                case 'M':
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write(value);
                    break;
                case 'T':
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write(value);
                    break;
                case 'C':
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.Write(value);
                    break;
                default:
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write(value);
                    break;
            }

        }
    }
 
    public class TestModel
    {
        public string Name { get; set; }
        public int Value { get; set; }
        public int TempNum { get; set; }

        public TestModel(string n, int v)
        {
            this.Name = n;
            this.Value = v;
        }
    }
}
