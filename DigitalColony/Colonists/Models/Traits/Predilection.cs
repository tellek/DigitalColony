using System;
using System.Collections.Generic;
using System.Text;

namespace DigitalColony.Colonists.Models.Traits
{
    public class Predilection : Traits
    {
        /// <summary>
        /// How likely the DC is to just chill and do nothing.
        /// </summary>
        public int Resting { get; set; }

        /// <summary>
        /// Determines how often the DC will try new commands or stick to what is memorized.
        /// </summary>
        public int Initiative { get; set; }

        /// <summary>
        /// How likely the DC is to take exploration actions.
        /// </summary>
        public int Exploring { get; set; }
    }
}
