using System;
using System.Collections.Generic;
using System.Text;

namespace DigitalColony.BaseEntity
{
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
                default:
                    break; // Do not move.
            }
        }

        private void DocumentBeforeMove()
        {
            SetPreviousCoords();
            Moved = true;
            Redraw = true;
        }
    }
}
