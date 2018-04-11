using DigitalColony.Colonists;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace DigitalColony
{
    class Program
    {
        private static int xCells = 118;
        private static int yCells = 28;

        static void Main(string[] args)
        {
            Console.CursorVisible = false;
            var area = new List<Entity>();
            PlaceMountains(area);
            var jim = new Colonist(area){ X=2, Y=2 };
            //var kira = new Colonist(area) { X = 100, Y = 10 };
            //var fred = new Colonist(area) { X = 75, Y = 22 };
            //var Sue = new Colonist(area) { X = 35, Y = 18 };
            area.Add(jim);
            //area.Add(kira);
            //area.Add(fred);
            //area.Add(Sue);


            while (true)
            {
                // Time in ticks.
                DrawArea(area);
                jim.Tick();
                //kira.Tick();
                //fred.Tick();
                //Sue.Tick();

                Thread.Sleep(500);
            }
        }

        static void DrawArea(List<Entity> area)
        {
            foreach (var c in area.Where(n => n.Redraw))
            {
                if (c.GetType() == typeof(Mountain)) WriteToConsole('M', c.X, c.Y);
                if (c.GetType() == typeof(Colonist)) WriteToConsole('C', c.X, c.Y);
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

    public class Entity
    {
        private List<Entity> _whereImAt { get; set; }

        public string Name { get; set; }
        // Current Coordinates
        public int X { get; set; }
        public int Y { get; set; }
        public bool Redraw { get; set; }
        // Previous Coordinates
        public int Px { get; set; }
        public int Py { get; set; }
        public bool Moved { get; set; }

        public Entity(List<Entity> WhereImAt)
        {
            _whereImAt = WhereImAt;
        }

        public void SetPreviousCoords()
        {
            Px = X;
            Py = Y;
        }

        public void Move(Direction direction)
        {
            switch (direction)
            {
                case Direction.Up:
                    if (_whereImAt.FindIndex(f => f.Y == Y - 1 && f.X == X) == -1)
                    {
                        DocumentBeforeMove();
                        Y--;
                    }
                    break;
                case Direction.Down:
                    if (_whereImAt.FindIndex(f => f.Y == Y + 1 && f.X == X) == -1)
                    {
                        DocumentBeforeMove();
                        Y++;
                    }
                    break;
                case Direction.Left:
                    if (_whereImAt.FindIndex(f => f.X == X - 1 && f.Y == Y) == -1)
                    {
                        DocumentBeforeMove();
                        X--;
                    }
                    break;
                case Direction.Right:
                    if (_whereImAt.FindIndex(f => f.X == X + 1 && f.Y == Y) == -1)
                    {
                        DocumentBeforeMove();
                        X++;
                    }
                    break;
            }
        }

        private void DocumentBeforeMove()
        {
            SetPreviousCoords();
            Moved = true;
            Redraw = true;
        }
    }

    public class Mountain : Entity
    {
        public Mountain(List<Entity> WhereImAt) : base(WhereImAt)
        {
        }
    }

    

    public enum Direction { Up, Down, Left, Right }
}
