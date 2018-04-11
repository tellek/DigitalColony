//using System;
//using System.Collections.Generic;
//using System.Text;
//using System.Threading;

//namespace DigitalColony
//{
//    class OldCode
//    {
//        private static int xCells = 118;
//        private static int yCells = 28;

//        static void Main(string[] args)
//        {
//            Console.CursorVisible = false;
//            var area = new Dictionary<string, Entity>();

//            PlaceMountains(area);
//            area.Add($"Jim", new Colonist { X = 5, Y = 5 });
//            //PlaceTrees(area, 75);
//            DrawArea(area);



//            while (true)
//            {
//                MoveColonist(area["Jim"], Direction.Left, area);

//                Thread.Sleep(1000);
//            }
//        }

//        static void DrawArea(Dictionary<string, Entity> area)
//        {
//            foreach (var c in area)
//            {
//                if (c.Value.GetType() == typeof(Mountain)) WriteToConsole('M', c.Value.X, c.Value.Y);
//                if (c.Value.GetType() == typeof(Tree)) WriteToConsole('T', c.Value.X, c.Value.Y);
//                if (c.Value.GetType() == typeof(Colonist)) WriteToConsole('C', c.Value.X, c.Value.Y);
//            }
//        }

//        static void PlaceMountains(Dictionary<string, Entity> area)
//        {
//            for (int i = 0; i < yCells + 1; i++)
//            {
//                area.Add($"0.{i.ToString()}", new Mountain { X = 0, Y = i });
//                area.Add($"{xCells}.{i.ToString()}", new Mountain { X = xCells, Y = i });
//            }
//            for (int i = 1; i < xCells; i++)
//            {
//                area.Add($"{i.ToString()}.0", new Mountain { X = i, Y = 0 });
//                area.Add($"{i.ToString()}.{yCells}", new Mountain { X = i, Y = yCells });
//            }
//        }

//        //static void PlaceTrees(Dictionary<string, Entity> area, int amount)
//        //{
//        //    var random = new Random();
//        //    for (int a = 0; a < amount; a++)
//        //    {
//        //        int x = random.Next(1, xCells);
//        //        int y = random.Next(1, yCells);

//        //        if (area[$"{x}.{y}"].Iam.GetType() == typeof(EmptyLand))
//        //            area[$"{x}.{y}"].Iam = new Tree();
//        //        else
//        //            a--;
//        //    }
//        //}

//        static void MoveColonist(Entity colonist, Direction direction, Dictionary<string, Entity> area)
//        {
//            area.Remove($"Jim");
//            try
//            {
//                switch (direction)
//                {
//                    case Direction.Up:
//                        colonist.X = colonist.X - 1;
//                        break;
//                    case Direction.Down:
//                        colonist.X = colonist.X + 1;
//                        break;
//                    case Direction.Left:
//                        colonist.Y = colonist.Y - 1;
//                        break;
//                    case Direction.Right:
//                        colonist.Y = colonist.Y + 1;
//                        break;
//                }

//            }
//            catch (Exception)
//            {
//                Console.Write("TEST");
//            }
//            area.Add($"Jim", colonist);
//        }


//        static void WriteToConsole(char value, int x, int y)
//        {
//            Console.SetCursorPosition(x, y);
//            switch (value)
//            {
//                case 'M':
//                    Console.ForegroundColor = ConsoleColor.Red;
//                    Console.Write(value);
//                    break;
//                case 'T':
//                    Console.ForegroundColor = ConsoleColor.Green;
//                    Console.Write(value);
//                    break;
//                case 'C':
//                    Console.ForegroundColor = ConsoleColor.Cyan;
//                    Console.Write(value);
//                    break;
//                default:
//                    Console.ForegroundColor = ConsoleColor.White;
//                    Console.Write(value);
//                    break;
//            }

//        }

//    }

//    public class Entity
//    {
//        public int X { get; set; }
//        public int Y { get; set; }
//    }

//    public class Mountain : Entity
//    {

//    }

//    public class EmptyLand : Entity
//    {

//    }

//    public class Tree : Entity
//    {

//    }

//    public class Colonist : Entity
//    {
//        public void PerformAction(string input)
//        {
//            switch (input)
//            {
//                case "u":
//                    // Move negative on the Y axis.
//                    break;
//                case "d":
//                    // Move positive on the Y axis.
//                    break;
//                case "l":
//                    // Move negative on the X axis.
//                    break;
//                case "r":
//                    // Move positive on the Y axis.
//                    break;
//            }
//        }
//    }
//}
