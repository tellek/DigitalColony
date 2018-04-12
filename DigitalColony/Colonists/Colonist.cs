using DigitalColony.BaseEntity;
using DigitalColony.Colonists.Actions;
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
        private readonly List<ActionMemory> aMem = new List<ActionMemory>();
        private readonly Predilection pTrait = new Predilection();

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
            ExecuteActions.PerformAction(input, this);

        }

        private int DecideWhatToDo()
        {
            // Try something new, or do something remembered.
            if (Randomness.ShouldDo(pTrait.Initiative))
            {
                // Try something new.
                return Randomness.GetRandomNumber(0, 5);
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
