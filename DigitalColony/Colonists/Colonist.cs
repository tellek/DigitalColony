using DigitalColony.Colonists.Models.Memory;
using DigitalColony.Colonists.Models.Traits;
using DigitalColony.Statics;
using DigitalColony.Statics.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace DigitalColony.Colonists
{
    public class Colonist : Entity
    {
        private List<ActionMemory> aMem = new List<ActionMemory>();
        private List<LocationMemory> lMem = new List<LocationMemory>();
        private Predilection pTrait = new Predilection();

        public Colonist(List<Entity> WhereImAt) : base(WhereImAt)
        {
            // A new colonist is born.
            RandomizeTraits();
            Messages.PostMessage($"Jim was created with the following traits: Resting {pTrait.Resting}, Initiative {pTrait.Initiative}, Exploring {pTrait.Exploring}");
        }

        public void Tick()
        {
            // Check feelings after last action.
            // Remember last action results.

            int input = DecideWhatToDo();
            PerformAction(input);




        }

        private void PerformAction(int input)
        {
            switch (input)
            {
                case 0:
                    // Do nothing. Rest.
                    break;
                case 1:
                    // Move negative on the Y axis.
                    Move(Direction.Up);
                    break;
                case 2:
                    // Move positive on the Y axis.
                    Move(Direction.Down);
                    break;
                case 3:
                    // Move negative on the X axis.
                    Move(Direction.Left);
                    break;
                case 4:
                    // Move positive on the Y axis.
                    Move(Direction.Right);
                    break;
                default:
                    // Nothing happened with this option dislike it...
                    break;

            }
        }

        private int DecideWhatToDo()
        {
            // Try something new, or do something remembered.
            if (Randomness.ShouldDo(pTrait.Initiative))
            {
                // Try something new.
                return Randomness.GetRandomNumber(0, 25);
            }
            else
            {
                // Do something remembered.
                if (aMem.Count <= 0) return 0;
                return Randomness.GetRandomNumber(1, 4);
            }
        }

        private void RandomizeTraits()
        {
            pTrait.Resting = Randomness.GetRandomNumber(1, 8);
            pTrait.Initiative = Randomness.GetRandomNumber(1, 8);
            pTrait.Exploring = Randomness.GetRandomNumber(1, 8);
        }
    }
}
