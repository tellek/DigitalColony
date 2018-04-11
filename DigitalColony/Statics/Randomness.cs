using System;
using System.Collections.Generic;
using System.Text;

namespace DigitalColony.Statics
{
    public static class Randomness
    {
        private static Random random;

        static Randomness()
        {
            random = new Random();
        }

        public static int RollTheDie(int sides)
        {
            return random.Next(1,sides+1);
        }

        public static bool ShouldDo(int predilection)
        {
            int roll = random.Next(1, 10);
            if (roll <= predilection) return true;
            else return false;
        }

        public static int GetRandomNumber(int start, int end)
        {
            return random.Next(start, end + 1);
        }
    }
}
