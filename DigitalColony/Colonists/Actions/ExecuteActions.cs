using DigitalColony.BaseEntity;
using System;
using System.Collections.Generic;
using System.Text;

namespace DigitalColony.Colonists.Actions
{
    public class ExecuteActions
    {
        public static void PerformAction(int input, Entity entity)
        {
            switch (input)
            {
                case 1:
                    // Move negative on the Y axis.
                    entity.Move(Direction.Up);
                    break;
                case 2:
                    // Move positive on the Y axis.
                    entity.Move(Direction.Down);
                    break;
                case 3:
                    // Move negative on the X axis.
                    entity.Move(Direction.Left);
                    break;
                case 4:
                    // Move positive on the Y axis.
                    entity.Move(Direction.Right);
                    break;
                default:
                    // Nothing happened with this option dislike it...
                    break;

            }
        }
    }
}
